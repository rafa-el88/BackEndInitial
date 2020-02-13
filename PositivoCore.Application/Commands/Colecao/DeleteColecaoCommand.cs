using Flunt.Notifications;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands
{
    public class DeleteColecaoCommand : Notifiable, ICommand
    {
        public DeleteColecaoCommand(Guid id)
        {
            Id = id;
        }
        public DeleteColecaoCommand() { }

        public Guid Id { get; set; }

        public void Validate()
        {
            // Method intentionally left empty.
        }
    }
}