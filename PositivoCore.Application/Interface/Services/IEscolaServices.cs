using PositivoCore.Application.Commands;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Interface.Services
{
    public interface IEscolaServices
    {
        Task<IEnumerable<EscolaViewModel>> GetAllEscolas();
        Task<EscolaViewModel> GetEscolaById(Guid idEscola);
        Task<EscolaViewModel> GetEscolaByCNPJ(string cnpj);
        Task<IEnumerable<EscolaViewModel>> GetEscolaByNome(string nome);
        Task<ICommandResult> CreateEscola(CreateEscolaCommand command);
        Task<ICommandResult> CreateEscolasFromList(List<EscolaViewModel> lst);
        Task<ICommandResult> UpdateEscola(UpdateEscolaCommand command);
        Task<ICommandResult> DeleteEscola(Guid idEscola);
    }
}
