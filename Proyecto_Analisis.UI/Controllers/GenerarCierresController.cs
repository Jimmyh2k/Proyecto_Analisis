using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Analisis.BL;
using Proyecto_Analisis.Model;

namespace Proyecto_Analisis.UI.Controllers
{
    public class GenerarCierresController : Controller
    {

        private readonly IRepositorioDelProyecto Repositorio;
        public GenerarCierresController(IRepositorioDelProyecto repositorio)
        {
            Repositorio = repositorio;
        }

        public IActionResult Index()
        {
            List<Factura> facturas = new List<Factura>();
            facturas = Repositorio.ObtenerFacturasFinalizadas();
            int montoTotal= 0;
            foreach(var factura in facturas)
            {
                montoTotal = (int)factura.MontoTotal+ montoTotal;
            }
            CierresFacturas cierresFacturas = new CierresFacturas();
            cierresFacturas.facturas = facturas;
            cierresFacturas.montoTotal = montoTotal;

            return View(cierresFacturas);
        }

        public ActionResult Detalles(int ID_Factura)
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
            return View(facturaDetallada);
        }
    }
}
