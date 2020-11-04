using System;
using System.Collections.Generic;
using System.Linq;
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

            List<Factura> facturasVacias;
            facturasVacias = Repositorio.ObtenerFacturasVacias();
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

    }
}
