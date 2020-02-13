using Flunt.Notifications;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands
{
    public class DeleteAdministradorCommand : Notifiable, ICommand
    {
        public DeleteAdministradorCommand(Guid id)
        {
            Id = id;
        }
        public DeleteAdministradorCommand() { }

        public Guid Id { get; set; }

        public void Validate()
        {
            // Method intentionally left empty.
        }
    }
}