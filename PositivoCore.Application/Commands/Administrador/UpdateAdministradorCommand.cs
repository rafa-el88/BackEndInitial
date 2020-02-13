using System;
using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Domain.Enums;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands
{
    public class UpdateAdministradorCommand : Notifiable, ICommand
    {
        public UpdateAdministradorCommand(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public UpdateAdministradorCommand() { }

        public UpdateAdministradorCommand(Guid id, string nome, string email, string cpf, DateTime? dataNascimento, EGenero genero)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Genero = genero;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
        public EGenero Genero { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Nome, 100, "Nome", "Nome deve conter no m�ximo 100 caracteres")
                .HasMaxLengthIfNotNullOrEmpty(Email, 200, "Email", "Email deve conter no m�ximo 200 caracteres")
            );
        }
    }
}