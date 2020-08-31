using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteBitzen.DOMAIN.Entities;
using TesteBitzen.DOMAIN.Interfaces.Abastecimentos;

namespace TesteBitzen.TESTS.Fakes
{
    public class FakeAbastecimentoRepository : IAbastecimentoRepository
    {
        private readonly List<Abastecimento> abastecimentos;

        public FakeAbastecimentoRepository()
        {
            abastecimentos = new List<Abastecimento>();
        }
        public bool Alterar(Abastecimento entity)
        {
            int index = abastecimentos.FindIndex(x => x.Id == entity.Id);

            abastecimentos[index] = entity;

            return true;
        }

        public Abastecimento BuscarPorId(Guid id)
        {
            return abastecimentos.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Abastecimento> BuscarTodos()
        {
            return abastecimentos;
        }

        public bool Criar(Abastecimento entity)
        {
            int count = abastecimentos.Count;
            abastecimentos.Add(entity);

            return abastecimentos.Count > count;
        }

        public bool Excluir(Abastecimento entity)
        {
            int count = abastecimentos.Count;
            abastecimentos.Remove(entity);

            return abastecimentos.Count < count;
        }
    }
}
