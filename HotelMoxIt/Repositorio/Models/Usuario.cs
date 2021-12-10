using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(255)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(8)]
        public string Dni { get; set; }

        [Required]
        public bool TipoUsuario { get; set; }

        public int IdHabitacion { get; set; }
        public Habitacion Habitacion { get; set; }



    }
}
