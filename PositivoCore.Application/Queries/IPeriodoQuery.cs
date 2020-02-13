using PositivoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Queries
{
    public interface IPeriodoQuery
    {
        Task<IEnumerable<Periodo>> GetAllPeriodos();
        Task<Periodo> GetPeriodoPorId(Guid id);
        Task<IEnumerable<Periodo>> GetPeriodoPorNome(string nome);
        Task<IEnumerable<Periodo>> GetPeriodoByTipo(Guid idPeriodoLetivoTipo);
    }
}
