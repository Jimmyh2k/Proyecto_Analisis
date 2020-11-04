using Proyecto_Analisis.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Analisis.BL
{
    public interface IRepositorioDelProyecto
    {
        public List<Persona> ObtenerTodosLosClientes();
        public Persona ObtenerClienteDeFactura(int ID_Factura);
        public List<Factura> ObtenerTodasLasFacturas();
        public Factura ObtenerFacturaPorID(int ID_Factura);
        public List<Factura> ObtenerFacturasVacias();

        public List<Factura> ObtenerFacturasFinalizadas();

        public List<Producto> ObtenerTodosLosArticulos();

        public List<Producto> ObtenerProductosDeFactura(int ID_Factura);

        public List<Producto> ObtenerArticulosDisponibles();

        public void FinalizarFactura(int ID_Factura);

        public void AgregarProducto(Producto producto);
        public void AgregarDetalleDeFactura(DetalleFactura detalleFactura);

        public void AgregarFactura(Factura factura);
        public void AgregarCliente(Persona persona);

        public void actualizarCliente(Persona persona);

        public void EliminarCliente(Persona persona);
        public void EliminarProducto(Producto producto);

        public Persona ObtenerPorId(int id);

        public void EditarProducto(Producto producto);
        public void DecrementarCantidadDeProducto(int ID_Producto);
        Producto ObtenerProductoPorId(int id);
    }
}
