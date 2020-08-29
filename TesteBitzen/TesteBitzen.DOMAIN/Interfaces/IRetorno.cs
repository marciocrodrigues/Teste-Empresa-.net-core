using System;
using System.Collections.Generic;
using System.Text;

namespace TesteBitzen.DOMAIN.Interfaces
{
    public interface IRetorno
    {
        bool Sucesso { get; set; }
        string Mensagem { get; set; }
        object Data { get; set; }
    }
}
