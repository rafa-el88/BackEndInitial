using PositivoCore.Domain.Enums;
using System;

namespace PositivoCore.Application.ViewModels
{
    public class AlunoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public string Matricula { get; private set; }
        public string Apelido { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public EGenero Genero { get; private set; }
    }
}
