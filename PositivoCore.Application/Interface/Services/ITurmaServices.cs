using PositivoCore.Application.Commands;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Interface.Services
{
    public interface ITurmaServices
    {
        Task<IEnumerable<TurmaViewModel>> GetAllTurmas();
        Task<TurmaViewModel> GetTurmaByID(Guid idTurma);
        Task<IEnumerable<TurmaViewModel>> GetTurmaByNome(string nome);
        Task<ICommandResult> AttachTurmaDisciplinaProfessor(List<TurmaDisciplinaProfessorViewModel> obj);
        Task<ICommandResult> NewTurma(CreateTurmaCommand command);
        Task<ICommandResult> UpdateTurma(UpdateTurmaCommand command);
        Task<ICommandResult> DeletarTurma(Guid idTurma);
    }
}
