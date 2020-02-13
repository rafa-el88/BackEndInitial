using PositivoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Queries
{
    public interface IPeriodoLetivoTipoQuery
    {
        Task<IEnumerable<PeriodoLetivoTipo>> GetAllPeriodoLetivoTipos();
        Task<PeriodoLetivoTipo> GetPeriodoLetivoTipoPorId(Guid id);
        Task<IEnumerable<PeriodoLetivoTipo>> GetPeriodoLetivoTipoPorNome(string nome);
    }
}
