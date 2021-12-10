using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositorio;
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
       
        [EsAdmin]
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [EsAdmin]
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
