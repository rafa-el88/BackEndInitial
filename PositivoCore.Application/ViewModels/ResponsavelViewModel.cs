using System;

namespace PositivoCore.Application.ViewModels
{
    public class ResponsavelViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; private set; }
        public string Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string CPF { get; set; }
        public bool Ativo { get; private set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}