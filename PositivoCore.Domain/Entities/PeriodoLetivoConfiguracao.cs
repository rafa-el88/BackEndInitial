using PositivoCore.Shared.Entities;
using System;

namespace PositivoCore.Domain.Entities
{
    public class PeriodoLetivoConfiguracao: Entity
    {
        public PeriodoLetivoConfiguracao()
        {

        }

        public PeriodoLetivoConfiguracao(DateTime dtInicio, int anoLetivo, Guid idEscola, Guid idNivelEnsino, Guid idPeriodoLetivoTipo, Guid idPeriodo)
        {
            DtInicio = dtInicio;
            AnoLetivo = anoLetivo;
            IdEscola = idEscola;
            IdNivelEnsino = idNivelEnsino;
            IdPeriodoLetivoTipo = idPeriodoLetivoTipo;
            IdPeriodo = idPeriodo;
        }

        public virtual Escola Escola { get; private set; }
        public virtual NivelEnsino NivelEnsino { get; private set; }
        public virtual PeriodoLetivoTipo PeriodoLetivoTipo { get; private set; }
        public virtual Periodo Periodo { get; private set; }

        public DateTime DtInicio { get; private set; }
        public int AnoLetivo { get; private set; }
        public Guid IdEscola { get; private set; }
        public Guid IdNivelEnsino { get; private set; }
        public Guid IdPeriodoLetivoTipo { get; private set; }
        public Guid IdPeriodo { get; private set; }

        public void UpdateFields(PeriodoLetivoConfiguracao fields)
        {
            DtInicio = fields.DtInicio;
            AnoLetivo = fields.AnoLetivo;
            IdEscola = fields.IdEscola;
            IdNivelEnsino = fields.IdNivelEnsino;
            IdPeriodoLetivoTipo = fields.IdPeriodoLetivoTipo;
            IdPeriodo = fields.IdPeriodo;
        }
    }
}
