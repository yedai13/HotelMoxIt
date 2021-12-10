using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public interface IReservaRepositorio
    {
        void Reservar(int? idUsuario, Habitacion habitacion);
        IEnumerable<Reserva> ObtenerPorUsuario(int? idUsuario);
    }
}
