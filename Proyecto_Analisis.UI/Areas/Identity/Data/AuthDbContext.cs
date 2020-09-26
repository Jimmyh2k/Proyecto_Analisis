﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proyecto_Analisis.UI.Areas.Identity.Data;

namespace Proyecto_Analisis.UI.Data
{
    public class AuthDbContext : IdentityDbContext<UsuariosDeProgramaDeFacturacion>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {

            Database.EnsureCreated();

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
