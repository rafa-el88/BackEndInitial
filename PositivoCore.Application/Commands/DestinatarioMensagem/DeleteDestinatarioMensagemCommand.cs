using Flunt.Notifications;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands
{
    public class DeleteDestinatarioMensagemCommand : Notifiable, ICommand
    {
        public DeleteDestinatarioMensagemCommand(Guid id)
        {
            Id = id;
        }
        public DeleteDestinatarioMensagemCommand() { }

        public Guid Id { get; set; }

        public void Validate()
        {
            // Method intentionally left empty.
        }
    }
}