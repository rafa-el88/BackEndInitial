using PositivoCore.Shared.Entities;
using System;
using System.Collections.Generic;

namespace PositivoCore.Domain.Entities
{
    public class Periodo: Entity
    {
        public Periodo()
        {
                
        }
        public Periodo(string nome, Guid idPeriodoLetivoTipo)
        {
            Nome = nome;
            IdPeriodoLetivoTipo = idPeriodoLetivoTipo;
        }

        public string Nome { get; private set; }
        public Guid IdPeriodoLetivoTipo { get; private set; }
        public virtual PeriodoLetivoTipo PeriodoLetivoTipo { get; private set; }
        public virtual List<PeriodoLetivoConfiguracao> PeriodoLetivoConfiguracoes { get; set; }

        public void UpdateFields(Periodo fields)
        {
            Nome = fields.Nome;
            IdPeriodoLetivoTipo = fields.IdPeriodoLetivoTipo;
        }

    }
}
