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
    [Logeado]
    public class HabitacionesController : Controller
    {
        private IHabitacionRepositorio _habitacionRepositorio;

        public HabitacionesController(IHabitacionRepositorio habitacionRepositorio)
        {
            _habitacionRepositorio = habitacionRepositorio;
        }
       
        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Create(CreateHabitacionViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _habitacionRepositorio.Create(viewModel);
         
                return RedirectToAction("Index", "Habitaciones");
            
        }

        public IActionResult Index()
        {

            if (HttpContext.Session.GetInt32("TipoUsuario") == 1)
            {
                var habitaciones = _habitacionRepositorio.ObtenerHabitacionesDisponibles();
                return View("Index",habitaciones);
            }


            var habitacionesAdmin = _habitacionRepositorio.ObtenerTodas();
            return View("IndexAdmin", habitacionesAdmin);
        }

        public IActionResult Editar(int id)
        {
            var habitacion = _habitacionRepositorio.GetById(id);
            return View(habitacion);
        }

        [HttpPost]
        public IActionResult Editar(Habitacion  habitacion)
        {
            _habitacionRepositorio.Editar(habitacion);

            return RedirectToAction("Index", "Habitaciones");
        }
    }

}

