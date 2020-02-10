using PositivoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Queries
{
    public interface ITurmaQuery
    {
        Task<IEnumerable<Turma>> GetAllTurmas();
        Task<Turma> GetTurmaByID(Guid id);
        Task<IEnumerable<Turma>> GetTurmaByNome(string nome);
    }
}
