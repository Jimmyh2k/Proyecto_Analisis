using Proyecto_Analisis.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Analisis.BL
{
    public interface IRepositorioDelProyecto
    {
        public List<Persona> ObtenerTodosLosClientes();

        public List<Producto> ObtenerTodosLosArticulos();

        public void AgregarProducto(Producto producto);

        public void AgregarCliente(Persona persona);

        public void EditarProducto(Producto producto);
        Producto ObtenerProductoPorId(int id);
    }
}
