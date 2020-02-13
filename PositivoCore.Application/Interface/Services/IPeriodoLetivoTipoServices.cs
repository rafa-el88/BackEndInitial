using PositivoCore.Application.Commands;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Interface.Services
{
    public interface IPeriodoLetivoTipoServices
    {
        Task<IEnumerable<PeriodoLetivoTipoViewModel>> GetAllPeriodoLetivoTipos();
        Task<PeriodoLetivoTipoViewModel> GetPeriodoLetivoTipoById(Guid idPeriodoLetivoTipo);
        Task<IEnumerable<PeriodoLetivoTipoViewModel>> GetPeriodoLetivoTipoByNome(string nome);
        Task<ICommandResult> NewPeriodoLetivoTipo(CreatePeriodoLetivoTipoCommand command);
        Task<ICommandResult> UpdatePeriodoLetivoTipo(UpdatePeriodoLetivoTipoCommand command);
        Task<ICommandResult> DeletarPeriodoLetivoTipo(Guid idPeriodoLetivoTipo);
    }
}
