using System;

namespace PositivoCore.Application.ViewModels
{
    public class EscolaViewModel
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
