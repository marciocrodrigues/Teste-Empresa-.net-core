using System;
using Flunt.Notifications;
using Flunt.Validations;
using TesteBitzen.DOMAIN.Dtos.Interfaces;

namespace TesteBitzen.DOMAIN.Dtos
{
  public class AbastecimentoDTO : Notifiable, IBaseDTO
  {
    public AbastecimentoDTO(){}

    public AbastecimentoDTO(int kmAbastecimento, 
                            double litrosAbastecidos, 
                            double valorPago, 
                            DateTime dataAbastecimento, 
                            string postoCombustivel, 
                            Guid usuarioId, 
                            string tipoCombustivel, 
                            Guid veiculoId)
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
    public double ValorPago { get; set; }
    public DateTime DataAbastecimento { get; set; }
    public string PostoCombustivel { get; set; }
    public Guid UsuarioId { get; set; }
    public string TipoCombustivel { get; set; }
    public Guid VeiculoId { get; set; }
    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .IsGreaterThan(KmAbastecimento, 0, "KmAbastecimento", "KmAbastecimento é obrigatorio")
                .IsGreaterThan(LitrosAbastecidos, 0, "LitrosAbastecidos", "LitrosAbastecidos é obrigatorio")
                .IsGreaterThan(ValorPago, 0, "ValorPago", "ValorPago é obrigatorio")
                .IsNotNullOrEmpty(DataAbastecimento.ToString(), "DataAbastecimento", "DataAbastecimento é obrigatoria")
                .IsNotNullOrEmpty(PostoCombustivel, "PostoCombustivel", "PostoCombustivel é obrigatorio")
                .IsNotNullOrEmpty(UsuarioId.ToString(), "UsuarioId", "UsuarioId é obrigatorio")
                .IsNotNullOrEmpty(TipoCombustivel, "TipoCombustivel", "TipoCombustivel é obrigatorio")
                .IsNotNullOrEmpty(VeiculoId.ToString(), "VeiculoId", "VeiculoId é obrigatorio")
        );
    }
  }
}