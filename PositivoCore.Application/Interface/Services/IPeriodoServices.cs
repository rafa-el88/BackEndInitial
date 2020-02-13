using PositivoCore.Application.Commands;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Interface.Services
{
    public interface IPeriodoServices
    {
        Task<IEnumerable<PeriodoViewModel>> GetAllPeriodos();
        Task<PeriodoViewModel> GetPeriodoById(Guid idPeriodo);
        Task<IEnumerable<PeriodoViewModel>> GetPeriodoByNome(string nome);
        Task<ICommandResult> NewPeriodo(CreatePeriodoCommand command);
        Task<ICommandResult> UpdatePeriodo(UpdatePeriodoCommand command);
        Task<ICommandResult> DeletarPeriodo(Guid idPeriodo);
        Task<IEnumerable<PeriodoViewModel>> GetPeriodoByTipo(Guid idPeriodoLetivoTipo);
    }
}
