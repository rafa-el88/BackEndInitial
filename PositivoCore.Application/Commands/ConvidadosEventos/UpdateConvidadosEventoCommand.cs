using System;
using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands.ConvidadosEventos
{
    public class UpdateConvidadosEventoCommand : Notifiable, ICommand
    {
        public UpdateConvidadosEventoCommand() {}

        public UpdateConvidadosEventoCommand(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "Disciplina deve conter pelo menos 3 caracteres")
            );
        }
    }
}