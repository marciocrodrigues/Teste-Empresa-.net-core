using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteBitzen.INFRA.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    Senha = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Nome = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Marca = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Modelo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Ano = table.Column<short>(type: "smallint", nullable: false),
                    Placa = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    Combustivel = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    QuilometragemCadastro = table.Column<int>(type: "integer", nullable: false),
                    QuilometragemRodada = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    Foto = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculo_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Abastecimento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    KmAbastecimento = table.Column<int>(type: "integer", nullable: false),
                    QuilometrosRodados = table.Column<int>(nullable: false),
                    LitrosAbastecidos = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    ValorAbastecimento = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    DiaAbastecimento = table.Column<short>(type: "smallint", nullable: false),
                    MesAbastecimento = table.Column<short>(type: "smallint", nullable: false),
                    AnoAbastecimento = table.Column<short>(type: "smallint", nullable: false),
                    PostoCombustivel = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    TipoCombustivel = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    VeiculoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abastecimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abastecimento_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Abastecimento_Veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abastecimento_UsuarioId",
                table: "Abastecimento",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Abastecimento_VeiculoId",
                table: "Abastecimento",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_UsuarioId",
                table: "Veiculo",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abastecimento");

            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
