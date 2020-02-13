using System;
using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands.Responsavel
{
    public class CreateResponsavelCommand : Notifiable, ICommand
    {
        public CreateResponsavelCommand() { }
        public CreateResponsavelCommand(string nome, string email, DateTime dataNascimento, string cpf)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            CPF = cpf;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres")
            );
        }
    }
}
