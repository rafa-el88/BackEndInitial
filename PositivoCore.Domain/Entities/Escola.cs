using PositivoCore.Domain.Enums;
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

        public Escola(
            string nome,
            CNPJ cnpj,
            string? razaoSocial,
            string? iNEP,
            string? inscricaoEstadual,
            string? codSGE,
            TipoEscola? tipoEscola,
            List<Turma>? turmas) : this(nome, cnpj)
        {
            RazaoSocial = razaoSocial;
            INEP = iNEP;
            InscricaoEstadual = inscricaoEstadual;
            CodSGE = codSGE;
            TipoEscola = tipoEscola;
            Turmas = turmas;
        }

        public string Nome { get; private set; }
        public CNPJ CNPJ { get; private set; }
        public string? RazaoSocial { get; set; }
        public string? INEP { get; set; }
        public string? INEPDescricao { get; set; }
        public string? InscricaoEstadual { get; set; }
        public string? CodSGE { get; set; }
        public TipoEscola? TipoEscola { get; set; }
        public virtual List<Turma> Turmas { get; set; }
        public void UpdateNome(string nome) => Nome = nome;
        public virtual List<PeriodoLetivoConfiguracao> PeriodoLetivoConfiguracoes { get; set; }

    }
}
