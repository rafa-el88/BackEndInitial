using PositivoCore.Shared.Entities;
using System;
using System.Collections.Generic;

namespace PositivoCore.Domain.Entities
{
    public class Turma : Entity
    {
        public Turma(Guid id)
        {
            Id = id;
        }
        public Turma(string nome, Guid idEscola, Guid idSerie)
        {
            Nome = nome;
            IdEscola = idEscola;
            IdSerie = idSerie;
        }
        public Turma()
        {
        }

        public string Nome { get; private set; }
        public Guid IdEscola { get; private set; }
        public Guid IdSerie { get; private set; }

        public virtual Escola Escola { get; set; }
        public virtual Serie Serie { get; set; }

        public virtual ICollection<TurmaDisciplinaProfessor> TurmasDisciplinasProfessores { get; set; }

        public void UpdateNome(string nome)
        {
            Nome = nome;
        }

    }
}
