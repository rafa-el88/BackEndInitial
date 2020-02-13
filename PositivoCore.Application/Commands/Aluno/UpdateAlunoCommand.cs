using System;
using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Domain.Enums;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands
{
    public class UpdateAlunoCommand : Notifiable, ICommand
    {
        public UpdateAlunoCommand(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public UpdateAlunoCommand() { }

        public UpdateAlunoCommand(Guid id, string nome, string email, string cpf, string matricula, string apelido, DateTime? dataNascimento, EGenero genero)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Matricula = matricula;
            Apelido = apelido;
            DataNascimento = dataNascimento;
            Genero = genero;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Matricula { get; set; }
        public string Apelido { get; set; }
        public DateTime? DataNascimento { get; set; }
        public EGenero Genero { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Nome, 100, "Nome", "Nome deve conter no máximo 100 caracteres")
                .HasMaxLengthIfNotNullOrEmpty(Email, 200, "Email", "Email deve conter no máximo 200 caracteres")
                .HasMaxLengthIfNotNullOrEmpty(Matricula, 20, "Matricula", "Matricula deve conter no máximo 20 caracteres")
                .HasMaxLengthIfNotNullOrEmpty(Apelido, 20, "Apelido", "Apelido deve conter no máximo 20 caracteres")
            );
        }
    }
}