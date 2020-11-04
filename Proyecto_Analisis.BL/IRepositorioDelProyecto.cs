using Proyecto_Analisis.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Analisis.BL
{
    public interface IRepositorioDelProyecto
    {
        public List<Persona> ObtenerTodosLosClientes();

        
        public List<Factura> ObtenerTodasLasFacturas();

        public List<Factura> ObtenerFacturasVacias();

        public List<Factura> ObtenerFacturasFinalizadas();

        public List<Producto> ObtenerTodosLosArticulos();

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
        List<Producto> ObtenerProductosDeFactura(int iD_Factura);
        Persona ObtenerClienteDeFactura(int iD_Factura);
        Factura ObtenerFacturaPorID(int iD_Factura);
    }
}
