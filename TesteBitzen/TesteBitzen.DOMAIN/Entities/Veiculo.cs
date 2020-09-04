using System;
using System.Collections.Generic;

namespace TesteBitzen.DOMAIN.Entities
{
    public class Veiculo : BaseEntitie
    {
        public Veiculo(string marca, string modelo, int ano, string placa, int tipoVeiculoId, int tipoCumbustivelId, int quilometragemCadastro, Guid usuarioId)
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Placa = placa;
            TipoVeiculoId = tipoVeiculoId;
            TipoCumbustivelId = tipoCumbustivelId;
            QuilometragemCadastro = quilometragemCadastro;
            QuilometragemRodada = quilometragemCadastro;
            UsuarioId = usuarioId;
        }

        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public int Ano { get; private set; }
        public string Placa { get; private set; }
        public int TipoVeiculoId { get; private set; }
        public TipoVeiculo TipoVeiculo { get; private set;}
        public int TipoCumbustivelId { get; private set;}
        public TipoCombustivel TipoCombustivel { get; private set;}
        public int QuilometragemCadastro { get; private set; }
        public int QuilometragemRodada { get; private set; }
        public Guid UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }
        public string Foto { get; private set; }
        public IEnumerable<Abastecimento> Abastecimentos { get; set; }

        public void AlterarQuilometragemRodada(int quilometragem)
        {
            QuilometragemRodada += quilometragem;
        }

        public void AlterarFoto(string foto)
        {
            Foto = foto;
        }

        public void AlterarPlaca(string placa)
        {
            Placa = placa;
        }
    }
}
