using Flunt.Notifications;
using System;

namespace PositivoCore.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            DataCadastro = DateTime.UtcNow;
            DataAtualizacao = DateTime.UtcNow;
            Ativo = true;
        }

        public Guid Id { get; protected set; }        
        public DateTime DataCadastro { get; protected set; }
        public DateTime DataAtualizacao { get; protected set; }
        public bool Ativo { get; protected set; }

        public void AtualizaDataAtualizacao()
        {
            DataAtualizacao = DateTime.UtcNow;
        }        
    }
}
