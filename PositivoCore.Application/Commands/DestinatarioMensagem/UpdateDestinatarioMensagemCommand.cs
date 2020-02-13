using Flunt.Notifications;
using PositivoCore.Domain.Enums;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands
{
    public class UpdateDestinatarioMensagemCommand : Notifiable, ICommand
    {
        public UpdateDestinatarioMensagemCommand() { }

        public UpdateDestinatarioMensagemCommand(Guid id, ETipoPerfil tipoPerfil, Guid idDestinatario, Guid idMensagem)
        {
            Id = id;
            TipoPerfil = tipoPerfil;
            IdDestinatario = idDestinatario;
            IdMensagem = idMensagem;
        }

        public Guid Id { get; set; }
        public ETipoPerfil TipoPerfil { get; set; }
        public Guid IdDestinatario { get; set; }
        public Guid IdMensagem { get;  set; }

        public void Validate()
        {
            //
        }
    }
}