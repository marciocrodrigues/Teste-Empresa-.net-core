using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteBitzen.DOMAIN.Dtos;
using TesteBitzen.DOMAIN.Entities;
using TesteBitzen.DOMAIN.Interfaces;
using TesteBitzen.DOMAIN.Interfaces.Abastecimentos;
using TesteBitzen.DOMAIN.Interfaces.Veiculos;

namespace TesteBitzen.DOMAIN.Services.Abastecimentos
{
    public class AbastecimentoService : IAbastecimentoService
    {
        private readonly IAbastecimentoRepository _repository;
        private readonly IVeiculoRepository _veiculoRepository;

        public AbastecimentoService(IAbastecimentoRepository repository,
                                    IVeiculoRepository veiculoRepository)
        {
            _repository = repository;
            _veiculoRepository = veiculoRepository;
        }
        public IRetorno Alterar(Guid id, AbastecimentoDTO dto)
        {
            dto.Validate();

            if (dto.Invalid)
            {
                return new RetornoDTO(false, "Erro na Requisição, verificar valores enviados", dto.Notifications);
            }

            var abastecimento = _repository.BuscarPorId(id);

            if(abastecimento == null)
            {
                return new RetornoDTO(false, "Abastecimento não encontrado para alteração", null);
            }

            abastecimento.AlterarDataAbastecimento(dto.DataAbastecimento);
            abastecimento.AlterarPostoCombustivel(dto.PostoCombustivel);
            abastecimento.AlterarTipoCombustivel(dto.TipoCombustivel);

            if (!_repository.Alterar(abastecimento))
            {
                return new RetornoDTO(false, "Erro ao tentar alterar o abastecimento", null);
            }

            return new RetornoDTO(true, "Abastecimento alterado com sucesso", abastecimento);


        }

        public IRetorno BuscarPorId(Guid id)
        {
            var abastecimento = _repository.BuscarPorId(id);

            if(abastecimento == null)
            {
                return new RetornoDTO(false, "Abastecimento não encontrado", null);
            }

            return new RetornoDTO(true, "", abastecimento);
        }

        public IRetorno BuscarTodos()
        {
            var abastecimentos = _repository.BuscarTodos();

            if(abastecimentos.ToList().Count > 0)
            {
                return new RetornoDTO(true, "", abastecimentos);
            }

            return new RetornoDTO(false, "Nenhum abastecimento cadastrado", null);
        }

        public IRetorno Criar(AbastecimentoDTO dto)
        {
            dto.Validate();

            if (dto.Invalid)
            {
                return new RetornoDTO(false, "Erro na Requisição, verificar valores enviado", dto.Notifications);
            }


            var veiculo = _veiculoRepository.BuscarPorId(dto.VeiculoId);

            if(veiculo == null)
            {
                return new RetornoDTO(false, "O veiculo selecionado não existe na base dedados", null);
            }

            var quilometrosRodados = dto.KmAbastecimento - veiculo.QuilometragemRodada;

            veiculo.AlterarQuilometragemRodada(quilometrosRodados);

            if (!_veiculoRepository.Alterar(veiculo))
            {
                return new RetornoDTO(false, "Erro ao tentar atualizar Quilometros rodados do veiculo", null);
            }

            var abastecimento = new Abastecimento(dto.KmAbastecimento, quilometrosRodados, dto.LitrosAbastecidos, dto.ValorPago, dto.DataAbastecimento.Day, dto.DataAbastecimento.Month, dto.DataAbastecimento.Year, dto.PostoCombustivel, dto.UsuarioId, dto.TipoCombustivel, dto.VeiculoId);

            if (!_repository.Criar(abastecimento))
            {
                return new RetornoDTO(false, "Erro ao tentar cadastrar Abastecimento", null);
            }

            return new RetornoDTO(true, "Abastecimento cadastrado com sucesso", abastecimento);
        }

        public IRetorno Excluir(Guid id)
        {
            var abastecimento = _repository.BuscarPorId(id);

            if(abastecimento == null)
            {
                return new RetornoDTO(false, "Nenhum abastecimento encontrado", null);
            }

            if (!_repository.Excluir(abastecimento))
            {
                return new RetornoDTO(false, "Erro ao tentar excluir abastecimento", null);
            }

            return new RetornoDTO(true, "Abastecimento excluido com sucesso", null);
        }
    }
}
