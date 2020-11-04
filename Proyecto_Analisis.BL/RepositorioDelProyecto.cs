using Proyecto_Analisis.DA;
using Proyecto_Analisis.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Proyecto_Analisis.BL
{
    public class RepositorioDelProyecto : IRepositorioDelProyecto
    {

        private ContextoDeBaseDeDatos ElContextoDeBaseDeDatos;
        public RepositorioDelProyecto(ContextoDeBaseDeDatos contexto)
        {
            ElContextoDeBaseDeDatos = contexto;

        }

        public void AgregarCliente(Persona persona)
        {
            ElContextoDeBaseDeDatos.Persona.Add(persona);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

        public void FinalizarFactura(int ID_Factura) {
            int montoTotal=0;
            Factura facturaParaFinalizar = ElContextoDeBaseDeDatos.Factura.Find(ID_Factura);
            List<DetalleFactura> detallesDeFactura;
            detallesDeFactura= ElContextoDeBaseDeDatos.DetalleFactura.ToList();
            foreach (var detalle in detallesDeFactura)
            {
                if (detalle.CodigoFactura== facturaParaFinalizar.CodigoFactura) 
                {
                    Producto producto = ObtenerProductoPorId(detalle.ID_Producto);
                    montoTotal += producto.PrecioUnitario;
                }

            }
            facturaParaFinalizar.MontoTotal = montoTotal;
            facturaParaFinalizar.FechaEmision = DateTime.Now;
            ElContextoDeBaseDeDatos.Factura.Update(facturaParaFinalizar);
            ElContextoDeBaseDeDatos.SaveChanges();


        }
        public void actualizarCliente(Persona persona)
        {
            Persona PersonaPorActualizar;
            PersonaPorActualizar = ObtenerPorId(persona.ID);

            PersonaPorActualizar.PrimerNombre = persona.PrimerNombre;
            PersonaPorActualizar.SegundoNombre = persona.SegundoNombre;
            PersonaPorActualizar.PrimerApellido = persona.PrimerApellido;
            PersonaPorActualizar.SegundoApellido = persona.SegundoApellido;
            PersonaPorActualizar.CorreoElectronico = persona.CorreoElectronico;
            PersonaPorActualizar.Pais = persona.Pais;
            PersonaPorActualizar.Provincia = persona.Provincia;
            PersonaPorActualizar.Canton = persona.Canton;
            PersonaPorActualizar.Distrito = persona.Distrito;
            ElContextoDeBaseDeDatos.Persona.Update(PersonaPorActualizar);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

        public Persona ObtenerPorId(int id)
        {
            Persona persona;
            persona = ElContextoDeBaseDeDatos.Persona.Find(id);
            return persona;
        }
        public void EliminarCliente(Persona persona) {
            ElContextoDeBaseDeDatos.Persona.Remove(persona);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

        public void AgregarProducto(Producto producto)
        {
            ElContextoDeBaseDeDatos.Producto.Add(producto);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

        public void AgregarFactura(Factura factura){
            
            ElContextoDeBaseDeDatos.Factura.Add(factura);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

        public List<Factura> ObtenerFacturasVacias() {
            List<Factura> todasLasFacturas;
            List<Factura> facturasVacias;
            todasLasFacturas = ObtenerTodasLasFacturas();
            facturasVacias = ObtenerTodasLasFacturas();

            foreach (var factura in todasLasFacturas)
            {
                if (factura.FechaEmision!=null) {
                    facturasVacias.Remove(factura);
                }

            }
            return facturasVacias;
        }

        public List<Factura> ObtenerFacturasFinalizadas() {

            List<Factura> todasLasFacturas;
            List<Factura> facturasFinalizadas;
            todasLasFacturas = ObtenerTodasLasFacturas();
            facturasFinalizadas = ObtenerTodasLasFacturas();

            foreach (var factura in todasLasFacturas)
            {
                if (factura.FechaEmision == null)
                {
                    facturasFinalizadas.Remove(factura);
                }

            }
            return facturasFinalizadas;

        }

        public void AgregarDetalleDeFactura(DetalleFactura detalleFactura) {
            ElContextoDeBaseDeDatos.DetalleFactura.Add(detalleFactura);
            ElContextoDeBaseDeDatos.SaveChanges();
        }
        public void EditarProducto(Producto producto)
        {
            Producto productoParaActualizar = ElContextoDeBaseDeDatos.Producto.Find(producto.ID_Producto);
            productoParaActualizar.Nombre = producto.Nombre;
            productoParaActualizar.Detalle = producto.Detalle;
            productoParaActualizar.PrecioUnitario = producto.PrecioUnitario;
            productoParaActualizar.Cantidad = producto.Cantidad;
            ElContextoDeBaseDeDatos.Producto.Update(productoParaActualizar);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

        public void DecrementarCantidadDeProducto(int ID_Producto) 
        {
            Producto productoParaActualizar = ElContextoDeBaseDeDatos.Producto.Find(ID_Producto);
            productoParaActualizar.Cantidad = productoParaActualizar.Cantidad - 1;
            ElContextoDeBaseDeDatos.Producto.Update(productoParaActualizar);
            ElContextoDeBaseDeDatos.SaveChanges();
        }
        public Producto ObtenerProductoPorId(int id)
        {
            Producto producto;
            producto = ElContextoDeBaseDeDatos.Producto.Find(id);
            return producto;
        }

        public List<Factura> ObtenerTodasLasFacturas()
        {
            List<Factura> Lalista;
            Lalista = ElContextoDeBaseDeDatos.Factura.ToList();
            return Lalista;
        }

        public List<Producto> ObtenerTodosLosArticulos()
        {
            List<Producto> Lalista;
            Lalista = ElContextoDeBaseDeDatos.Producto.ToList();
            return Lalista;
        }

        public List<Producto> ObtenerArticulosDisponibles() 
        {
            List<Producto> Lalista;
            List<Producto> listaDeDisponibles;
            listaDeDisponibles= ElContextoDeBaseDeDatos.Producto.ToList();
            Lalista = ElContextoDeBaseDeDatos.Producto.ToList();
            foreach (var producto in Lalista)
            {
                if (producto.Cantidad<1) 
                {
                    listaDeDisponibles.Remove(producto);
                }
            }
            return listaDeDisponibles;

        }
        public List<Persona> ObtenerTodosLosClientes()
        {
            List<Persona> Lalista;
            Lalista = ElContextoDeBaseDeDatos.Persona.ToList();
            return Lalista;
        }

        public void EliminarProducto(Producto producto)
        {
            ElContextoDeBaseDeDatos.Producto.Remove(producto);
            ElContextoDeBaseDeDatos.SaveChanges();
        }
    }
}
