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


        public void actualizar(Persona persona)
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
