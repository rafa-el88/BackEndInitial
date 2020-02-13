using System;

namespace PositivoCore.Application.ViewModels
{
    public class MensagemViewModel
    {
        public Guid Id { get; set; }
        public string Assunto { get; set; }
        public string Texto { get; set; }
        public bool PermiteResposta { get; set; }
        public Guid IdMensagemVinculada { get; set; }
    }
}
