using System;

namespace PositivoCore.Shared.Entities
{
    public abstract class JoinEntity
    {
        protected JoinEntity()
        {
            DataCadastro = DateTime.UtcNow;
            DataAtualizacao = DateTime.UtcNow;
            Ativo = true;
        }

        public DateTime DataCadastro { get; protected set; }
        public DateTime DataAtualizacao { get; protected set; }
        public bool Ativo { get; protected set; }

        public void AtualizaDataAtualizacao()
        {
            DataAtualizacao = DateTime.UtcNow;
        }
    }
}
