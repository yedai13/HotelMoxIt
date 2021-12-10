using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Models
{
    class Habitacion
    {
        public int Id { get; set; }
        public int NroHabitacion { get; set; }
        public byte Capacidad { get; set; }
        public int Estado { get; set; }
        public decimal Precio { get; set; }
    }
}
