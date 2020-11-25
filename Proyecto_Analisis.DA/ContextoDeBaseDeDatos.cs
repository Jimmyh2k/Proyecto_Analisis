using Microsoft.EntityFrameworkCore;
using Proyecto_Analisis.Model;

namespace Proyecto_Analisis.DA
{
    public class ContextoDeBaseDeDatos : DbContext
    {

        public ContextoDeBaseDeDatos()
        {

        }

        public ContextoDeBaseDeDatos(DbContextOptions<ContextoDeBaseDeDatos> opciones) : base(opciones)
        {
        }

        public DbSet<Factura> Factura { get; set; }
        public DbSet<DetalleFactura> DetalleFactura { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Producto> Producto { get; set; }




    }
}
