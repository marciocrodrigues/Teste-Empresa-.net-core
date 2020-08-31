using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteBitzen.API.Config;
using TesteBitzen.DOMAIN.Dtos;
using TesteBitzen.DOMAIN.Entities;
using TesteBitzen.DOMAIN.Interfaces;

namespace TesteBitzen.API.Controllers
{
    [ApiController]
    [Route("v1/login")]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public LoginController(IUsuarioService service)
        {
            _service = service;
        }

        [Route("GerarToken")]
        [HttpPost]
        public IActionResult Index([FromBody] LoginDTO dto)
        {
            var retorno = _service.BuscarPorEmailSenha(dto);

            if (retorno.Sucesso)
            {
                var usuario = (Usuario)retorno.Data;
                var token = Token.GerarToken(usuario);

                return Ok(new { usuario.Id, usuario.Nome, token });
            }

            return BadRequest(new { retorno.Mensagem, retorno.Data });
        }
    }
}
