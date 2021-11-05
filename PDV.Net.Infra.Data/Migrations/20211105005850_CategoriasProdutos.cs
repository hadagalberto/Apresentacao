using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PDV.Net.Infra.Data.Migrations
{
    public partial class CategoriasProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdCategoriaProduto",
                table: "Produtos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoriasProdutos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasProdutos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdCategoriaProduto",
                table: "Produtos",
                column: "IdCategoriaProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_CategoriasProdutos_IdCategoriaProduto",
                table: "Produtos",
                column: "IdCategoriaProduto",
                principalTable: "CategoriasProdutos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_CategoriasProdutos_IdCategoriaProduto",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "CategoriasProdutos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_IdCategoriaProduto",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "IdCategoriaProduto",
                table: "Produtos");
        }
    }
}
