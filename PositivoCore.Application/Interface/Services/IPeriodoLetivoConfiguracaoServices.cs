using PositivoCore.Application.Commands;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Interface.Services
{
    public interface IPeriodoLetivoConfiguracaoServices
    {
        Task<IEnumerable<PeriodoLetivoConfiguracaoViewModel>> GetAllPeriodoLetivoConfiguracoes();
        Task<PeriodoLetivoConfiguracaoViewModel> GetPeriodoLetivoConfiguracaoById(Guid idPeriodoLetivoConfiguracao);
        Task<ICommandResult> NewPeriodoLetivoConfiguracao(CreatePeriodoLetivoConfiguracaoCommand command);
        Task<ICommandResult> UpdatePeriodoLetivoConfiguracao(UpdatePeriodoLetivoConfiguracaoCommand command);
        Task<ICommandResult> DeletarPeriodoLetivoConfiguracao(Guid idPeriodoLetivoConfiguracao);
    }
}
