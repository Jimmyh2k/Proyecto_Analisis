using Microsoft.EntityFrameworkCore;
using Proyecto_Analisis.Model;

namespace Proyecto_Analisis.DA
{
    class ContextoDeBaseDeDatos : DbContext
    {

        public ContextoDeBaseDeDatos(DbContextOptions<ContextoDeBaseDeDatos> opciones) : base(opciones)
        {
        }

        public DbSet<Canton> Canton { get; set; }
        public DbSet<CorreoElectronico> CorreoElectronico { get; set; }
        public DbSet<Distrito> Distrito { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<MetodoDePago> MetodoDePago { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<Reporte> Reporte { get; set; }




    }
}
