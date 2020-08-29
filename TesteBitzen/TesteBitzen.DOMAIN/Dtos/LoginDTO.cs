using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using TesteBitzen.DOMAIN.Dtos.Interfaces;

namespace TesteBitzen.DOMAIN.Dtos
{
    public class LoginDTO : Notifiable, IBaseDTO
    {
        public LoginDTO(){}

        public LoginDTO(string email, 
                        string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; set; }
        public string Senha { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Email, "E-mail", "E-mail obrigatorio")
                    .IsNotNullOrEmpty(Senha, "Senha", "Senha obrigatoria")
            );
        }
    }
}
