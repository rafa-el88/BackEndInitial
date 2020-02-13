using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PositivoCore.Data.Migrations
{
    public partial class AlterTableAluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Disciplina",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Disciplina",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Aluno",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "Apelido",
                table: "Aluno",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Aluno",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Aluno",
                type: "DateTime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Aluno",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Genero",
                table: "Aluno",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Matricula",
                table: "Aluno",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apelido",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "Aluno");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Disciplina",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Disciplina",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Aluno",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
