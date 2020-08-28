using System.Collections.Generic;

namespace TesteBitzen.DOMAIN.Entities
{
    public class Usuario : BaseEntitie
    {
        public Usuario(string email, 
                       string senha, 
                       string nome)
        {
            Email = email;
            Senha = senha;
            Nome = nome;
        }

        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Nome { get; private set; }
        public IEnumerable<Veiculo> Veiculos { get; set; }

        public void AlterarEmail(string email)
        {
            Email = email;
        }

        public void AlterarSenha(string senha)
        {
            Senha = senha;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }
    }
}
