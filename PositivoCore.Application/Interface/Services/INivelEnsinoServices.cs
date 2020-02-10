using PositivoCore.Application.Commands;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Interface.Services
{
    public interface INivelEnsinoServices
    {
        Task<IEnumerable<NivelEnsinoViewModel>> GetAllNiveisEnsino();
        Task<NivelEnsinoViewModel> GetNivelEnsinoByID(Guid idNivelEnsino);
        Task<IEnumerable<NivelEnsinoViewModel>> GetNivelEnsinoByNome(string nome);
        Task<ICommandResult> NewNivelEnsino(CreateNivelEnsinoCommand command);
        Task<ICommandResult> UpdateNivelEnsino(UpdateNivelEnsinoCommand command);
        Task<ICommandResult> DeletarNivelEnsino(Guid idNivelEnsino);
    }
}
