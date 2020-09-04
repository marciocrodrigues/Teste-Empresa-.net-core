namespace TesteBitzen.DOMAIN.Entities
{
    public class TipoCombustivel : BaseEntitie
    {
        public TipoCombustivel(string descricao) 
        {
          this.Descricao = descricao;
               
        }
                public string Descricao { get; private set; }

        public void AlterarDescricao(string descricao) 
        {
            Descricao = descricao;
        }
    }
}