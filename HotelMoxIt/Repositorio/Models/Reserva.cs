using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdHabitacion { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaReserva { get; set; }
    }
}
