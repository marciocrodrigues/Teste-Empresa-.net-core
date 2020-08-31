using System;

namespace TesteBitzen.DOMAIN.Entities
{
    public class Abastecimento : BaseEntitie
    {
        public Abastecimento(int kmAbastecimento, 
                             int quilometrosRodados,
                             double litrosAbastecidos, 
                             double valorAbastecimento, 
                             int diaAbastecimento,
                             int mesAbastecimento,
                             int anoAbastecimento,
                             string postoCombustivel, 
                             Guid usuarioId,  
                             string tipoCombustivel, 
                             Guid veiculoId)
        {
          KmAbastecimento = kmAbastecimento;
          QuilometrosRodados = quilometrosRodados;
          LitrosAbastecidos = litrosAbastecidos;
          ValorAbastecimento = valorAbastecimento;
            DiaAbastecimento = diaAbastecimento;
            MesAbastecimento = mesAbastecimento;
          AnoAbastecimento = anoAbastecimento;
          PostoCombustivel = postoCombustivel;
          UsuarioId = usuarioId;
          TipoCombustivel = tipoCombustivel;
          VeiculoId = veiculoId;
        }
    
        public int KmAbastecimento { get; private set; }
        public int QuilometrosRodados { get; set; }
        public double LitrosAbastecidos { get; private set; }
        public double ValorAbastecimento { get; private set; }
        public int DiaAbastecimento { get; private set; }
        public int MesAbastecimento { get; private set; }
        public int AnoAbastecimento { get; set; }
        public string PostoCombustivel { get; private set; }
        public Guid UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }
        public string TipoCombustivel { get; private set; }
        public Guid VeiculoId { get; private set; }
        public Veiculo Veiculo { get; private set; }

        public void AlterarDataAbastecimento(DateTime data)
        {
            DiaAbastecimento = data.Day;
            MesAbastecimento = data.Month;
            AnoAbastecimento = data.Year;
        }

        public void AlterarPostoCombustivel(string posto)
        {
          PostoCombustivel = posto;
        }

        public void AlterarTipoCombustivel(string tipo)
        {
          TipoCombustivel = tipo;
        }
    }
}