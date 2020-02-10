using System.Collections.Generic;
using Flunt.Notifications;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands
{
    public class AttachTurmaDisciplinaProfessorCommand : Notifiable, ICommand
    {
        public AttachTurmaDisciplinaProfessorCommand(List<TurmaDisciplinaProfessorViewModel> turmasDisciplinasProfessores)
        {
            TurmasDisciplinasProfessores = turmasDisciplinasProfessores;
        }
        public AttachTurmaDisciplinaProfessorCommand() { }

        public List<TurmaDisciplinaProfessorViewModel> TurmasDisciplinasProfessores { get; private set; }

        public void Validate()
        {
            // Method intentionally left empty.
        }
    }
}