using System;
using TesteBitzen.DOMAIN.Dtos;

namespace TesteBitzen.DOMAIN.Interfaces.Veiculos
{
    public interface IVeiculoService : IService<VeiculoDTO>
    {
        IRetorno BuscarVeiculosPorUsuario(Guid UsuarioId);
        IRetorno AlterarVeiculo(Guid id, AlterarVeiculoDTO dto);
        IRetorno IncluirFotoVeiculo(Guid id, string foto);
    }
}
