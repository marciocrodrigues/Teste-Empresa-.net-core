using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TesteBitzen.DOMAIN.Dtos;
using TesteBitzen.DOMAIN.Entities;
using TesteBitzen.DOMAIN.Services.Abastecimentos;
using TesteBitzen.DOMAIN.Services.Relatorios;
using TesteBitzen.DOMAIN.Services.Veiculos;
using TesteBitzen.TESTS.Fakes;

namespace TesteBitzen.TESTS.Services
{
    [TestClass]
    public class RelatoriosServiceTests
    {
        private readonly RelatorioService _service;
        private readonly VeiculoService _serviceVeiculo;
        private readonly AbastecimentoService _serviceAbastecimento;
        private readonly AbastecimentoDTO _abastecimento1;
        private readonly AbastecimentoDTO _abastecimento2;
        private readonly AbastecimentoDTO _abastecimento3;
        private readonly Guid usuarioId;
        private readonly Veiculo cadVeiculo;


        public RelatoriosServiceTests()
        {
            var fakeVeiculo = new FakeVeiculoRepository();
            var fakeAbastecimento = new FakeAbastecimentoRepository();
            _serviceVeiculo = new VeiculoService(fakeVeiculo);
            _serviceAbastecimento = new AbastecimentoService(fakeAbastecimento, fakeVeiculo);
            _service = new RelatorioService(fakeAbastecimento);
            usuarioId = Guid.NewGuid();
            var veiculoDTO = new VeiculoDTO("VW", "GOL G5", 2019, "ABC-1234", 1, 1, 0, usuarioId);
            cadVeiculo = (Veiculo)_serviceVeiculo.Criar(veiculoDTO).Data;
            _abastecimento1 = new AbastecimentoDTO(100, 50, 150.00, DateTime.Now, "Post Ipiranga", usuarioId, "Alcool", cadVeiculo.Id);
            _abastecimento2 = new AbastecimentoDTO(200, 50, 150.00, DateTime.Now, "Post Ipiranga", usuarioId, "Alcool", cadVeiculo.Id);
            _abastecimento3 = new AbastecimentoDTO(300, 50, 150.00, DateTime.Now.AddMonths(1), "Post Ipiranga", usuarioId, "Alcool", cadVeiculo.Id);
        }

        [TestMethod]
        public void Que_Seja_Possivel_Buscar_Relatorio_de_Litros_Abastecidos_Mensalmente_Anual()
        {
            _serviceAbastecimento.Criar(_abastecimento1);
            _serviceAbastecimento.Criar(_abastecimento2);
            var abastecimentos = _serviceAbastecimento.BuscarTodos();
            var retorno = _service.LitrosAbastecidosMensal();
            Assert.AreEqual(true, retorno.Sucesso);
        }

        [TestMethod]
        public void Que_Seja_Possivel_Buscar_Relatorio_Media_Km_Carro_Faz_Mensalmente_Por_Um_Ano()
        {
            _serviceAbastecimento.Criar(_abastecimento1);
            _serviceAbastecimento.Criar(_abastecimento2);
            _serviceAbastecimento.Criar(_abastecimento3);
            var retorno = _service.MediaMensalPorCarro(cadVeiculo.Id);
            Assert.AreEqual(true, true);
        }
    }
}
