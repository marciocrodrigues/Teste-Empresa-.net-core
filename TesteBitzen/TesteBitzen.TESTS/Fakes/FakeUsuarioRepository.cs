using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteBitzen.DOMAIN.Entities;
using TesteBitzen.DOMAIN.Interfaces.Usuarios;

namespace TesteBitzen.TESTS.Fakes
{
    public class FakeUsuarioRepository : IUsuarioRepository
    {
        private List<Usuario> usuarios;

        public FakeUsuarioRepository()
        {
            usuarios = new List<Usuario>();
        }
        public bool Alterar(Usuario entity)
        {
            int index = usuarios.FindIndex(x => x.Id == entity.Id);
            
            usuarios[index] = entity;
            
            return true;
        }

        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            return usuarios.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();
        }

        public Usuario BuscarPorId(Guid id)
        {
            return usuarios.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Usuario> BuscarTodos()
        {
            return usuarios;
        }

        public bool Criar(Usuario entity)
        {
            int count = usuarios.Count;
            usuarios.Add(entity);

            return usuarios.Count > count;
        }

        public bool Excluir(Usuario entity)
        {
            int count = usuarios.Count;
            usuarios.Remove(entity);

            return usuarios.Count < count;
        }
    }
}
