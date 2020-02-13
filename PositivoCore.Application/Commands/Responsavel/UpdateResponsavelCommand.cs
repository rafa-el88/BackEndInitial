using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands.Responsavel
{
    public class UpdateResponsavelCommand : Notifiable, ICommand
    {
        public UpdateResponsavelCommand() { }

        public UpdateResponsavelCommand(Guid id, string nome)
        {
            Nome = nome;
            Id = id;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string CPF { get; set; }
        public Guid Id { get; set; }
        public void Validate() {}
    }
}
