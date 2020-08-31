using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteBitzen.DOMAIN.Interfaces;
using TesteBitzen.DOMAIN.Interfaces.Relatorios;

namespace TesteBitzen.API.Controllers
{
    [ApiController]
    [Route("v1/relatorios")]
    [Authorize]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatoriosService _service;
        public RelatorioController(IRelatoriosService service)
        {
            _service = service;
        }

        /// <summary>
        /// Quantidade mensal de litros abastecidos no periodo de um ano
        /// </summary>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Não Autorizado</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [Route("AbastecimentoMensal")]
        [HttpGet]
        public IActionResult AbastecimentoMensal()
        {
            var retorno = _service.LitrosAbastecidosMensal();

            if (retorno.Sucesso)
            {
                return Ok(new { retorno.Mensagem, retorno.Data });
            }

            return NotFound(new { retorno.Mensagem });
        }

        /// <summary>
        /// Valor mensal dos abastecimentos pagos no periodo de um ano
        /// </summary>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Não Autorizado</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [Route("PagamentoMensal")]
        [HttpGet]
        public IActionResult PagamentoMensal()
        {
            var retorno = _service.PagamentoMensalAbastecimentoAnual();

            if (retorno.Sucesso)
            {
                return Ok(new { retorno.Mensagem, retorno.Data });
            }

            return NotFound(new { retorno.Mensagem });
        }

        /// <summary>
        /// Quilometros rodados mensalmente no periodo de um ano
        /// </summary>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Não Autorizado</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [Route("QuilometrosRodados")]
        [HttpGet]
        public IActionResult QuilometrosRodados()
        {
            var retorno = _service.QuilometrosRodadosMensalmenteAnual();

            if (retorno.Sucesso)
            {
                return Ok(new { retorno.Mensagem, retorno.Data });
            }

            return NotFound(new { retorno.Mensagem });
        }

        /// <summary>
        /// Media mensal por veiculo(CAlculo de quantos km o carro faz por litro)
        /// </summary>
        /// <param name="idVeiculo"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Não Autorizado</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [Route("MediaMensalVeiculo/{idVeiculo:Guid}")]
        [HttpGet]
        public IActionResult MediaMensalVeiculo(Guid idVeiculo)
        {
            var retorno = _service.MediaMensalPorCarro(idVeiculo);

            if (retorno.Sucesso)
            {
                return Ok(new { retorno.Mensagem, retorno.Data });
            }

            return NotFound(new { retorno.Mensagem });
        }

    }
}
