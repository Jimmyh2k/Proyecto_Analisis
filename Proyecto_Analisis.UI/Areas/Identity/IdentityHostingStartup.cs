using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Proyecto_Analisis.UI.Areas.Identity.Data;
using Proyecto_Analisis.UI.Data;

[assembly: HostingStartup(typeof(Proyecto_Analisis.UI.Areas.Identity.IdentityHostingStartup))]
namespace Proyecto_Analisis.UI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        
        
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthDbContextConnection")));

                services.AddDefaultIdentity<UsuariosDeProgramaDeFacturacion>(options => options.SignIn.RequireConfirmedAccount = false).
                AddRoles<IdentityRole>().AddEntityFrameworkStores<AuthDbContext>();
                services.AddAuthorization(options =>
                {
                    options.AddPolicy("RequireRoleAdministrativo",
                         policy => policy.RequireRole("Administrador"));
                });
            });
        }
        

    }
}