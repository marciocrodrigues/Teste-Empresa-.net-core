using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TesteBitzen.API.Config;
using TesteBitzen.DOMAIN.Dtos;
using TesteBitzen.DOMAIN.Interfaces;
using TesteBitzen.DOMAIN.Interfaces.Veiculos;

namespace TesteBitzen.API.Controllers
{
    [ApiController]
    [Route("v1/veiculo")]
    [Authorize]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _service;
        public VeiculoController(IVeiculoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Cadastro de veiculo
        /// </summary>
        /// <param name="dto"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Não Autorizado</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] VeiculoDTO dto)
        {
            var retorno = _service.Criar(dto);
                
            if (retorno.Sucesso)
            {
                return Ok(new { retorno.Mensagem, retorno.Data });
            }

            return BadRequest(new { retorno.Mensagem, retorno.Data });
        }

        /// <summary>
        /// Listar todos os veiculos
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
        /// Buscar veiculo pelo identificador
        /// <param name="id"></param>
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
        /// Alterar dados do veiculo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Não Autorizado</response>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [Route("Alterar/{id:Guid}")]
        [HttpPut]
        public IActionResult Alterar(Guid id, [FromBody] AlterarVeiculoDTO dto)
        {
            var retorno = _service.AlterarVeiculo(id, dto);

            if (retorno.Sucesso)
            {
                return Ok(new { retorno.Mensagem, retorno.Data });
            }

            return BadRequest(new { retorno.Mensagem, retorno.Data });
        }

        /// <summary>
        /// Excluir veiculo
        /// </summary>
        /// <param name="id"></param>
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

        /// <summary>
        /// Incluir foto para um veiculo
        /// </summary>
        /// <param name="idVeiculo"></param>
        /// <param name="arquivo"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Não Autorizado</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [Route("IncluirFoto/{idVeiculo:Guid}")]
        [HttpPost]
        public IActionResult IncluirFoto(Guid idVeiculo, IFormFile arquivo)
        {
            UploadFotoFile.SalvarFoto(arquivo);

            if (!string.IsNullOrEmpty(UploadFotoFile.Erro))
            {
                return BadRequest(new { Mensagem = UploadFotoFile.Erro });
            }

            var retorno = _service.IncluirFotoVeiculo(idVeiculo, UploadFotoFile.Foto);

            if (retorno.Sucesso)
            {
                return Ok(new { retorno.Mensagem });
            }

            return BadRequest(new { retorno.Mensagem });
        }
    }
}
