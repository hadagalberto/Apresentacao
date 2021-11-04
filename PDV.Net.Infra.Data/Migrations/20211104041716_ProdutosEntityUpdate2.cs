using Microsoft.EntityFrameworkCore.Migrations;

namespace PDV.Net.Infra.Data.Migrations
{
    public partial class ProdutosEntityUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Valor",
                table: "Produtos",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(2)",
                oldPrecision: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Valor",
                table: "Produtos",
                type: "float(2)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
