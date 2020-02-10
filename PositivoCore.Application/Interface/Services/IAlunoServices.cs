using PositivoCore.Application.Commands;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Interface.Services
{
    public interface IAlunoServices
    {
        Task<IEnumerable<AlunoViewModel>> GetAllAlunos();
        Task<AlunoViewModel> GetAlunoById(Guid idAluno);
        Task<IEnumerable<AlunoViewModel>> GetAlunoByNome(string nome);
        Task<ICommandResult> NewAluno(CreateAlunoCommand command);
        Task<ICommandResult> UpdateAluno(UpdateAlunoCommand command);
        Task<ICommandResult> DeletarAluno(Guid idAluno);
        Task<ICommandResult> NewListStudents(List<AlunoViewModel> lst);
        Task<ICommandResult> UpdateListStudents(List<AlunoViewModel> lst);
        Task<ICommandResult> DeleteListStudents(List<Guid> lst);
    }
}
