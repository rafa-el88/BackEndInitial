using PositivoCore.Domain.Enums;
using PositivoCore.Shared.Entities;
using System;

namespace PositivoCore.Domain.Entities
{
    public class DestinatarioMensagem : Entity
    {
        public DestinatarioMensagem(Guid id)
        {
            Id = id;
        }

        public DestinatarioMensagem(ETipoPerfil tipoPerfil, Guid idDestinatario, Guid idMensagem, Mensagem mensagem)
        {
            TipoPerfil = tipoPerfil;
            IdDestinatario = idDestinatario;
            IdMensagem = idMensagem;
            Mensagem = mensagem;
        }

        protected DestinatarioMensagem() { }

        public ETipoPerfil TipoPerfil { get; private set; }
        // IdDestinatario é referente ao o id da pessoa conforme o perfil. Id do administrador, aluno ou professor.
        public Guid IdDestinatario { get; private set; }
        public Guid IdMensagem { get; private set; }
        public virtual Mensagem Mensagem { get; set; }

        public void UpdateFields(DestinatarioMensagem fields)
        {
            //
        }
    }
}
