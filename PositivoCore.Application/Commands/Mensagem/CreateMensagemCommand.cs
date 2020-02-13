using Flunt.Notifications;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands
{
    public class CreateMensagemCommand : Notifiable, ICommand
    {
        public CreateMensagemCommand() { }

        public CreateMensagemCommand(string assunto, string texto, bool permiteResposta, Guid? idMensagemVinculada)
        {
            Assunto = assunto;
            Texto = texto;
            PermiteResposta = permiteResposta;
            IdMensagemVinculada = idMensagemVinculada;
        }

        public string Assunto { get; set; }
        public string Texto { get; set; }
        public bool PermiteResposta { get; set; }
        public Guid? IdMensagemVinculada { get; set; }


        public void Validate()
        {
            // Method intentionally left empty.
        }
    }
}