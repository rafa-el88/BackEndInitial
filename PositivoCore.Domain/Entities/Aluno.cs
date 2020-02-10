using PositivoCore.Shared.Entities;
using System;

namespace PositivoCore.Domain.Entities
{
    public class Aluno : Entity
    {
        public Aluno(Guid id)
        {
            Id = id;
        }

        public Aluno(string nome)
        {
            Nome = nome;
        }

        protected Aluno() { }

        public string Nome { get; private set; }

        public void UpdateNome(string nome)
        {
            Nome = nome;
        }
    }
}
