using Flunt.Notifications;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Commands;
using System.Collections.Generic;

namespace PositivoCore.Application.Commands
{
    public class CreateEscolasCommand : Notifiable, ICommand
    {
        public CreateEscolasCommand(List<EscolaViewModel> escolas) => Escolas = escolas;

        public CreateEscolasCommand() { }

        public List<EscolaViewModel> Escolas { get; private set; }

        public void Validate()
        {
            // Method intentionally left empty.
        }
    }
}