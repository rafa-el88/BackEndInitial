using PositivoCore.Shared.Entities;
using System;
using System.Collections.Generic;

namespace PositivoCore.Domain.Entities
{
    public class NivelEnsino : Entity
    {
        public NivelEnsino(Guid id)
        {
            Id = id;
        }
        public NivelEnsino(string nome)
        {
            Nome = nome;
        }
        public NivelEnsino()
        {

        }
        public string Nome { get; private set; }


        public void UpdateNome(string nome)
        {
            Nome = nome;
        }
        public virtual List<Serie> Series { get; set; }
    }
}
