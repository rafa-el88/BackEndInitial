using Flunt.Notifications;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands
{
    public class DeleteProfessorCommand : Notifiable, ICommand
    {
        public DeleteProfessorCommand(Guid id)
        {
            Id = id;
        }
        public DeleteProfessorCommand() { }

        public Guid Id { get; set; }

        public void Validate()
        {
            // Method intentionally left empty.
        }
    }
}