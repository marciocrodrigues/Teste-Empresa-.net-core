using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteBitzen.DOMAIN.Dtos;
using TesteBitzen.DOMAIN.Interfaces;
using TesteBitzen.DOMAIN.Interfaces.Abastecimentos;

namespace TesteBitzen.API.Controllers
{
    [ApiController]
    [Route("v1/abastecimento")]
    [Authorize]
    public class AbastecimentoController : ControllerBase
    {
        private readonly IAbastecimentoService _service;
        public AbastecimentoController(IAbastecimentoService service)
        {
            _service = service;
        }
        /// <summary>
        /// Cadastro de abastecimento
        /// </summary>
        /// <param name="dto"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Não Autorizado</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] AbastecimentoDTO dto)
        {
            var retorno = _service.Criar(dto);

            if (retorno.Sucesso)
            {
                return Ok(new { retorno.Mensagem, retorno.Data });
            }

            return BadRequest(new { retorno.Mensagem, retorno.Data });
        }

        /// <summary>
        /// Listar todos os abastecimentos
        /// </summary>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Não Autorizado</response>
        [ProducesResponseType(typeof(IRetorno), 200)]
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

        /// <summary>
        /// Buscar abastecimento pelo identificador
        /// </summary>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Não Autorizado</response>
        [ProducesResponseType(typeof(IRetorno), 200)]
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
        /// Alterar dados do abastecimento
        /// </summary>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Não Autorizado</response>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [Route("Alterar/{id:Guid}")]
        [HttpPut]
        public IActionResult Alterar(Guid id, [FromBody] AbastecimentoDTO dto)
        {
            var retorno = _service.Alterar(id, dto);

            if (retorno.Sucesso)
            {
                return Ok(new { retorno.Mensagem, retorno.Data });
            }

            return BadRequest(new { retorno.Mensagem, retorno.Data });
        }

        /// <summary>
        /// Excluir abastecimento
        /// </summary>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Não Autorizado</response>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [Route("Excluir/{id:Guid}")]
        [HttpDelete]
        public IActionResult Excluir(Guid id)
        {
            var retorno = _service.Excluir(id);

            if (retorno.Sucesso)
            {
                return Ok(new { retorno.Mensagem });
            }

            return BadRequest(new { retorno.Mensagem });
        }
    }
}
