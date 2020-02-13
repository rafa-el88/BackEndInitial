using System;
using PositivoCore.Domain.Enums;
using PositivoCore.Shared.Entities;

namespace PositivoCore.Domain.Entities
{
    public class ConvidadosEvento : Entity
    {
        protected ConvidadosEvento() { }
        public ConvidadosEvento(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        public ConvidadosEvento(string nome, TipoPerfil tipoPerfil, Guid idConvidado)
        {
            Nome = nome;
            TipoPerfil = tipoPerfil;
            IdConvidado = idConvidado;
        }
        public string Nome { get; set; }
        public TipoPerfil TipoPerfil { get; set; }
        public Guid IdConvidado { get; set; }

        public void Update(string nome)
        {
            Nome = nome;
        }
    }
}