using Flunt.Notifications;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands
{
    public class DeleteAlunoCommand : Notifiable, ICommand
    {
        public DeleteAlunoCommand(Guid id)
        {
            Id = id;
        }
        public DeleteAlunoCommand() { }

        public Guid Id { get; set; }

        public void Validate()
        {
            // Method intentionally left empty.
        }
    }
}