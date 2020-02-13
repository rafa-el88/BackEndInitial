using PositivoCore.Application.Commands;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Interface.Services
{
    public interface IColecaoServices
    {
        Task<IEnumerable<ColecaoViewModel>> GetAllColecoes();
        Task<ColecaoViewModel> GetColecaoById(Guid idColecao);
        Task<IEnumerable<ColecaoViewModel>> GetColecaoByNome(string nome);
        Task<ICommandResult> NewColecao(CreateColecaoCommand command);
        Task<ICommandResult> UpdateColecao(UpdateColecaoCommand command);
        Task<ICommandResult> DeletarColecao(Guid idColecao);
    }
}
