using PositivoCore.Application.Commands;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Interface.Services
{
    public interface IDisciplinaServices
    {
        Task<IEnumerable<DisciplinaViewModel>> GetAllDisciplinas();
        Task<DisciplinaViewModel> GetDisciplinaByID(Guid idDisciplina);
        Task<IEnumerable<DisciplinaViewModel>> GetDisciplinaByNome(string nome);
        Task<ICommandResult> NewDisciplina(CreateDisciplinaCommand command);
        Task<ICommandResult> UpdateDisciplina(UpdateDisiplinaCommand command);
        Task<ICommandResult> DeletarDisciplina(Guid idDisciplina);
    }
}
