using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.ViewModel
{
    public class RegistroViewModel
    {
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
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Contraseña { get; set; }
    }
}
