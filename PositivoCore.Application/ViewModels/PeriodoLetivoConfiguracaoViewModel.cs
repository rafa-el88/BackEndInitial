using System;

namespace PositivoCore.Application.ViewModels
{
    public class PeriodoLetivoConfiguracaoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DtInicio { get; set; }
        public int AnoLetivo { get; set; }
        public EscolaViewModel Escola { get; set; }
        public NivelEnsinoViewModel NivelEnsino { get; set; }
        public PeriodoLetivoTipoViewModel PeriodoLetivoTipo { get; set; }
        public PeriodoViewModel Periodo { get; set; }
    }
}
