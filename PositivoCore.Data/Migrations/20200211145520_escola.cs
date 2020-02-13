using Microsoft.EntityFrameworkCore.Migrations;

namespace PositivoCore.Data.Migrations
{
    public partial class escola : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodSGE",
                table: "Escola",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "INEP",
                table: "Escola",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "INEPDescricao",
                table: "Escola",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InscricaoEstadual",
                table: "Escola",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RazaoSocial",
                table: "Escola",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoEscola",
                table: "Escola",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodSGE",
                table: "Escola");

            migrationBuilder.DropColumn(
                name: "INEP",
                table: "Escola");

            migrationBuilder.DropColumn(
                name: "INEPDescricao",
                table: "Escola");

            migrationBuilder.DropColumn(
                name: "InscricaoEstadual",
                table: "Escola");

            migrationBuilder.DropColumn(
                name: "RazaoSocial",
                table: "Escola");

            migrationBuilder.DropColumn(
                name: "TipoEscola",
                table: "Escola");
        }
    }
}
