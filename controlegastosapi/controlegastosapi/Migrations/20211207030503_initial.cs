using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace controlegastosapi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Produto = table.Column<string>(nullable: false),
                    Loja = table.Column<string>(nullable: false),
                    Local = table.Column<string>(nullable: true),
                    NumeroParcela = table.Column<int>(nullable: false),
                    QuantidadeParcelas = table.Column<int>(nullable: false),
                    Tipo = table.Column<string>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    Observacao = table.Column<string>(nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
