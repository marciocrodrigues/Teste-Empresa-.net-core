using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using TesteBitzen.DOMAIN.Dtos;
using TesteBitzen.DOMAIN.Interfaces;
using TesteBitzen.DOMAIN.Interfaces.Abastecimentos;
using TesteBitzen.DOMAIN.Interfaces.Relatorios;

namespace TesteBitzen.DOMAIN.Services.Relatorios
{
    public class RelatorioService : IRelatoriosService
    {
        private readonly IAbastecimentoRepository _repository;

        public RelatorioService(IAbastecimentoRepository repository)
        {
            _repository = repository;
        }

        public IRetorno LitrosAbastecidosMensal()
        {
            var abastecimentos = _repository.BuscarTodos();

            var retorno = abastecimentos.Where(x => CompararDatas(x.DiaAbastecimento, x.MesAbastecimento, x.AnoAbastecimento) <= 12).GroupBy(x => new { x.MesAbastecimento }).Select(m => new
            {
                Mes = Mes(m.Key.MesAbastecimento),
                valor = m.Sum(x => x.LitrosAbastecidos)
            }).ToList();

            return new RetornoDTO(true, "", retorno);
        }

        public IRetorno MediaMensalPorCarro(Guid VeiculoId)
        {
            var abastecimentos = _repository.BuscarTodos().Where(x => x.VeiculoId == VeiculoId).ToList();
            var retorno = abastecimentos.GroupBy(x => new { x.MesAbastecimento, x.VeiculoId }).Select(x => new
            {
                Mes = Mes(x.Key.MesAbastecimento),
                Media = x.Sum(v => v.QuilometrosRodados) / x.Sum(v => v.LitrosAbastecidos)
            }).ToList();

            return new RetornoDTO(true, "", retorno);
        }

        public IRetorno PagamentoMensalAbastecimentoAnual()
        {
            var abastecimentos = _repository.BuscarTodos();

            var retorno = abastecimentos.Where(x => CompararDatas(x.DiaAbastecimento, x.MesAbastecimento, x.AnoAbastecimento) <= 12).GroupBy(x => new { x.MesAbastecimento }).Select(m => new
            {
                Mes = Mes(m.Key.MesAbastecimento),
                valor = m.Sum(x => x.ValorAbastecimento)
            }).ToList();

            return new RetornoDTO(true, "", retorno);
        }

        public IRetorno QuilometrosRodadosMensalmenteAnual()
        {
            var abastecimentos = _repository.BuscarTodos();
            var retorno = abastecimentos.GroupBy(x => new { x.MesAbastecimento, x.VeiculoId }).Select(x => new
            {
                Mes = Mes(x.Key.MesAbastecimento),
                Media = x.Sum(v => v.QuilometrosRodados)
            }).ToList();

            return new RetornoDTO(true, "", retorno);
        }

        private string Mes(int mes)
        {
            string[] meses = new string[12] { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
            return meses[mes - 1];
        }

        private double CompararDatas(int dia, int mes, int ano)
        {
            var dataAbastecimento = new DateTime(ano, mes, dia);
            var dataAtual = DateTime.Now;

            var retorno = Math.Truncate(dataAtual.Subtract(dataAbastecimento).Days / (365.25 / 12));

            return retorno;
        }
    }
}
