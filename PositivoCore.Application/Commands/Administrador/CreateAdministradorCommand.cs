using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Domain.Enums;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands
{
    public class CreateAdministradorCommand : Notifiable, ICommand
    {
        public CreateAdministradorCommand() { }

        public CreateAdministradorCommand(string nome, string email, string cpf, DateTime? dataNascimento, EGenero? genero)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Genero = genero;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
        public EGenero? Genero { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Nome, 100, "Nome", "Nome deve conter no máximo 100 caracteres")
                .HasMaxLengthIfNotNullOrEmpty(Email, 200, "Email", "Email deve conter no máximo 200 caracteres")
            );
        }
    }
}