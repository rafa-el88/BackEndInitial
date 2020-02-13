using PositivoCore.Shared.Entities;
using System;

namespace PositivoCore.Domain.Entities
{
    public class Aluno : Entity
    {
        public Aluno(Guid id)
        {
            Id = id;
        }

        public Aluno(string nome, string email, string cpf, string matricula, string apelido, DateTime? dataNascimento, int? genero)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Matricula = matricula;
            Apelido = apelido;
            DataNascimento = dataNascimento;
            Genero = genero;
        }

        protected Aluno() { }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public string Matricula { get; private set; }
        public string Apelido { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public int? Genero { get; private set; }

        public void UpdateFields(Aluno fields)
        {
            Nome = fields.Nome;
            Email = fields.Email;
            Cpf = fields.Cpf;
            Matricula = fields.Matricula;
            Apelido = fields.Apelido;
            DataNascimento = fields.DataNascimento;
            Genero = fields.Genero;
        }
    }
}
