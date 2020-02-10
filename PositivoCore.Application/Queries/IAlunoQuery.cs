using PositivoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Queries
{
    public interface IAlunoQuery
    {
        Task<IEnumerable<Aluno>> GetAllAlunos();
        Task<Aluno> GetAlunoPorId(Guid id);
        Task<IEnumerable<Aluno>> GetAlunoPorNome(string nome);
    }
}
