using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio.ViewModel;

namespace Repositorio
{
    public interface IUsuarioRepositorio
    {
        void Create(RegistroViewModel usuario);
    }
}
