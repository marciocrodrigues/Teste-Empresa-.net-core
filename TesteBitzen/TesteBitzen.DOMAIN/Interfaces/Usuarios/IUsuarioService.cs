using TesteBitzen.DOMAIN.Dtos;

namespace TesteBitzen.DOMAIN.Interfaces
{
    public interface IUsuarioService : IService<UsuarioDTO>
    {
        IRetorno BuscarPorEmailSenha(LoginDTO dto);
    }
}