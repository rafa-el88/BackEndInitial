using PositivoCore.Shared.Entities;
using System;
using System.Collections.Generic;

namespace PositivoCore.Domain.Entities
{
    public class Serie : Entity
    {
        public Serie(Guid id)
        {
            Id = id;
        }
        public Serie(string nome, Guid idNivelEnsino)
        {
            Nome = nome;
            IdNivelEnsino = idNivelEnsino;
        }
        public Serie()
        {
        }

        public string Nome { get; private set; }
        public Guid IdNivelEnsino { get; private set; }

        public virtual NivelEnsino NivelEnsino { get; set; }
        public void UpdateNome(string nome)
        {
            Nome = nome;
        }
        public virtual List<Turma> Turmas { get; set; }
    }
}
