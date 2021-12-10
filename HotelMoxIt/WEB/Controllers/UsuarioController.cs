using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositorio;
using Repositorio.Models;
using Repositorio.ViewModel;
using WEB.Filters;

namespace WEB.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        

        [NoLogeado]
        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [NoLogeado]
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


        [NoLogeado]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [NoLogeado]
        public IActionResult Login(LoginViewModel viewmodel)
        {
            if (!ModelState.IsValid) return View(viewmodel);

            var usuario = _usuarioRepositorio.Login(viewmodel);

            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, "Credenciales incorrectas");
                return View(viewmodel);
            }

            HttpContext.Session.SetInt32("Id", usuario.Id);
            HttpContext.Session.SetInt32("ExisteUsuario", 1);
            HttpContext.Session.SetInt32("TipoUsuario", usuario.TipoUsuario);
            HttpContext.Session.SetString("Nombre", usuario.Nombre + " " + usuario.Apellido);



            return RedirectToAction("Index", "Habitaciones");
        }

        [Logeado]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Create", "Habitaciones");
        }

        public IActionResult Editar()
        {
            var idUsuario =HttpContext.Session.GetInt32("Id");
            var usuario = _usuarioRepositorio.GetById(idUsuario);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            _usuarioRepositorio.Editar(usuario);
            return RedirectToAction("Index", "Habitaciones");
        }

    }
}
