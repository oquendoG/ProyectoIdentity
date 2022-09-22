using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProyectoIdentity.Datos;
using ProyectoIdentity.Models;
using ProyectoIdentity.ViewModels;

namespace ProyectoIdentity.Controllers
{
    public class CuentasController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public CuentasController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Registro(string returnurl)
        {
            ViewData["RedirectUrl"] = returnurl;
            var RegistroVM = new RegistroViewModel();

            return View(RegistroVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro(RegistroViewModel registro, string returnurl)
        {
            ViewData["RedirectUrl"] = returnurl;
            returnurl = returnurl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var usuario = new AppUsuario()
                {
                    UserName = registro.Email,
                    Email = registro.Email,
                    Nombre = registro.Nombre,
                    Url = registro.Url,
                    CodigoPais = registro.CodigoPais,
                    Telefono = registro.Telefono,
                    Pais = registro.Pais,
                    Ciudad = registro.Ciudad,
                    Direccion = registro.Direccion,
                    FechaNacimiento = registro.FechaNacimiento,
                    Estado = registro.Estado
                };

                var resultado = await userManager.CreateAsync(usuario, registro.Contraseña);

                if (resultado.Succeeded)
                {
                    await signInManager.SignInAsync(usuario, isPersistent: false);
                    return LocalRedirect(returnurl);
                }

                ValidarErrores(resultado);

            }

            return View(registro);

        }

        private void ValidarErrores(IdentityResult Resultado)
        {
            foreach (var error in Resultado.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        [HttpGet]
        public IActionResult IniciarSesion(string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IniciarSesion(AccesoViewModel model, string returnurl = null)
        {

            ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var resultado = await signInManager.
                    PasswordSignInAsync(model.Email, model.Contraseña, model.RemerberMe, 
                    lockoutOnFailure: false);

                if (resultado.Succeeded)
                {
                    return LocalRedirect(returnurl);
                } 
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos");
                    return View(model);
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CerrarSesion()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

    }
}
