using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repositorio
{
    public class ReservaRepositorio : IReservaRepositorio
    {
        private HotelDBContext _ctx;

        public ReservaRepositorio(HotelDBContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Reserva> ObtenerPorUsuario(int? idUsuario)
        {
            return _ctx.Reserva.Include(r => r.Habitacion).Where(r => r.IdUsuario == idUsuario).ToList();
        }

        public void Reservar(int? idUsuario, Habitacion habitacion)
        {
            Reserva nueva = new();

            nueva.IdUsuario = (int)idUsuario;
            nueva.IdHabitacion = habitacion.Id;
            nueva.Precio = habitacion.Precio;
            nueva.FechaReserva= DateTime.Now;
            nueva.Habitacion = habitacion;

            habitacion.Estado = 2;

            _ctx.Reserva.Add(nueva);
            _ctx.Habitacion.Update(habitacion);

            _ctx.SaveChanges();

        }
    }
}
