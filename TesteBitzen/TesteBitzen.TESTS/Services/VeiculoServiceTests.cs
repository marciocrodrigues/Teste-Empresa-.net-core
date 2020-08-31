using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TesteBitzen.API.Dtos;
using TesteBitzen.DOMAIN.Entities;
using TesteBitzen.DOMAIN.Services.Veiculos;
using TesteBitzen.TESTS.Fakes;

namespace TesteBitzen.TESTS.Services
{
    [TestClass]
    public class VeiculoServiceTests
    {
        private readonly VeiculoService _service;
        private VeiculoDTO _dtoBase;
        private Guid _usuarioId;

        public VeiculoServiceTests()
        {
            _service = new VeiculoService(new FakeVeiculoRepository());
            _usuarioId = Guid.NewGuid();
            _dtoBase = new VeiculoDTO("VW", "Gol G5", 2019, "ABC-1234", "Carro", "Alcool/Gasolina", 0, _usuarioId, "foto.jpg");
        }

        [TestMethod]
        public void Que_Seja_Possivel_Cadastrar_Veiculo()
        {
            var retorno = _service.Criar(_dtoBase);
            Assert.AreEqual(true, retorno.Sucesso);
        }

        [TestMethod]
        public void Que_Seja_Possivel_Buscar_Veiculo_Por_Id()
        {
            var id = ((Veiculo)_service.Criar(_dtoBase).Data).Id;
            var retorno = _service.BuscarPorId(id);
            Assert.AreEqual(true, retorno.Sucesso);
        }

        [TestMethod]
        public void Que_Seja_Possivel_Buscar_Veiculos_Por_Usuario()
        {
            _service.Criar(_dtoBase);
            var retorno = _service.BuscarVeiculosPorUsuario(_usuarioId);
            Assert.AreEqual(true, retorno.Sucesso);
        }

        [TestMethod]
        public void Que_Seja_Possivel_Excluir_Veiculo()
        {
            var id = ((Veiculo)_service.Criar(_dtoBase).Data).Id;
            var retorno = _service.Excluir(id);
            Assert.AreEqual(true, retorno.Sucesso);
        }

        [TestMethod]
        public void Que_Seja_Possivel_Alterar_Veiculo()
        {
            var retorno = _service.Criar(_dtoBase);
            var veiculo = (Veiculo)retorno.Data;
            var id = veiculo.Id;
            var foto = veiculo.Foto;
            var placa = veiculo.Placa;
            var veiculoAlterado = new VeiculoDTO(veiculo.Marca, veiculo.Modelo, veiculo.Ano, "DEF-1234", veiculo.Tipo, veiculo.Combustivel, 1000, _usuarioId, "foto2.png");
            _service.Alterar(id, veiculoAlterado);
            Assert.AreEqual(
                true, 
                ((veiculo.Foto != foto &&
                  veiculo.Placa != placa) && veiculo.Id == id)
            );
        }
    }
}
