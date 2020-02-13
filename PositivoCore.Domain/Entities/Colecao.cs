using PositivoCore.Shared.Entities;
using System;

namespace PositivoCore.Domain.Entities
{
    public class Colecao : Entity
    {
        public Colecao(Guid id)
        {
            Id = id;
        }

        protected Colecao() { }

        public string Nome { get; private set; }
        public bool Padrao { get; private set; }

        public void UpdateFields(Colecao fields)
        {
            Nome = fields.Nome;
            Padrao = fields.Padrao;
        }
    }
}
