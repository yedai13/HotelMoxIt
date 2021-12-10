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
        void Reservar(Usuario usuario, Habitacion habitacion);
        IEnumerable<Reserva> ObtenerPorUsuario(int? idUsuario);
        IEnumerable<Reserva> ObtenerTodas();
    }
}
