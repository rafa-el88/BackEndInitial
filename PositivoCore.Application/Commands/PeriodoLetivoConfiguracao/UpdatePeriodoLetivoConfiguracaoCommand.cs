using System;
using Flunt.Notifications;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands
{
    public class UpdatePeriodoLetivoConfiguracaoCommand : Notifiable, ICommand
    {
        public UpdatePeriodoLetivoConfiguracaoCommand() { }

        public UpdatePeriodoLetivoConfiguracaoCommand(Guid id, DateTime dtInicio, int anoLetivo, Guid idEscola, Guid idNivelEnsino, Guid idPeriodoLetivoTipo, Guid idPeriodo)
        {
            Id = id;
            DtInicio = dtInicio;
            AnoLetivo = anoLetivo;
            IdEscola = idEscola;
            IdNivelEnsino = idNivelEnsino;
            IdPeriodoLetivoTipo = idPeriodoLetivoTipo;
            IdPeriodo = idPeriodo;
        }

        public Guid Id { get; set; }
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