using Flunt.Notifications;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands
{
    public class DeleteNivelEnsinoCommand : Notifiable, ICommand
    {
        public DeleteNivelEnsinoCommand(Guid id)
        {
            Id = id;
        }
        public DeleteNivelEnsinoCommand() { }
        
        public Guid Id { get; set; }

        public void Validate()
        {
            // Method intentionally left empty.
        }
    }
}