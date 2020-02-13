using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PositivoCore.Data.Migrations
{
    public partial class CreatedTableMensagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mensagem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Assunto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Texto = table.Column<string>(nullable: false),
                    PermiteResposta = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagem", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mensagem");
        }
    }
}
