using Repositorio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio.Models;

namespace Repositorio
{
    public class HabitacionRepositorio : IHabitacionRepositorio
    {
        private HotelDBContext _ctx;

        public HabitacionRepositorio(HotelDBContext ctx)
        {
            _ctx = ctx;
        }
        public void Create(CreateHabitacionViewModel habitacion)
        {
            Habitacion nuevo = new();

            nuevo.NroHabitacion = habitacion.NroHabitacion;
            nuevo.Capacidad = habitacion.Capacidad;
            nuevo.Estado = habitacion.Estado;
            nuevo.Precio = habitacion.Precio;

            _ctx.Habitacion.Add(nuevo);
            _ctx.SaveChanges();
        }

        public Habitacion GetById(int id)
        {
            return _ctx.Habitacion.Where(h => h.Id == id).FirstOrDefault();
        }

        public IEnumerable<Habitacion> ObtenerHabitacionesDisponibles()
        {
            return _ctx.Habitacion.Where(h=> h.Estado == 1).ToList();
        }

        public IEnumerable<Habitacion> ObtenerTodas()
        {
            return _ctx.Habitacion.ToList();
        }
    }
}
