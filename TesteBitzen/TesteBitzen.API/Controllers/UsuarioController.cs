using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteBitzen.DOMAIN.Dtos;
using TesteBitzen.DOMAIN.Interfaces;

namespace TesteBitzen.API.Controllers
{
    [ApiController]
    [Route("v1/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        /// <summary>
        /// Cadastrar novo usuario
        /// </summary>
        /// <param name="input"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [AllowAnonymous]
        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] UsuarioDTO dto)
        {
            var retorno = _service.Criar(dto);

            if (retorno.Sucesso)
            {
                return Ok(new { retorno.Mensagem, retorno.Data });
            }

            return BadRequest(new { retorno.Mensagem, retorno.Data });
        }

        /// <summary>
        /// Buscar usuario pelo identificador
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Requisição não autorizada</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [Authorize]
        [Route("BuscarPorId/{id:Guid}")]
        [HttpGet]
        public IActionResult BuscarPorId(Guid id)
        {
            var retorno = _service.BuscarPorId(id);

            if (retorno.Sucesso)
            {
                return Ok(new { retorno.Mensagem, retorno.Data });
            }

            return BadRequest(new { retorno.Mensagem, retorno.Data });
        }

        /// <summary>
        /// Alterar o dados do usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Requisição não autorizada</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [Authorize]
        [Route("Alterar/{id:Guid}")]
        [HttpPut]
        public IActionResult Alterar(Guid id, [FromBody]UsuarioDTO dto)
        {
            var retorno = _service.Alterar(id, dto);

            if (retorno.Sucesso)
            {
                return Ok(new { retorno.Mensagem, retorno.Data });
            }

            return BadRequest(new { retorno.Mensagem, retorno.Data });
        }

        /// <summary>
        /// Excluir usuario
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Requisição não autorizada</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [Authorize]
        [Route("Excluir/{id:Guid}")]
        [HttpDelete]
        public IActionResult Excluir(Guid id)
        {
            var retorno = _service.Excluir(id);

            if (retorno.Sucesso)
            {
                return Ok( new { retorno.Mensagem });
            }

            return BadRequest(new { retorno.Mensagem });
        }

        /// <summary>
        /// Listar todos os usuarios
        /// </summary>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Requisição não autorizada</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [Authorize]
        [Route("ListarTodos")]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            var retorno = _service.BuscarTodos();

            if (retorno.Sucesso)
            {
                return Ok(new { retorno.Mensagem, retorno.Data });
            }

            return BadRequest(new { retorno.Mensagem, retorno.Data });
        }
    }
}
