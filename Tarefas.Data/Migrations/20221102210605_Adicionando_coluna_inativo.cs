using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarefas.Data.Migrations
{
    public partial class Adicionando_coluna_inativo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "inativo",
                table: "usuarios",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inativo",
                table: "clientes",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "inativo",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "inativo",
                table: "clientes");
        }
    }
}
