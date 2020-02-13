using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PositivoCore.Data.Migrations
{
    public partial class CreatedTableDestinatarioMensagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DestinatarioMensagem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    TipoPerfil = table.Column<int>(type: "int", nullable: false),
                    IdDestinatario = table.Column<Guid>(nullable: false),
                    IdMensagem = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinatarioMensagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DestinatarioMensagem_Mensagem_IdMensagem",
                        column: x => x.IdMensagem,
                        principalTable: "Mensagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DestinatarioMensagem_IdMensagem",
                table: "DestinatarioMensagem",
                column: "IdMensagem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestinatarioMensagem");
        }
    }
}
