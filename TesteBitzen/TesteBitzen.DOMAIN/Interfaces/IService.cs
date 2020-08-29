using System;
using System.Collections.Generic;
using System.Text;

namespace TesteBitzen.DOMAIN.Interfaces
{
    public interface IService<T> where T : class
    {
        IRetorno Criar(T dto);
        IRetorno Alterar(Guid id, T dto);
        IRetorno Excluir(Guid id);
        IRetorno BuscarTodos();
        IRetorno BuscarPorId(Guid id);
    }
}
