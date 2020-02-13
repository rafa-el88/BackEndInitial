using Flunt.Notifications;
using PositivoCore.Domain.Enums;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands
{
    public class CreateDestinatarioMensagemCommand : Notifiable, ICommand
    {
        public CreateDestinatarioMensagemCommand() { }

        public CreateDestinatarioMensagemCommand(ETipoPerfil tipoPerfil, Guid idDestinatario, Guid idMensagem)
        {
            TipoPerfil = tipoPerfil;
            IdDestinatario = idDestinatario;
            IdMensagem = idMensagem;
        }

        public ETipoPerfil TipoPerfil { get; set; }
        public Guid IdDestinatario { get; set; }
        public Guid IdMensagem { get;  set; }

        public void Validate()
        {
            //
        }
    }
}