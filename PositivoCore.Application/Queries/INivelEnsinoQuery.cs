using PositivoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Queries
{
    public interface INivelEnsinoQuery
    {
        Task<IEnumerable<NivelEnsino>> GetAllNiveisEnsino();
        Task<NivelEnsino> GetNivelEnsinoByID(Guid id);
        Task<IEnumerable<NivelEnsino>> GetNivelEnsinoByNome(string nome);
    }
}
