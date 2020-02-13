using PositivoCore.Shared.Entities;
using System;

namespace PositivoCore.Domain.Entities
{
    public class Administrador : Entity
    {
        public Administrador(Guid id)
        {
            Id = id;
        }

        public Administrador(string nome, string email, string cpf, DateTime? dataNascimento, int? genero)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Genero = genero;
        }

        protected Administrador() { }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public int? Genero { get; private set; }

        public void UpdateFields(Administrador fields)
        {
            Nome = fields.Nome;
            Email = fields.Email;
            Cpf = fields.Cpf;
            DataNascimento = fields.DataNascimento;
            Genero = fields.Genero;
        }
    }
}
