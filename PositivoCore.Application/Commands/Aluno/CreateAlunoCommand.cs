using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Domain.Enums;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands
{
    public class CreateAlunoCommand : Notifiable, ICommand
    {
        public CreateAlunoCommand() { }

        public CreateAlunoCommand(string nome, string email, string cpf, string matricula, string apelido, DateTime? dataNascimento, EGenero? genero)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Matricula = matricula;
            Apelido = apelido;
            DataNascimento = dataNascimento;
            Genero = genero;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Matricula { get; set; }
        public string Apelido { get; set; }
        public DateTime? DataNascimento { get; set; }
        public EGenero? Genero { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Nome, 100, "Nome", "Nome deve conter no m�ximo 100 caracteres")
                .HasMaxLengthIfNotNullOrEmpty(Email, 200, "Email", "Email deve conter no m�ximo 200 caracteres")
                .HasMaxLengthIfNotNullOrEmpty(Matricula, 20, "Matricula", "Matricula deve conter no m�ximo 20 caracteres")
                .HasMaxLengthIfNotNullOrEmpty(Apelido, 20, "Apelido", "Apelido deve conter no m�ximo 20 caracteres")
            );
        }
    }
}