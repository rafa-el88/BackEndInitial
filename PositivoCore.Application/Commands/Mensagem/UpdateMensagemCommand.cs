using System;
using Flunt.Notifications;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands
{
    public class UpdateMensagemCommand : Notifiable, ICommand
    {
        public UpdateMensagemCommand() { }

        public UpdateMensagemCommand(Guid id, string assunto, string texto, bool permiteResposta, Guid idMensagemVinculada)
        {
            Id = id;
            Assunto = assunto;
            Texto = texto;
            PermiteResposta = permiteResposta;
            IdMensagemVinculada = idMensagemVinculada;
        }

        public Guid Id { get; set; }
        public string Assunto { get; set; }
        public string Texto { get; set; }
        public bool PermiteResposta { get; set; }
        public Guid IdMensagemVinculada { get; set; }
        public void Validate()
        {
            // Method intentionally left empty.
        }
    }
}