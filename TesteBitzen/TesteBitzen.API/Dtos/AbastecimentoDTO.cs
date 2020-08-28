using System;
using Flunt.Notifications;
using Flunt.Validations;
using TesteBitzen.API.Dtos.Interfaces;

namespace TesteBitzen.API.Dtos
{
  public class AbastecimentoDTO : Notifiable, IBaseDTO
  {
    public AbastecimentoDTO(){}

    public AbastecimentoDTO(int kmAbastecimento, 
                            double litrosAbastecidos, 
                            decimal valorPago, 
                            DateTime dataAbastecimento, 
                            string postoCombustivel, 
                            int usuarioId, 
                            string tipoCombustivel, 
                            int veiculoId)
    {
      KmAbastecimento = kmAbastecimento;
      LitrosAbastecidos = litrosAbastecidos;
      ValorPago = valorPago;
      DataAbastecimento = dataAbastecimento;
      PostoCombustivel = postoCombustivel;
      UsuarioId = usuarioId;
      TipoCombustivel = tipoCombustivel;
      VeiculoId = veiculoId;
    }

    public int KmAbastecimento { get; set; }
    public double LitrosAbastecidos { get; set; }
    public decimal ValorPago { get; set; }
    public DateTime DataAbastecimento { get; set; }
    public string PostoCombustivel { get; set; }
    public int UsuarioId { get; set; }
    public string TipoCombustivel { get; set; }
    public int VeiculoId { get; set; }
    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .IsGreaterThan(KmAbastecimento, 0, "KmAbastecimento", "KmAbastecimento é obrigatorio")
                .IsGreaterThan(LitrosAbastecidos, 0, "LitrosAbastecidos", "LitrosAbastecidos é obrigatorio")
                .IsGreaterThan(ValorPago, 0, "ValorPago", "ValorPago é obrigatorio")
                .IsNullOrEmpty(DataAbastecimento.ToString(), "DataAbastecimento", "DataAbastecimento é obrigatoria")
                .IsNullOrEmpty(PostoCombustivel, "PostoCombustivel", "PostoCombustivel é obrigatorio")
                .IsGreaterThan(UsuarioId, 0, "UsuarioId", "UsuarioId é obrigatorio")
                .IsNullOrEmpty(TipoCombustivel, "TipoCombustivel", "TipoCombustivel é obrigatorio")
                .IsGreaterThan(VeiculoId, 0, "VeiculoId", "VeiculoId é obrigatorio")
        );
    }
  }
}