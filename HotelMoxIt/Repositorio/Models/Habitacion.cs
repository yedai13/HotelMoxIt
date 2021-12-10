using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Models
{
    public class Habitacion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int NroHabitacion { get; set; }

        [Required]
        public byte Capacidad { get; set; }

        [Required]
        public int Estado { get; set; }

        [Required]
        public decimal Precio { get; set; }
    }
}
