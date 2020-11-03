using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Proyecto_Analisis.UI.Areas.Identity.Data;

namespace Proyecto_Analisis.UI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<UsuariosDeProgramaDeFacturacion> _signInManager;
        private readonly UserManager<UsuariosDeProgramaDeFacturacion> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<UsuariosDeProgramaDeFacturacion> userManager,
            SignInManager<UsuariosDeProgramaDeFacturacion> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }
        

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "El nombre es requerido")]
            [DataType(DataType.Text)]
            [Display(Name = "Nombre")]
            public string Name { get; set; }

            [Required(ErrorMessage = "El correo es requerido")]
            [EmailAddress]
            [Display(Name = "Correo")]
            public string Email { get; set; }

            [Required(ErrorMessage = "La contraseña es requerida")]
            [StringLength(100, ErrorMessage = "La {0} debe ser al menos {2} y máximo de {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirme contraseña")]
            [Compare("Password", ErrorMessage = "La contraseña y la confirmación de la contraseña no coincide.")]
            public string ConfirmPassword { get; set; }

            [Display(Name = "¿Asignar rol de administrador?")]
            public bool Administrador { get; set; }

            [Display(Name = "¿Asignar rol de agente de ventas?")]
            public bool AgenteDeVentas { get; set; }
        }

        public async Task <IActionResult> CrearRoles() 
        {
            var roleExiste = await _roleManager.RoleExistsAsync("Administrador");
            if (!roleExiste) 
            {
                var result = await _roleManager.CreateAsync(new IdentityRole("Administrador"));
            }
            var roleExiste2 = await _roleManager.RoleExistsAsync("Agente de ventas");
            if (!roleExiste)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole("Agente de ventas"));
            }
            return Page();

        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
             
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                await CrearRoles();
                var user = new UsuariosDeProgramaDeFacturacion { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);

                
                if (result.Succeeded)
                {
                 

                    if (Input.Administrador == true) { _userManager.AddToRoleAsync(user, "Administrador").Wait(); }
                    if (Input.AgenteDeVentas == true) { _userManager.AddToRoleAsync(user, "Agente de ventas").Wait(); }
                    _logger.LogInformation("Usuario creó una nueva cuenta con contraseña.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirme su correo",
                        $"Por favor confirme su cuenta haciendo <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'> click aquí</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        
                        
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }


            
            return Page();
        }


        
    }
}
