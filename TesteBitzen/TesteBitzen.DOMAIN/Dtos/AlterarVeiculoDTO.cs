using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using TesteBitzen.DOMAIN.Dtos.Interfaces;

namespace TesteBitzen.DOMAIN.Dtos
{
    public class AlterarVeiculoDTO : Notifiable, IBaseDTO
    {
        public string Placa { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Placa, "Placa", "Placa obrigatoria")
            );
        }
    }
}
