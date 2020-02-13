using PositivoCore.Shared.Entities;
using System;

namespace PositivoCore.Domain.Entities
{
    public class Responsavel : Entity
    {
        public Responsavel() { }

        public Responsavel(string nome) => Nome = nome;
        public Responsavel(Guid id) => Id = id;
        public Responsavel(string nome, string email, DateTime? dataNascimento, string cPF) : this(nome)
        {
            Email = email;
            DataNascimento = dataNascimento;
            CPF = cPF;
        }

        public string Nome { get; private set; }
        public string Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string CPF { get; set; }
        public void UpdateNome(string nome) => Nome = nome;

    }
}
