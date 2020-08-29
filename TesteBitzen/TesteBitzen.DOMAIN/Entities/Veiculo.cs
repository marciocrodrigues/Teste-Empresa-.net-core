using System;
using System.Collections.Generic;

namespace TesteBitzen.DOMAIN.Entities
{
    public class Veiculo : BaseEntitie
    {
        public Veiculo(string marca, string modelo, int ano, string placa, string tipo, string combustivel, int quilometragem, Guid usuarioId, string foto)
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Placa = placa;
            Tipo = tipo;
            Combustivel = combustivel;
            Quilometragem = quilometragem;
            UsuarioId = usuarioId;
            Foto = foto;
        }

        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public int Ano { get; private set; }
        public string Placa { get; private set; }
        public string Tipo { get; private set; }
        public string Combustivel { get; private set; }
        public int Quilometragem { get; private set; }
        public Guid UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }
        public string Foto { get; private set; }
        public IEnumerable<Abastecimento> Abastecimentos { get; set; }

        public void AlterarQuilomegragem(int quilometragem)
        {
            Quilometragem = quilometragem;
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
