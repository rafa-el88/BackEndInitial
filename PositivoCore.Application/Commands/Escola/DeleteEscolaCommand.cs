using Flunt.Notifications;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands
{
    public class DeleteEscolaCommand : Notifiable, ICommand
    {
        public DeleteEscolaCommand(Guid id) => Id = id;

        public DeleteEscolaCommand() { }

        public Guid Id { get; set; }

        public void Validate()
        {
            // Method intentionally left empty.
        }
    }
}