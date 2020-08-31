using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TesteBitzen.DOMAIN.Entities;
using TesteBitzen.DOMAIN.Interfaces.Abastecimentos;
using TesteBitzen.INFRA.Context;

namespace TesteBitzen.INFRA.Repositories.Abastecimentos
{
    public class AbastecimentoRepository : IAbastecimentoRepository
    {
        private readonly DataContext _context;
        public AbastecimentoRepository(DataContext context)
        {
            _context = context;
        }
        public bool Alterar(Abastecimento entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public Abastecimento BuscarPorId(Guid id)
        {
            return _context.Abastecimentos
                .Include(x => x.Veiculo)
                .Include(x => x.Usuario)
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Abastecimento> BuscarTodos()
        {
            return _context.Abastecimentos
                .Include(x => x.Veiculo)
                .Include(x => x.Usuario)
                .AsNoTracking()
                .OrderBy(x => x.Usuario.Nome);
        }

        public bool Criar(Abastecimento entity)
        {
            _context.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public bool Excluir(Abastecimento entity)
        {
            _context.Remove(entity);
            return _context.SaveChanges() > 0;
        }
    }
}
