using PositivoCore.Domain.ValueObjects;
using PositivoCore.Shared.Entities;
using System;
using System.Collections.Generic;

namespace PositivoCore.Domain.Entities
{
    public class Escola : Entity
    {
        public Escola(string nome, CNPJ cnpj)
        {
            Nome = nome;
            CNPJ = cnpj;
        }

        public Escola(Guid id) => Id = id;

        public Escola() { }

        public string Nome { get; private set; }
        public CNPJ CNPJ { get; private set; }

        public virtual List<Turma> Turmas { get; set; }

        public void UpdateNome(string nome) => Nome = nome;
    }
}
