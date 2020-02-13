using PositivoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Queries
{
    public interface IPeriodoLetivoConfiguracaoQuery
    {
        Task<IEnumerable<PeriodoLetivoConfiguracao>> GetAllPeriodoLetivoConfiguracoes();
        Task<PeriodoLetivoConfiguracao> GetPeriodoLetivoConfiguracaoPorId(Guid id);
    }
}
