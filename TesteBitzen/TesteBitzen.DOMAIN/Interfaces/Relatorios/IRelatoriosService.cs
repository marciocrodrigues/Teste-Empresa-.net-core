using System;
using System.Collections.Generic;
using System.Text;

namespace TesteBitzen.DOMAIN.Interfaces.Relatorios
{
    public interface IRelatoriosService
    {
        IRetorno LitrosAbastecidosMensal();
        IRetorno PagamentoMensalAbastecimentoAnual();
        IRetorno QuilometrosRodadosMensalmenteAnual();
        IRetorno MediaMensalPorCarro(Guid VeiculoId);
    }
}
