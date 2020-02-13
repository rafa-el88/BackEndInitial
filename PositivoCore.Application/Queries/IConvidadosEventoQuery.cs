using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PositivoCore.Domain.Entities;

namespace PositivoCore.Application.Queries
{
    public interface IConvidadosEventoQuery
    {
        Task<IEnumerable<ConvidadosEvento>> GetAllConvidadosEvento();
        Task<ConvidadosEvento> GetConvidadosEventoById(Guid id);
        Task<IEnumerable<ConvidadosEvento>> GetConvidadosEventoByNome(string nome);
    }
}