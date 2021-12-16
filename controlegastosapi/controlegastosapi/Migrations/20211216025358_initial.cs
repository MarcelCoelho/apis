using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace controlegastosapi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faturas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UsuarioCriacao = table.Column<string>(nullable: true),
                    UsuarioModificacao = table.Column<string>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataModificacao = table.Column<DateTime>(nullable: false),
                    mes = table.Column<string>(type: "varchar(2)", nullable: false),
                    ano = table.Column<string>(type: "varchar(4)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Observacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faturas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposPagamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UsuarioCriacao = table.Column<string>(nullable: true),
                    UsuarioModificacao = table.Column<string>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataModificacao = table.Column<DateTime>(nullable: false),
                    Codigo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    Observacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPagamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UsuarioCriacao = table.Column<string>(nullable: true),
                    UsuarioModificacao = table.Column<string>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataModificacao = table.Column<DateTime>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    FaturaId = table.Column<Guid>(nullable: true),
                    TipoPagamentoId = table.Column<Guid>(nullable: true),
                    Produto = table.Column<string>(type: "varchar(300)", nullable: false),
                    Loja = table.Column<string>(type: "varchar(300)", nullable: false),
                    Local = table.Column<string>(type: "varchar(300)", nullable: false),
                    NumeroParcela = table.Column<decimal>(type: "numeric", nullable: false),
                    QuantidadeParcelas = table.Column<decimal>(type: "numeric", nullable: false),
                    Tipo = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    Observacao = table.Column<string>(type: "varchar(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Faturas_FaturaId",
                        column: x => x.FaturaId,
                        principalTable: "Faturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_TiposPagamentos_TipoPagamentoId",
                        column: x => x.TipoPagamentoId,
                        principalTable: "TiposPagamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_FaturaId",
                table: "Items",
                column: "FaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_TipoPagamentoId",
                table: "Items",
                column: "TipoPagamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Faturas");

            migrationBuilder.DropTable(
                name: "TiposPagamentos");
        }
    }
}
