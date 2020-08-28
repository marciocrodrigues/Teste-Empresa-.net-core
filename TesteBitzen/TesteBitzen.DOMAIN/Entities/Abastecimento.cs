using System;

namespace TesteBitzen.DOMAIN.Entities
{
    public class Abastecimento : BaseEntitie
    {
        public Abastecimento(int kmAbastecimento, 
                             double litrosAbastecidos, 
                             decimal valorAbastecimento, 
                             DateTime dataAbastecimento, 
                             string postoCombustivel, 
                             int usuarioId,  
                             string tipoCombustivel, 
                             int veiculoId)
        {
          KmAbastecimento = kmAbastecimento;
          LitrosAbastecidos = litrosAbastecidos;
          ValorAbastecimento = valorAbastecimento;
          DataAbastecimento = dataAbastecimento;
          PostoCombustivel = postoCombustivel;
          UsuarioId = usuarioId;
          TipoCombustivel = tipoCombustivel;
          VeiculoId = veiculoId;
        }
    
        public int KmAbastecimento { get; private set; }
        public double LitrosAbastecidos { get; private set; }
        public decimal ValorAbastecimento { get; private set; }
        public DateTime DataAbastecimento { get; private set; }
        public string PostoCombustivel { get; private set; }
        public int UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }
        public string TipoCombustivel { get; private set; }
        public int VeiculoId { get; private set; }
        public Veiculo Veiculo { get; private set; }

        public void AlterarKmAbastecimetno(int kmabastecimento)
        {
          KmAbastecimento = kmabastecimento;
        }

        public void AlterarLitrosAbastecimento(double litros)
        {
          LitrosAbastecidos = litros;
        }

        public void AlterarValorAbastecimento(decimal valor)
        {
          ValorAbastecimento = valor;
        }

        public void AlterarDataAbastecimento(DateTime data)
        {
          DataAbastecimento = data;
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