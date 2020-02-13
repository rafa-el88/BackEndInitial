using PositivoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Queries
{
    public interface IColecaoQuery
    {
        Task<IEnumerable<Colecao>> GetAllColecoes();
        Task<Colecao> GetColecaoPorId(Guid id);
        Task<IEnumerable<Colecao>> GetColecaoPorNome(string nome);
    }
}
