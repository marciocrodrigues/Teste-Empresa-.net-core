using System;
using System.Collections.Generic;
using System.Text;
using TesteBitzen.DOMAIN.Interfaces;

namespace TesteBitzen.DOMAIN.Dtos
{
    public class RetornoDTO : IRetorno
    {
        public RetornoDTO(bool sucesso,
                          string mensagem, 
                          object data)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Data = data;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Data { get; set; }
    }
}
