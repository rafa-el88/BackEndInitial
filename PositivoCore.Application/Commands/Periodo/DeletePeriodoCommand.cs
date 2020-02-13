using Flunt.Notifications;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands
{
    public class DeletePeriodoCommand : Notifiable, ICommand
    {
        public DeletePeriodoCommand(Guid id)
        {
            Id = id;
        }
        public DeletePeriodoCommand() { }

        public Guid Id { get; set; }

        public void Validate()
        {
            // Method intentionally left empty.
        }
    }
}