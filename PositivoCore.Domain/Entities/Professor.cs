using PositivoCore.Shared.Entities;
using System;
using System.Collections.Generic;

namespace PositivoCore.Domain.Entities
{
    public class Professor : Entity
    {
        public Professor(Guid id)
        {
            Id = id;
        }

        public Professor(string nome, string cpf)
        {
            Nome = nome;
            CPF = cpf;
        }

        protected Professor() { }

        public string Nome { get; private set; }
        public string CPF { get; private set; }

        public void UpdateNome(string nome)
        {
            Nome = nome;
        }

        public virtual ICollection<TurmaDisciplinaProfessor> TurmasDisciplinasProfessores { get; set; }
        
    }
}
