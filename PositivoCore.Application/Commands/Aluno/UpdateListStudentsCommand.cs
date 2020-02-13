using Flunt.Notifications;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Commands;
using System.Collections.Generic;

namespace PositivoCore.Application.Commands.Aluno
{
    public class UpdateListStudentsCommand : Notifiable, ICommand
    {
        public UpdateListStudentsCommand() { }
        public UpdateListStudentsCommand(List<AlunoViewModel> alunos) => Alunos = alunos;
        public List<AlunoViewModel> Alunos { get; private set; }

        public void Validate()
        {
            // Method intentionally left empty.
        }
    }
}
