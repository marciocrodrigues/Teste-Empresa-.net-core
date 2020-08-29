using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteBitzen.DOMAIN.Entities;
using TesteBitzen.DOMAIN.Interfaces.Veiculos;

namespace TesteBitzen.TESTS.Fakes
{
    public class FakeVeiculoRepository : IVeiculoRepository
    {
        private readonly List<Veiculo> veiculos;

        public FakeVeiculoRepository()
        {
            veiculos = new List<Veiculo>();
        }
        public bool Alterar(Veiculo entity)
        {
            int index = veiculos.FindIndex(x => x.Id == entity.Id);

            veiculos[index] = entity;

            return true;
        }

        public Veiculo BuscarPorId(Guid id)
        {
            return veiculos.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Veiculo> BuscarTodos()
        {
            return veiculos;
        }

        public IEnumerable<Veiculo> BuscarVeiculosPorUsuario(Guid UsuarioId)
        {
            return veiculos.Where(x => x.UsuarioId == UsuarioId);
        }

        public bool Criar(Veiculo entity)
        {
            int count = veiculos.Count;
            veiculos.Add(entity);

            return veiculos.Count > count;
        }

        public bool Excluir(Veiculo entity)
        {
            int count = veiculos.Count;
            veiculos.Remove(entity);

            return veiculos.Count < count;
        }
    }
}
