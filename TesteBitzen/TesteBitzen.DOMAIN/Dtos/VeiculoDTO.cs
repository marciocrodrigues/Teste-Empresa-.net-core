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
                      string tipoVeiculo, 
                      string tipoCombustivel, 
                      int quilometragem, 
                      Guid usuarioId)
    {
      Marca = marca;
      Modelo = modelo;
      Ano = ano;
      Placa = placa;
      TipoVeiculo = tipoVeiculo;
      TipoCombustivel = tipoCombustivel;
      Quilometragem = quilometragem;
      UsuarioId = usuarioId;
    }

    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public string Placa { get; set; }
    public string TipoVeiculo { get; set; }
    public string TipoCombustivel { get; set; }
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
            .IsNotNullOrEmpty(TipoVeiculo, "TipoVeiculo", "TipoVeiculo é obrigatorio")
            .IsNotNullOrEmpty(TipoCombustivel, "TipoCombustivel", "TipoCombustivel é obrigatorio")
            .IsNotNullOrEmpty(UsuarioId.ToString(), "UsuarioId", "UsuarioId é obrigatorio")
      );
    }
  }
}