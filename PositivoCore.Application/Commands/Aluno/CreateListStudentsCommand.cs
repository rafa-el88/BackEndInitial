using System;
using System.Collections.Generic;
using Flunt.Notifications;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands.Aluno
{
    public class CreateListStudentsCommand : Notifiable, ICommand
    {
        public CreateListStudentsCommand() { }
        public CreateListStudentsCommand(List<AlunoViewModel> alunos) => Alunos = alunos;
        public List<AlunoViewModel> Alunos { get; private set; }

        public void Validate()
        {
            // Method intentionally left empty.
        }
    }
}