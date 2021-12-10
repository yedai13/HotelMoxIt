using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Models
{
    public class Reserva
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public int IdHabitacion { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public DateTime FechaReserva { get; set; }

        public Usuario Usuario { get; set; }
        public Habitacion Habitacion { get; set; }
    }
}
