using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TesteBitzen.DOMAIN.Entities;
using TesteBitzen.DOMAIN.Interfaces.Usuarios;
using TesteBitzen.INFRA.Context;

namespace TesteBitzen.INFRA.Repositories.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _context;

        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public bool Alterar(Usuario entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            return _context.Usuarios
                .FirstOrDefault(x => x.Email == email && x.Senha == senha);
        }

        public Usuario BuscarPorId(Guid id)
        {
            return _context.Usuarios
                .Include(x => x.Veiculos)
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Usuario> BuscarTodos()
        {
            return _context.Usuarios
                .Include(x => x.Veiculos)
                .AsNoTracking()
                .OrderByDescending(x => x.Nome);
        }

        public bool Criar(Usuario entity)
        {
            _context.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public bool Excluir(Usuario entity)
        {
            _context.Remove(entity);
            return _context.SaveChanges() > 0;
        }
    }
}
