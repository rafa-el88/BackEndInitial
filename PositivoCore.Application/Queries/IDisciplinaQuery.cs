using PositivoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Queries
{
    public interface IDisciplinaQuery
    {
        Task<IEnumerable<Disciplina>> GetAllDisciplinas();
        Task<Disciplina> GetDisciplinaById(Guid id);
        Task<IEnumerable<Disciplina>> GetDisciplinaByNome(string nome);
    }
}
