using Flunt.Notifications;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands
{
    public class DeleteDisciplinaCommand : Notifiable, ICommand
    {
        public DeleteDisciplinaCommand(Guid id)
        {
            Id = id;
        }
        public DeleteDisciplinaCommand() { }

        public Guid Id { get; set; }

        public void Validate()
        {
            // Method intentionally left empty.
        }
    }
}