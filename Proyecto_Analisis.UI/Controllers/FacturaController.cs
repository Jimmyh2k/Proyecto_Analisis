using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Proyecto_Analisis.BL;
using Proyecto_Analisis.Model;

namespace Proyecto_Analisis.UI.Controllers
{
    
    public class FacturaController : Controller
    {
        private readonly IRepositorioDelProyecto Repositorio;
        public FacturaController(IRepositorioDelProyecto repositorio)
        {
            Repositorio = repositorio;
}


        // GET: FacturaController
        public ActionResult Index()
        {
            List<Factura> Facturas;
            Facturas = Repositorio.ObtenerFacturasVacias();
            return View(Facturas);
        }

        public ActionResult FacturasFinalizadas() {
            List<Factura> Facturas;
            Facturas = Repositorio.ObtenerFacturasFinalizadas();
            return View(Facturas);
        }


        public ActionResult ListarClientes(int ID_Factura)
        {
            ViewBag.ID_Factura = ID_Factura;
            List<Persona> personas;
            personas = Repositorio.ObtenerTodosLosClientes();
            return View(personas);
        }

         
        public ActionResult MostrarArticulosDisponibles(int ID_Factura,int ID_Cliente) 
        {
            ViewBag.ID_Factura = ID_Factura;
            ViewBag.ID_Cliente = ID_Cliente;
            List<Producto> articulos;
            articulos = Repositorio.ObtenerArticulosDisponibles();
            return View(articulos);
        }


        
        public ActionResult AgregarALaFactura(int ID_Factura, int ID_Cliente, int ID_Producto)
        {
            Producto producto = new Producto();
            DetalleFactura detalleDeFactura = new DetalleFactura();
            detalleDeFactura.CodigoFactura= ID_Factura;
            detalleDeFactura.ID_Persona = ID_Cliente;
            detalleDeFactura.ID_Producto = ID_Producto;
            Repositorio.DecrementarCantidadDeProducto(ID_Producto);
            Repositorio.AgregarDetalleDeFactura(detalleDeFactura);
            return RedirectToAction("MostrarArticulosDisponibles", new RouteValueDictionary(new
            {
                controller = "Factura",
                Action = "MostrarArticulosDisponibles",

                ID_Factura = ID_Factura,
                ID_Cliente = ID_Cliente
            }));
        }


        // GET: FacturaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FacturaController/Create
        public ActionResult FacturaNueva()
        {
            
            return View();
        }

        // POST: FacturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FacturaNueva(Factura factura)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repositorio.AgregarFactura(factura);
                    return RedirectToAction("Index", new RouteValueDictionary(new
                    {
                        controller = "Factura",
                        Action = "Index",
                    }));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Finalizar(int ID_Factura)
        {
            ViewBag.ID_Factura = ID_Factura;
            Repositorio.FinalizarFactura(ID_Factura);

            EnviarFacturaXML(ID_Factura);

            List<Factura> facturasVacias;
            facturasVacias = Repositorio.ObtenerFacturasVacias();
            ViewBag.Mensaje = "El correo ha sido enviado a exitosamente";

            return RedirectToAction("Index", new RouteValueDictionary(new
            {
                controller = "Factura",
                Action = "Index",
            }));
        }

        public ActionResult Detalles(int ID_Factura)
        {
            List<Producto> productos;
            productos = Repositorio.ObtenerProductosDeFactura(ID_Factura);
            Persona Cliente = Repositorio.ObtenerClienteDeFactura(ID_Factura);
            Factura factura =Repositorio.ObtenerFacturaPorID(ID_Factura);
            FacturaDetallada facturaDetallada = new FacturaDetallada();
            facturaDetallada.FechaEmision = factura.FechaEmision;
            facturaDetallada.NombreComercial = factura.NombreComercial;
            facturaDetallada.ListaDeProductos = productos;
            facturaDetallada.MontoTotal = factura.MontoTotal;
            facturaDetallada.Cliente = Cliente;
            return View(facturaDetallada);
        }

        public void EnviarFacturaXML(int ID_Factura)
        {

            List<Producto> productos;
            productos = Repositorio.ObtenerProductosDeFactura(ID_Factura);
            Persona Cliente = Repositorio.ObtenerClienteDeFactura(ID_Factura);
            Factura factura = Repositorio.ObtenerFacturaPorID(ID_Factura);
            FacturaDetallada facturaDetallada = new FacturaDetallada();
            facturaDetallada.FechaEmision = factura.FechaEmision;
            facturaDetallada.NombreComercial = factura.NombreComercial;
            facturaDetallada.ListaDeProductos = productos;
            facturaDetallada.MontoTotal = factura.MontoTotal;
            facturaDetallada.Cliente = Cliente;

            String To = Cliente.CorreoElectronico;
            String Subject = "Factura de compras";
            String Body = Cliente.PrimerNombre + ", le agradecemos por su compra. Vuelva pronto.";
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(To);
            mailMessage.Subject = Subject;
            mailMessage.Body = Body;
            mailMessage.From = new MailAddress(Cliente.CorreoElectronico);
            mailMessage.IsBodyHtml = false;

            string facturaYClienteInfo =
    "<?xml version=\"1.0\" encoding=\"utf - 8\" ?>\n" +
    "< !--Factura.xml stores information about Mahesh Chand and related books -->\n" +
    "< Facturas >\n" +
        "\t< Factura Fecha de emision = \"" + factura.FechaEmision + "\" Monto total = \"" + factura.MontoTotal + "\" Comercio = \""
        + factura.NombreComercial + "\" >\n" +
            "\t\t< Cliente >" + Cliente.PrimerNombre + " " + Cliente.SegundoNombre + " " + Cliente.PrimerApellido + " " + Cliente.SegundoApellido + " </Cliente>\n";
            string productosInfo = "";
            foreach (var producto in productos)
            {
                productosInfo =
            "\t\t< Producto >\n" +
                "\t\t\t< Nombre > " + producto.Nombre + " </ Nombre >\n" +
                "\t\t\t< Detalle > " + producto.Detalle + " </ Detalle >\n" +
                "\t\t\t< Precio unitario > " + producto.PrecioUnitario + " </ Precio unitario >\n" +
                "\t\t\t< Cantidad > " + producto.Cantidad + " </ Cantidad >\n" +
            "\t\t</ Producto >\n"
            + productosInfo;

            }
            string finalDeLaCadena =
        "\t</ Factura >\n" +
     "</ Facturas > \n";
            String xmlCompleto = facturaYClienteInfo + productosInfo + finalDeLaCadena;


            mailMessage.Attachments.Add(Attachment.CreateAttachmentFromString(xmlCompleto, "Factura.xml"));

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("pruebasdelprograma@gmail.com", "contra segur@ 23");
            smtpClient.Send(mailMessage);
        }

    }
}
