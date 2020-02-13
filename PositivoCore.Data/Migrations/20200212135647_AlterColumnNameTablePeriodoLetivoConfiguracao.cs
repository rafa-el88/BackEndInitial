using Microsoft.EntityFrameworkCore.Migrations;

namespace PositivoCore.Data.Migrations
{
    public partial class AlterColumnNameTablePeriodoLetivoConfiguracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dtInicio",
                table: "PeriodoLetivoConfiguracao",
                newName: "DtInicio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DtInicio",
                table: "PeriodoLetivoConfiguracao",
                newName: "dtInicio");
        }
    }
}
