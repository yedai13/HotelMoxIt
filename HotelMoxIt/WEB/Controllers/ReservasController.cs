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
        private IUsuarioRepositorio _usuarioRepositorio;

        public ReservasController(IReservaRepositorio reservaRepositorio,
                                  IHabitacionRepositorio habitacionRepositorio,
                                  IUsuarioRepositorio usuarioRepositorio)
        {
            _reservaRepositorio = reservaRepositorio;
            _habitacionRepositorio = habitacionRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }


        public IActionResult Reservar(int id)
        {

            var habitacion = _habitacionRepositorio.GetById(id);
            var usuario = _usuarioRepositorio.GetById(HttpContext.Session.GetInt32("Id"));

            if (habitacion == null)
            {
                return RedirectToAction("Index", "Habitaciones");
            }

            _reservaRepositorio.Reservar(usuario, habitacion);
            ViewBag.Msg = "Se reservo correctamente";
            return RedirectToAction("Index", "Habitaciones");

        }

        
        public IActionResult Historial()
        {
            var idUsuario = HttpContext.Session.GetInt32("Id");

            if (HttpContext.Session.GetInt32("TipoUsuario") == 1)
            {
                IEnumerable<Reserva> reservas = _reservaRepositorio.ObtenerPorUsuario(idUsuario);

                return View(reservas);
            }

            IEnumerable<Reserva> reservasAdmin = _reservaRepositorio.ObtenerTodas();

            return View("HistorialAdmin",reservasAdmin);
        }
    }
}
