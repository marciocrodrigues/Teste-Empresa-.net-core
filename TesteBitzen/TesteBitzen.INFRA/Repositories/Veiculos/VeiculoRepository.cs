using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TesteBitzen.DOMAIN.Entities;
using TesteBitzen.DOMAIN.Interfaces.Veiculos;
using TesteBitzen.INFRA.Context;

namespace TesteBitzen.INFRA.Repositories.Veiculos
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly DataContext _context;
        public VeiculoRepository(DataContext context)
        {
            _context = context;
        }
        public bool Alterar(Veiculo entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public Veiculo BuscarPorId(Guid id)
        {
            return _context.Veiculos
                .Include(x => x.Abastecimentos)
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Veiculo> BuscarTodos()
        {
            return _context.Veiculos
                .Include(x => x.Abastecimentos)
                .Include(x => x.Usuario)
                .AsNoTracking()
                .OrderBy(x => x.Ano);
        }

        public IEnumerable<Veiculo> BuscarVeiculosPorUsuario(Guid UsuarioId)
        {
            return _context.Veiculos
                .Include(x => x.Abastecimentos)
                .Include(x => x.Usuario)
                .AsNoTracking()
                .Where(x => x.UsuarioId == UsuarioId);
        }

        public bool Criar(Veiculo entity)
        {
            _context.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public bool Excluir(Veiculo entity)
        {
            _context.Remove(entity);
            return _context.SaveChanges() > 0;
        }
    }
}
