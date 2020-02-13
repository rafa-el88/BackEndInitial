using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PositivoCore.Data.Migrations
{
    public partial class Periodos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PeriodoLetivoTipo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodoLetivoTipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periodo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IdPeriodoLetivoTipo = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Periodo_PeriodoLetivoTipo_IdPeriodoLetivoTipo",
                        column: x => x.IdPeriodoLetivoTipo,
                        principalTable: "PeriodoLetivoTipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeriodoLetivoConfiguracao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    dtInicio = table.Column<DateTime>(nullable: false),
                    AnoLetivo = table.Column<int>(nullable: false),
                    IdEscola = table.Column<Guid>(nullable: false),
                    IdNivelEnsino = table.Column<Guid>(nullable: false),
                    IdPeriodoLetivoTipo = table.Column<Guid>(nullable: false),
                    IdPeriodo = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodoLetivoConfiguracao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodoLetivoConfiguracao_Escola_IdEscola",
                        column: x => x.IdEscola,
                        principalTable: "Escola",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PeriodoLetivoConfiguracao_NivelEnsino_IdNivelEnsino",
                        column: x => x.IdNivelEnsino,
                        principalTable: "NivelEnsino",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PeriodoLetivoConfiguracao_Periodo_IdPeriodo",
                        column: x => x.IdPeriodo,
                        principalTable: "Periodo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PeriodoLetivoConfiguracao_PeriodoLetivoTipo_IdPeriodoLetivoTipo",
                        column: x => x.IdPeriodoLetivoTipo,
                        principalTable: "PeriodoLetivoTipo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Periodo_IdPeriodoLetivoTipo",
                table: "Periodo",
                column: "IdPeriodoLetivoTipo");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodoLetivoConfiguracao_IdEscola",
                table: "PeriodoLetivoConfiguracao",
                column: "IdEscola");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodoLetivoConfiguracao_IdNivelEnsino",
                table: "PeriodoLetivoConfiguracao",
                column: "IdNivelEnsino");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodoLetivoConfiguracao_IdPeriodo",
                table: "PeriodoLetivoConfiguracao",
                column: "IdPeriodo");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodoLetivoConfiguracao_IdPeriodoLetivoTipo",
                table: "PeriodoLetivoConfiguracao",
                column: "IdPeriodoLetivoTipo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeriodoLetivoConfiguracao");

            migrationBuilder.DropTable(
                name: "Periodo");

            migrationBuilder.DropTable(
                name: "PeriodoLetivoTipo");
        }
    }
}
