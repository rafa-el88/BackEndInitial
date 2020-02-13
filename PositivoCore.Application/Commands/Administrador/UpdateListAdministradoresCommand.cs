using Flunt.Notifications;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Commands;
using System.Collections.Generic;

namespace PositivoCore.Application.Commands
{
    public class UpdateListAdministradoresCommand : Notifiable, ICommand
    {
        public UpdateListAdministradoresCommand() { }
        public UpdateListAdministradoresCommand(List<AdministradorViewModel> administradores) => Administradores = administradores;
        public List<AdministradorViewModel> Administradores { get; private set; }

        public void Validate()
        {
            // Method intentionally left empty.
        }
    }
}
