using Repositorio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio.Models;

namespace Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private HotelDBContext _ctx;

        public UsuarioRepositorio(HotelDBContext ctx)
        {
            _ctx = ctx;
        }
        public void Create(RegistroViewModel usuario)
        {
            Usuario nuevo = new();
            nuevo.Nombre = usuario.Nombre;
            nuevo.Apellido = usuario.Apellido;
            nuevo.Dni = usuario.Dni;
            nuevo.TipoUsuario = 1;
            nuevo.Email = usuario.Email;
            nuevo.Contraseña = usuario.Contraseña;
            _ctx.Usuario.Add(nuevo);
            _ctx.SaveChanges();
        }

        public void Editar(Usuario usuario)
        {
            _ctx.Usuario.Update(usuario);
            _ctx.SaveChanges();
        }

        public Usuario GetById(int? idUsuario)
        {
            return _ctx.Usuario.Where(u => u.Id == idUsuario).FirstOrDefault();
        }

        public Usuario Login(LoginViewModel usuario)
        {
            return _ctx.Usuario.Where(u => u.Email == usuario.Email && u.Contraseña == usuario.Contraseña).FirstOrDefault();
        }
    }
}
