using PositivoCore.Shared.Entities;
using System;
using System.Collections.Generic;

namespace PositivoCore.Domain.Entities
{
    public class Disciplina : Entity
    {
        public Disciplina(Guid id)
        {
            Id = id;
        }
        public Disciplina(string nome)
        {
            Nome = nome;
        }
        public Disciplina()
        {

        }
        public string Nome { get; private set; }

        public void UpdateNome(string nome)
        {
            Nome = nome;
        }

        public virtual ICollection<TurmaDisciplinaProfessor> TurmasDisciplinasProfessores { get; set; }

    }
}
