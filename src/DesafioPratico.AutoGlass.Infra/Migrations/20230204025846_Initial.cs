using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioPratico.AutoGlass.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    Situacao = table.Column<short>(type: "smallint", nullable: false),
                    DataFabricacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdFornecedor = table.Column<int>(type: "int", nullable: false),
                    DescricaoFornecedor = table.Column<string>(type: "varchar(100)", nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(14)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
