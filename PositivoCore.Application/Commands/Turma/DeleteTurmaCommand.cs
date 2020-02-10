using Flunt.Notifications;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands
{
    public class DeleteTurmaCommand : Notifiable, ICommand
    {
        public DeleteTurmaCommand(Guid id)
        {
            Id = id;
        }
        public DeleteTurmaCommand() { }

        public Guid Id { get; set; }

        public void Validate()
        {
            // Method intentionally left empty.
        }
    }
}