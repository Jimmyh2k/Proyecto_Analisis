using Microsoft.EntityFrameworkCore;
using Proyecto_Analisis.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Analisis.DA
{
    public class ContextoDeUsuarios : DbContext
    {
        public ContextoDeUsuarios(DbContextOptions<ContextoDeUsuarios> opciones) : base(opciones)
        {
        }

        

            
        //public DbSet<Roles> Roles { get; set; }
    }
}
