using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio.Models;
using Repositorio.ViewModel;

namespace Repositorio
{
    public interface IHabitacionRepositorio
    {
        void Create(CreateHabitacionViewModel habitacion);
        IEnumerable<Habitacion> ObtenerHabitacionesDisponibles();
        Habitacion GetById(int id);
        IEnumerable<Habitacion> ObtenerTodas();
    }
}
