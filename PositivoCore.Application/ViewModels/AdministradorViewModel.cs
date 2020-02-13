using PositivoCore.Domain.Enums;
using System;

namespace PositivoCore.Application.ViewModels
{
    public class AdministradorViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public EGenero Genero { get; private set; }
    }
}
