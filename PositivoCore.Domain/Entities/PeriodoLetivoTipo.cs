using PositivoCore.Shared.Entities;
using System;
using System.Collections.Generic;

namespace PositivoCore.Domain.Entities
{
    public class PeriodoLetivoTipo : Entity
    {
        public PeriodoLetivoTipo(Guid id)
        {
            Id = id;
        }

        public PeriodoLetivoTipo(string nome)
        {
            Nome = nome;
        }
        public PeriodoLetivoTipo(){                
        }       

        public string Nome { get; private set; }
        public virtual List<Periodo> Periodos { get; set; }
        public virtual List<PeriodoLetivoConfiguracao> PeriodoLetivoConfiguracoes { get; set; }

        public void UpdateFields(PeriodoLetivoTipo fields)
        {
            Nome = fields.Nome;
        }
    }
}
