using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositorio;
using Repositorio.Models;
using Repositorio.ViewModel;

namespace WEB.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        
        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Create(RegistroViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", viewModel);
            }
            
            _usuarioRepositorio.Create(viewModel);
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel viewmodel)
        {
            if (!ModelState.IsValid) return View(viewmodel);

            var usuario = _usuarioRepositorio.Login(viewmodel);

            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, "Credenciales incorrectas");
                return View(viewmodel);
            }

            HttpContext.Session.SetInt32("ExisteUsuario", 1);
            HttpContext.Session.SetInt32("TipoUsuario", 1);
            HttpContext.Session.SetString("Nombre", usuario.Nombre + " " + usuario.Apellido);



            return RedirectToAction("Index", "Habitaciones");
        }

    }
}
