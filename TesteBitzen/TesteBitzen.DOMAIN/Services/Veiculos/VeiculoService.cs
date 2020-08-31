using System;
using System.Linq;
using TesteBitzen.DOMAIN.Dtos;
using TesteBitzen.DOMAIN.Entities;
using TesteBitzen.DOMAIN.Interfaces;
using TesteBitzen.DOMAIN.Interfaces.Veiculos;

namespace TesteBitzen.DOMAIN.Services.Veiculos
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _repository;

        public VeiculoService(IVeiculoRepository repository)
        {
            _repository = repository;
        }

        public IRetorno Alterar(Guid id, VeiculoDTO dto)
        {
            throw new NotImplementedException();
        }

        public IRetorno AlterarVeiculo(Guid id, AlterarVeiculoDTO dto)
        {
            dto.Validate();

            if (dto.Invalid)
            {
                return new RetornoDTO(false, "Erro na Requisição, verificar valores enviados", dto.Notifications);
            }

            var veiculo = _repository.BuscarPorId(id);

            if (veiculo == null)
            {
                return new RetornoDTO(false, "Veiculo não encontrado", null);
            }

            veiculo.AlterarPlaca(dto.Placa);

            if (!_repository.Alterar(veiculo))
            {
                return new RetornoDTO(false, "Erro ao tentar alterar o usuario", null);
            }

            return new RetornoDTO(true, "Veiculo alterado com sucesso", veiculo);
        }

        public IRetorno BuscarPorId(Guid id)
        {
            var veiculo = _repository.BuscarPorId(id);

            if (veiculo == null)
            {
                return new RetornoDTO(false, "Nenhum veiculo encontrado", null);
            }

            return new RetornoDTO(true, "", veiculo);
        }

        public IRetorno BuscarTodos()
        {
            var veiculos = _repository.BuscarTodos();

            if (veiculos.ToList().Count > 0)
            {
                return new RetornoDTO(true, "", veiculos);
            }

            return new RetornoDTO(false, "Nenhum veiculo encontrado", null);
        }

        public IRetorno BuscarVeiculosPorUsuario(Guid UsuarioId)
        {
            var veiculos = _repository.BuscarVeiculosPorUsuario(UsuarioId);

            if (veiculos.ToList().Count > 0)
            {
                return new RetornoDTO(true, "", veiculos);
            }

            return new RetornoDTO(false, "Nenhum veiculo encontrado para o usuario informado", null);
        }

        public IRetorno Criar(VeiculoDTO dto)
        {
            dto.Validate();

            if (dto.Invalid)
            {
                return new RetornoDTO(false, "Erro na Requisição, verificar valores enviado", dto.Notifications);
            }

            var veiculo = new Veiculo(dto.Marca, dto.Modelo, dto.Ano, dto.Placa, dto.TipoVeiculo, dto.TipoCombustivel, dto.Quilometragem, dto.UsuarioId);

            if (!_repository.Criar(veiculo))
            {
                return new RetornoDTO(false, "Erro ao tentar cadastrar veiculo", null);
            }

            return new RetornoDTO(true, "Veiculo cadastrado com sucesso", veiculo);
        }

        public IRetorno Excluir(Guid id)
        {
            var veiculo = _repository.BuscarPorId(id);

            if (veiculo == null)
            {
                return new RetornoDTO(false, "Veiculo não encontrado", null);
            }

            if (!_repository.Excluir(veiculo))
            {
                return new RetornoDTO(false, "Erro tentar excluir veiculo", null);
            }

            return new RetornoDTO(true, "Veiculo removido com sucesso", null);
        }

        public IRetorno IncluirFotoVeiculo(Guid id, string foto)
        {
            var veiculo = _repository.BuscarPorId(id);
            
            if(veiculo == null)
            {
                return new RetornoDTO(false, "Veiculo não encontrado", null);
            }

            if (!string.IsNullOrEmpty(foto))
            {
                veiculo.AlterarFoto(foto);
            }

            if (!_repository.Alterar(veiculo))
            {
                return new RetornoDTO(false, "Erro ao tentar incluir foto para o veiculo", null);
            }

            return new RetornoDTO(true, "Foto incluida com sucesso", veiculo);
        }
    }
}
