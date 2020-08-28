using Flunt.Notifications;
using Flunt.Validations;
using TesteBitzen.API.Dtos.Interfaces;

namespace TesteBitzen.API.Dtos
{
  public class UsuarioDTO : Notifiable ,IBaseDTO
  {
    public UsuarioDTO(){}

    public UsuarioDTO(string email, string senha, string nome)
    {
      Email = email;
      Senha = senha;
      Nome = nome;
    }

    public string Email { get; set; }
    public string Senha { get; set; }
    public string Nome { get; set; } 
    
    public void Validate()
    {
      AddNotifications(
          new Contract()
            .Requires()
            .IsEmailOrEmpty(Email, "Email", "E-mail invalido")
            .IsNullOrEmpty(Senha, "Senha", "Senha é obrigatoria")
            .IsNullOrEmpty(Nome, "Nome", "Nome é obrigatorio")
      );
    }
  }
}