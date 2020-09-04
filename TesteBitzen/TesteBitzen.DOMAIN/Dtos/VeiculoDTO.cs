using Flunt.Notifications;
using Flunt.Validations;
using System;
using TesteBitzen.DOMAIN.Dtos.Interfaces;

namespace TesteBitzen.DOMAIN.Dtos
{
  public class VeiculoDTO : Notifiable, IBaseDTO
  {
    public VeiculoDTO(){}

    public VeiculoDTO(string marca, 
                      string modelo, 
                      int ano, 
                      string placa, 
                      int tipoVeiculoId, 
                      int tipoCombustivelId, 
                      int quilometragem, 
                      Guid usuarioId)
    {
      Marca = marca;
      Modelo = modelo;
      Ano = ano;
      Placa = placa;
      TipoVeiculoId = tipoVeiculoId;
      TipoCombustivelId = tipoCombustivelId;
      Quilometragem = quilometragem;
      UsuarioId = usuarioId;
    }

    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public string Placa { get; set; }
    public int TipoVeiculoId { get; set; }
    public int TipoCombustivelId { get; set; }
    public int Quilometragem { get; set; }
    public Guid UsuarioId { get; set; }
    public string Foto { get; set; }
    public void Validate()
    {
      AddNotifications(
          new Contract()
            .Requires()
            .IsNotNullOrEmpty(Marca, "Marca", "Marca é obrigatoria")
            .IsNotNullOrEmpty(Modelo, "Modelo", "Modelo é obrigatorio")
            .IsGreaterThan(Ano, 1900, "Ano", "Ano deve ser um valor valido")
            .IsNotNullOrEmpty(Placa, "Placa", "Placa é obrigatoria")
            .IsGreaterThan(TipoVeiculoId, 0, "TipoVeiculo", "TipoVeiculo é obrigatorio")
            .IsGreaterThan(TipoCombustivelId, 0, "TipoCombustivel", "TipoCombustivel é obrigatorio")
            .IsNotNullOrEmpty(UsuarioId.ToString(), "UsuarioId", "UsuarioId é obrigatorio")
      );
    }
  }
}