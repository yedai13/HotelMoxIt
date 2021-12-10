using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Debe Ingresar email")]
        [StringLength(255)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe ingresar Contraseña")]
        [StringLength(255)]
        public string Contraseña { get; set; }
    }
}
