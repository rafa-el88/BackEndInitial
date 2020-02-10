using Flunt.Notifications;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands
{
    public class DeleteSerieCommand : Notifiable, ICommand
    {
        public DeleteSerieCommand(Guid id)
        {
            Id = id;
        }
        public DeleteSerieCommand() { }

        public Guid Id { get; set; }

        public void Validate()
        {
            // Method intentionally left empty.
        }
    }
}