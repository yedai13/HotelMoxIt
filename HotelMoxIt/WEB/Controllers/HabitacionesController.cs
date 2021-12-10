using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositorio;
using Repositorio.ViewModel;

namespace WEB.Controllers
{
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
         
                return View();
            
        }

        public IActionResult Index()
        {
            var habitaciones = _habitacionRepositorio.ObtenerHabitacionesDisponibles();
            return View(habitaciones);
        }
       
    }
}
