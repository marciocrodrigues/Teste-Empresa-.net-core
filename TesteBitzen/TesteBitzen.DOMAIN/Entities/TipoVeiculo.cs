namespace TesteBitzen.DOMAIN.Entities
{
    public class TipoVeiculo : BaseEntitie
    {
       public string Descricao { get; set; }

       public void AlterarDescricao(string descricao)
       {
           Descricao = descricao;
       } 
    }
}