using Flunt.Notifications;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands
{
    public class DeletePeriodoLetivoTipoCommand : Notifiable, ICommand
    {
        public DeletePeriodoLetivoTipoCommand(Guid id)
        {
            Id = id;
        }
        public DeletePeriodoLetivoTipoCommand() { }

        public Guid Id { get; set; }

        public void Validate()
        {
            // Method intentionally left empty.
        }
    }
}