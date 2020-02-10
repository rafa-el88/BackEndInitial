using PositivoCore.Application.Commands;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Interface.Services
{
    public interface IProfessorServices
    {
        Task<IEnumerable<ProfessorViewModel>> GetAllProfessores();
        Task<ProfessorViewModel> GetProfessorById(Guid idProfessor);
        Task<ProfessorViewModel> GetProfessorByCPF(string cpf);
        Task<IEnumerable<ProfessorViewModel>> GetProfessorByNome(string nome);
        Task<ICommandResult> NewProfessor(CreateProfessorCommand command);
        Task<ICommandResult> UpdateProfessor(UpdateProfessorCommand command);
        Task<ICommandResult> DeletarProfessor(Guid idProfessor);
    }
}
