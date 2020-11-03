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

        public void AgregarProducto(Producto producto)
        {
            ElContextoDeBaseDeDatos.Producto.Add(producto);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

        public void EditarProducto(Producto producto)
        {
            Producto productoParaActualizar = ObtenerProductoPorId(producto.ID_Producto);
            productoParaActualizar.Nombre = producto.Nombre;
            productoParaActualizar.Detalle = producto.Detalle;
            productoParaActualizar.PrecioUnitario = producto.PrecioUnitario;
            productoParaActualizar.Cantidad = producto.Cantidad;
            ElContextoDeBaseDeDatos.Producto.Update(productoParaActualizar);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

        public Producto ObtenerProductoPorId(int id)
        {
            Producto producto;
            producto = ElContextoDeBaseDeDatos.Producto.Find(id);
            return producto;
        }

        public List<Producto> ObtenerTodosLosArticulos()
        {
            List<Producto> Lalista;
            Lalista = ElContextoDeBaseDeDatos.Producto.ToList();
            return Lalista;
        }

        public List<Persona> ObtenerTodosLosClientes()
        {
            List<Persona> Lalista;
            Lalista = ElContextoDeBaseDeDatos.Persona.ToList();
            return Lalista;
        }
    }
}
