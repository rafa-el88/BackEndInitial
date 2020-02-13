using Flunt.Notifications;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands
{
    public class DeletePeriodoLetivoConfiguracaoCommand : Notifiable, ICommand
    {
        public DeletePeriodoLetivoConfiguracaoCommand(Guid id)
        {
            Id = id;
        }
        public DeletePeriodoLetivoConfiguracaoCommand() { }

        public Guid Id { get; set; }

        public void Validate()
        {
            // Method intentionally left empty.
        }
    }
}