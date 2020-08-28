using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.AspNetCore.Http;
using TesteBitzen.API.Dtos.Interfaces;

namespace TesteBitzen.API.Dtos
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
                      int usuarioId, 
                      IFormFile foto)
    {
      Marca = marca;
      Modelo = modelo;
      Ano = ano;
      Placa = placa;
      TipoVeiculo = tipoVeiculo;
      TipoCombustivel = tipoCombustivel;
      Quilometragem = quilometragem;
      UsuarioId = usuarioId;
      Foto = foto;
    }

    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public string Placa { get; set; }
    public string TipoVeiculo { get; set; }
    public string TipoCombustivel { get; set; }
    public int Quilometragem { get; set; }
    public int UsuarioId { get; set; }
    public IFormFile Foto { get; set; }
    public void Validate()
    {
      AddNotifications(
          new Contract()
            .Requires()
            .IsNullOrEmpty(Marca, "Marca", "Marca é obrigatoria")
            .IsNullOrEmpty(Modelo, "Modelo", "Modelo é obrigatorio")
            .IsGreaterThan(Ano, 1900, "Ano", "Ano deve ser um valor valido")
            .IsNullOrEmpty(Placa, "Placa", "Placa é obrigatoria")
            .IsNullOrEmpty(TipoVeiculo, "TipoVeiculo", "TipoVeiculo é obrigatorio")
            .IsNullOrEmpty(TipoCombustivel, "TipoCombustivel", "TipoCombustivel é obrigatorio")
            .IsGreaterThan(UsuarioId, 0, "UsuarioId", "UsuarioId é obrigatorio")
      );
    }
  }
}