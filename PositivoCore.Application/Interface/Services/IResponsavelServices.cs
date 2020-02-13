using PositivoCore.Application.Commands.Responsavel;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Interface.Services
{
    public interface IResponsavelServices
    {
        Task<IEnumerable<ResponsavelViewModel>> GetAllResponsavels();
        Task<ResponsavelViewModel> GetResponsavelById(Guid idResponsavel);
        Task<IEnumerable<ResponsavelViewModel>> GetResponsavelByNome(string nome);
        Task<ICommandResult> NewResponsavel(CreateResponsavelCommand command);
        Task<ICommandResult> UpdateResponsavel(UpdateResponsavelCommand command);
        Task<ICommandResult> DeleteResponsavel(Guid idResponsavel);
    }
}