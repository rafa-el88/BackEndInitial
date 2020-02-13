using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PositivoCore.Data.Migrations
{
    public partial class AddColumnsMensagemFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Responsavel",
                type: "DateTime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AddColumn<Guid>(
                name: "IdMensagemVinculada",
                table: "Mensagem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_IdMensagemVinculada",
                table: "Mensagem",
                column: "IdMensagemVinculada");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagem_Mensagem_IdMensagemVinculada",
                table: "Mensagem",
                column: "IdMensagemVinculada",
                principalTable: "Mensagem",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensagem_Mensagem_IdMensagemVinculada",
                table: "Mensagem");

            migrationBuilder.DropIndex(
                name: "IX_Mensagem_IdMensagemVinculada",
                table: "Mensagem");

            migrationBuilder.DropColumn(
                name: "IdMensagemVinculada",
                table: "Mensagem");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Responsavel",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldNullable: true);
        }
    }
}
