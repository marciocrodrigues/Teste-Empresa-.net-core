using System;
using System.Collections.Generic;
using System.Text;
using TesteBitzen.DOMAIN.Entities;

namespace TesteBitzen.DOMAIN.Interfaces.Usuarios
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario BuscarPorEmailSenha(string email, string senha);
    }
}
