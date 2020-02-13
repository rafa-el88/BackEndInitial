using PositivoCore.Shared.Entities;
using System;
using System.Collections.Generic;

namespace PositivoCore.Domain.Entities
{
    public class Mensagem : Entity
    {
        public Mensagem(Guid id)
        {
            Id = id;
        }

        protected Mensagem() { }

        public string Assunto { get; private set; }
        public string Texto { get; private set; }
        public bool PermiteResposta { get; private set; }
        public Guid? IdMensagemVinculada { get; private set; }

        public virtual Mensagem MensagemVinculada { get; set; }

        public virtual List<Mensagem> MensagemVinculadas { get; set; }

        public virtual List<DestinatarioMensagem> DestinatarioMensagens { get; set; }

        public void UpdateFields(Mensagem fields)
        {
            Assunto = fields.Assunto;
            Texto = fields.Texto;
            PermiteResposta = fields.PermiteResposta;
            IdMensagemVinculada = fields.IdMensagemVinculada;
        }
    }
}
