using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarefas.Data.Migrations
{
    public partial class Primeira_migracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bairro = table.Column<string>(type: "text", nullable: false),
                    cidade = table.Column<string>(type: "text", nullable: false),
                    uf = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    logradouro = table.Column<string>(type: "text", nullable: false),
                    numero = table.Column<string>(type: "text", nullable: false),
                    cep = table.Column<string>(type: "text", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    login = table.Column<string>(type: "text", nullable: false),
                    senha = table.Column<string>(type: "text", nullable: false),
                    tipo_usuario = table.Column<int>(type: "integer", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "chamados",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    titulo = table.Column<string>(type: "text", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: false),
                    data_prevista = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    tipo = table.Column<int>(type: "integer", nullable: false),
                    id_criador = table.Column<Guid>(type: "uuid", nullable: false),
                    id_responsavel = table.Column<Guid>(type: "uuid", nullable: false),
                    id_cliente = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chamados", x => x.id);
                    table.ForeignKey(
                        name: "FK_chamados_clientes_id_cliente",
                        column: x => x.id_cliente,
                        principalTable: "clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chamados_usuarios_id_criador",
                        column: x => x.id_criador,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chamados_usuarios_id_responsavel",
                        column: x => x.id_responsavel,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "historicos_chamados",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    anotacao = table.Column<string>(type: "text", nullable: false),
                    id_usuario = table.Column<Guid>(type: "uuid", nullable: false),
                    data_ocorrencia = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    id_chamado = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historicos_chamados", x => x.id);
                    table.ForeignKey(
                        name: "FK_historicos_chamados_chamados_id_chamado",
                        column: x => x.id_chamado,
                        principalTable: "chamados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_historicos_chamados_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tempo_gasto",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tempo_gasto = table.Column<TimeSpan>(type: "interval", nullable: false),
                    atividade = table.Column<string>(type: "text", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    id_chamado = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tempo_gasto", x => x.id);
                    table.ForeignKey(
                        name: "FK_tempo_gasto_chamados_id_chamado",
                        column: x => x.id_chamado,
                        principalTable: "chamados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chamados_id_cliente",
                table: "chamados",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_chamados_id_criador",
                table: "chamados",
                column: "id_criador");

            migrationBuilder.CreateIndex(
                name: "IX_chamados_id_responsavel",
                table: "chamados",
                column: "id_responsavel");

            migrationBuilder.CreateIndex(
                name: "IX_historicos_chamados_id_chamado",
                table: "historicos_chamados",
                column: "id_chamado");

            migrationBuilder.CreateIndex(
                name: "IX_historicos_chamados_id_usuario",
                table: "historicos_chamados",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_tempo_gasto_id_chamado",
                table: "tempo_gasto",
                column: "id_chamado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historicos_chamados");

            migrationBuilder.DropTable(
                name: "tempo_gasto");

            migrationBuilder.DropTable(
                name: "chamados");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
