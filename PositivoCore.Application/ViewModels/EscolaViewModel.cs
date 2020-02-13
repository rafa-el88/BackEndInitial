using System;
using PositivoCore.Domain.Enums;

namespace PositivoCore.Application.ViewModels
{
    public class EscolaViewModel
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string? RazaoSocial { get; set; }
        public string? INEP { get; set; }
        public string? INEPDescricao { get; set; }
        public string? InscricaoEstadual { get; set; }
        public string? CodSGE { get; set; }
        public TipoEscola? TipoEscola { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
