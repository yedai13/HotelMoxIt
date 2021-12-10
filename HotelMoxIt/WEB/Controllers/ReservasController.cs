using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositorio;
using Repositorio.Models;
using WEB.Filters;

namespace WEB.Controllers
{
    [Logeado]
    public class ReservasController : Controller
    {
        private IReservaRepositorio _reservaRepositorio;
        private IHabitacionRepositorio _habitacionRepositorio;

        public ReservasController(IReservaRepositorio reservaRepositorio, IHabitacionRepositorio habitacionRepositorio)
        {
            _reservaRepositorio = reservaRepositorio;
            _habitacionRepositorio = habitacionRepositorio;
        }


        public IActionResult Reservar(int id)
        {

            var habitacion = _habitacionRepositorio.GetById(id);
            var idUsuario = HttpContext.Session.GetInt32("Id");

            if (habitacion == null)
            {
                return RedirectToAction("Index", "Habitaciones");
            }

            _reservaRepositorio.Reservar(idUsuario, habitacion);
            ViewBag.Msg = "Se reservo correctamente";
            return RedirectToAction("Index", "Habitaciones");

        }

        
        public IActionResult Historial()
        {
            var idUsuario = HttpContext.Session.GetInt32("Id");

            IEnumerable<Reserva> reservas = _reservaRepositorio.ObtenerPorUsuario(idUsuario);

            return View(reservas);
        }
    }
}
