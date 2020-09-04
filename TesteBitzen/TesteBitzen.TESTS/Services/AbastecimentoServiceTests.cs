using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TesteBitzen.DOMAIN.Dtos;
using TesteBitzen.DOMAIN.Entities;
using TesteBitzen.DOMAIN.Services.Abastecimentos;
using TesteBitzen.DOMAIN.Services.Veiculos;
using TesteBitzen.TESTS.Fakes;

namespace TesteBitzen.TESTS.Services
{
    [TestClass]
    public class AbastecimentoServiceTests
    {
        private readonly AbastecimentoService _service;
        private readonly VeiculoService _serviceVeiculo;
        private AbastecimentoDTO _dtoBase;
        private readonly Guid usuarioId;
        private readonly Veiculo cadVeiculo;

        public AbastecimentoServiceTests()
        {
            var fakeVeiculoRepository = new FakeVeiculoRepository();
            _service = new AbastecimentoService(new FakeAbastecimentoRepository(), fakeVeiculoRepository);
            _serviceVeiculo = new VeiculoService(fakeVeiculoRepository);
            usuarioId = Guid.NewGuid();
            var veiculoDTO = new VeiculoDTO("VW", "GOL G5", 2019, "ABC-1234", 1, 1, 0, usuarioId);
            cadVeiculo = (Veiculo)_serviceVeiculo.Criar(veiculoDTO).Data;
            _dtoBase = new AbastecimentoDTO(1001, 10.50, 60.00, DateTime.Now, "Posto Ipiranga", usuarioId, "Gasolina", cadVeiculo.Id);
        }

        [TestMethod]
        public void Que_Seja_Possivel_Cadastrar_Abastecimento()
        {
            var retorno = _service.Criar(_dtoBase);
            Assert.AreEqual(true, retorno.Sucesso);
        }

        [TestMethod]
        public void Que_Seja_Possivel_Buscar_Abastecimento_Por_Id()
        {
            var id = ((Abastecimento)_service.Criar(_dtoBase).Data).Id;
            var retorno = _service.BuscarPorId(id);
            Assert.AreEqual(true, retorno.Sucesso);
        }

        [TestMethod]
        public void Que_Seja_Possivel_Excluir_Abastecimento()
        {
            var id = ((Abastecimento)_service.Criar(_dtoBase).Data).Id;
            var retorno = _service.Excluir(id);
            Assert.AreEqual(true, retorno.Sucesso);
        }

        [TestMethod]
        public void Que_Seja_Possivel_Alterar_Abastecimento()
        {
            var retorno = _service.Criar(_dtoBase);
            var abastecimento = (Abastecimento)retorno.Data;
            var id = abastecimento.Id;
            var kmAbastecimento = abastecimento.KmAbastecimento;
            var diaAbastecimento = abastecimento.DiaAbastecimento;
            var abastecimentoAlterado = new AbastecimentoDTO(1002, abastecimento.LitrosAbastecidos, abastecimento.ValorAbastecimento, DateTime.Now.AddDays(1), abastecimento.PostoCombustivel, usuarioId, abastecimento.TipoCombustivel, cadVeiculo.Id);
            _service.Alterar(id, abastecimentoAlterado);
            Assert.AreEqual(
                true,
                ((abastecimento.KmAbastecimento != kmAbastecimento &&
                  abastecimento.DiaAbastecimento != diaAbastecimento) && abastecimento.Id == id)
            );
        }

    }
}
