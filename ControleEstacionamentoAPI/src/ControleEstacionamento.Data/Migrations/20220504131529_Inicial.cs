using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleEstacionamento.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cpf = table.Column<string>(nullable: true),
                    DataDesconto = table.Column<DateTime>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parametros",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ValorPrimeiraHora = table.Column<decimal>(nullable: false),
                    ValorHoraAdicional = table.Column<decimal>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParametrosGratuidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DiaSemana = table.Column<string>(nullable: true),
                    Inicio = table.Column<DateTime>(nullable: false),
                    Encerramento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametrosGratuidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Placa = table.Column<string>(nullable: false),
                    Cpf = table.Column<string>(nullable: true),
                    Entrada = table.Column<DateTime>(nullable: false),
                    Saida = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Desconto = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Parametros");

            migrationBuilder.DropTable(
                name: "ParametrosGratuidade");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
