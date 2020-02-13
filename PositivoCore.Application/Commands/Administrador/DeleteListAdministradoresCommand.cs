using Flunt.Notifications;
using PositivoCore.Shared.Commands;
using System;
using System.Collections.Generic;

namespace PositivoCore.Application.Commands
{
    public class DeleteListAdministradoresCommand : Notifiable, ICommand
    {
        public DeleteListAdministradoresCommand() { }
        public DeleteListAdministradoresCommand(List<Guid> id) => Id = id;
        public List<Guid> Id { get; private set; }
        
        public void Validate()
        {
            // Method intentionally left empty.
        }
    }
}
