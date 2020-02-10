using PositivoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Queries
{
    public interface ISerieQuery
    {
        Task<IEnumerable<Serie>> GetAllSeries();
        Task<Serie> GetSerieByID(Guid id);
        Task<IEnumerable<Serie>> GetSerieByNome(string nome);
    }
}
