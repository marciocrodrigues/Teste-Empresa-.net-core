using System;
using System.Collections.Generic;
using System.Text;
using TesteBitzen.DOMAIN.Entities;

namespace TesteBitzen.DOMAIN.Interfaces.Veiculos
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {
        IEnumerable<Veiculo> BuscarVeiculosPorUsuario(Guid UsuarioId);
    }
}
