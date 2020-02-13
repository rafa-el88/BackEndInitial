using PositivoCore.Application.Commands;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Interface.Services
{
    public interface IAdministradorServices
    {
        Task<IEnumerable<AdministradorViewModel>> GetAllAdministradores();
        Task<AdministradorViewModel> GetAdministradorById(Guid idAdministrador);
        Task<IEnumerable<AdministradorViewModel>> GetAdministradorByNome(string nome);
        Task<ICommandResult> NewAdministrador(CreateAdministradorCommand command);
        Task<ICommandResult> UpdateAdministrador(UpdateAdministradorCommand command);
        Task<ICommandResult> DeletarAdministrador(Guid idAdministrador);
        Task<ICommandResult> NewListAdministradores(List<AdministradorViewModel> lst);
        Task<ICommandResult> UpdateListAdministradores(List<AdministradorViewModel> lst);
        Task<ICommandResult> DeleteListAdministradores(List<Guid> lst);
    }
}
