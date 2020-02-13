using Flunt.Notifications;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands
{
    public class CreatePeriodoLetivoConfiguracaoCommand : Notifiable, ICommand
    {
        public CreatePeriodoLetivoConfiguracaoCommand() { }

        public CreatePeriodoLetivoConfiguracaoCommand(DateTime dtInicio, int anoLetivo, Guid idEscola, Guid idNivelEnsino, Guid idPeriodoLetivoTipo, Guid idPeriodo)
        {
            DtInicio = dtInicio;
            AnoLetivo = anoLetivo;
            IdEscola = idEscola;
            IdNivelEnsino = idNivelEnsino;
            IdPeriodoLetivoTipo = idPeriodoLetivoTipo;
            IdPeriodo = idPeriodo;
        }

        public DateTime DtInicio { get; set; }
        public int AnoLetivo { get; set; }
        public Guid IdEscola { get; set; }
        public Guid IdNivelEnsino { get; set; }
        public Guid IdPeriodoLetivoTipo { get; set; }
        public Guid IdPeriodo { get; set; }

        public void Validate()
        {
            // Method intentionally left empty.
        }
    }
}