using PositivoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Queries
{
    public interface IAdministradorQuery
    {
        Task<IEnumerable<Administrador>> GetAllAdministradores();
        Task<Administrador> GetAdministradorPorId(Guid id);
        Task<IEnumerable<Administrador>> GetAdministradorPorNome(string nome);
    }
}
