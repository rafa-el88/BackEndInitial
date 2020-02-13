using System;
using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Domain.Enums;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands.ConvidadosEventos
{
    public class CreateConvidadosEventoCommand : Notifiable, ICommand
    {
        public CreateConvidadosEventoCommand() { }
        public CreateConvidadosEventoCommand(string nome, TipoPerfil tipoPerfil, Guid idConvidado)
        {
            Nome = nome;
            TipoPerfil = tipoPerfil;
            IdConvidado = idConvidado;
        }
        public string Nome { get; set; }
        public TipoPerfil TipoPerfil { get; set; }
        public Guid IdConvidado { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "Convidado deve conter pelo menos 3 caracteres")
            );
        }
    }
}