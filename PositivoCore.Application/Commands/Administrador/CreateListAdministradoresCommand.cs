using System.Collections.Generic;
using Flunt.Notifications;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands
{
    public class CreateListAdministradoresCommand : Notifiable, ICommand
    {
        public CreateListAdministradoresCommand() { }
        public CreateListAdministradoresCommand(List<AdministradorViewModel> administradores) => Administradores = administradores;
        public List<AdministradorViewModel> Administradores { get; private set; }

        public void Validate()
        {
            // Method intentionally left empty.
        }
    }
}