using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TesteBitzen.DOMAIN.Dtos;
using TesteBitzen.DOMAIN.Entities;
using TesteBitzen.DOMAIN.Services.Usuarios;
using TesteBitzen.TESTS.Fakes;

namespace TesteBitzen.TESTS.Services
{
    [TestClass]
    public class UsuarioServicesTests
    {
        private readonly UsuarioService _service;
        private UsuarioDTO _dtoBase;
        private LoginDTO _dtoLogin;

        public UsuarioServicesTests()
        {
            _service = new UsuarioService(new FakeUsuarioRepository());
            _dtoBase = new UsuarioDTO("email@email.com.br", "123456", "teste da silva souza");
            _dtoLogin = new LoginDTO("email@email.com.br", "123456");
        }

        [TestMethod]
        public void Que_Seja_Possivel_Criar_Usuario()
        {
            var retorno = _service.Criar(_dtoBase);
            Assert.AreEqual(true, retorno.Sucesso);
        }

        [TestMethod]
        public void Que_Seja_Possivel_Buscar_Usuario_Por_Id()
        {
            var retorno = _service.Criar(_dtoBase);
            var id = ((Usuario)retorno.Data).Id;
            var usuario = _service.BuscarPorId(id);
            Assert.AreEqual(true, usuario.Sucesso);
        }

        [TestMethod]
        public void Que_Seja_Possivel_Buscar_Usuario_Por_Email_Senha()
        {
            var retorno = _service.Criar(_dtoBase);
            var usuario = _service.BuscarPorEmailSenha(_dtoLogin);
            Assert.AreEqual(true, usuario.Sucesso);
        }

        [TestMethod]
        public void Que_Seja_Possivel_Excluir_Usuario()
        {
            var retorno = _service.Criar(_dtoBase);
            var id = ((Usuario)retorno.Data).Id;
            Assert.AreEqual(true, _service.Excluir(id).Sucesso);
        }

        [TestMethod]
        public void Que_Seja_Possivel_Alterar_Usuario()
        {
            var retorno = _service.Criar(_dtoBase);
            var usuario = (Usuario)retorno.Data;
            var id = usuario.Id;
            var nome = usuario.Nome;
            var usuarioAlterado = new UsuarioDTO(usuario.Email, usuario.Senha, "Teste Alterado");
            _service.Alterar(id, usuarioAlterado);
            Assert.AreEqual(true, (usuario.Nome != nome && usuario.Id == id));
        }
    }
}
