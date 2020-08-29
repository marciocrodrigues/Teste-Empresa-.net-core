using System;
using System.Collections.Generic;
using System.Text;
using TesteBitzen.API.Dtos;

namespace TesteBitzen.DOMAIN.Interfaces.Veiculos
{
    public interface IVeiculoService : IService<VeiculoDTO>
    {
        IRetorno BuscarVeiculosPorUsuario(Guid UsuarioId);
    }
}
