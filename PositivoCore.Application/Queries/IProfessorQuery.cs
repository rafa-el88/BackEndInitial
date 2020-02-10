using PositivoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Queries
{
    public interface IProfessorQuery
    {
        Task<IEnumerable<Professor>> GetAllProfessores();
        Task<Professor> GetProfessorPorId(Guid id);
        Task<Professor> GetProfessorPorCPF(string cpf);
        Task<IEnumerable<Professor>> GetProfessorPorNome(string nome);
    }
}
