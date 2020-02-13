using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PositivoCore.Data.Migrations
{
    public partial class responsavelprops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Responsavel",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Responsavel",
                type: "DateTime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Responsavel",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Responsavel");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Responsavel");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Responsavel");
        }
    }
}
