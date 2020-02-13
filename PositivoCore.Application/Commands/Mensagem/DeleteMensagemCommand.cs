using Flunt.Notifications;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands
{
    public class DeleteMensagemCommand : Notifiable, ICommand
    {
        public DeleteMensagemCommand(Guid id)
        {
            Id = id;
        }
        public DeleteMensagemCommand() { }

        public Guid Id { get; set; }

        public void Validate()
        {
            // Method intentionally left empty.
        }
    }
}