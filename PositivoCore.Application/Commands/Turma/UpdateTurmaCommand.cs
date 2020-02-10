using System;
using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands
{
    public class UpdateTurmaCommand : Notifiable, ICommand
    {
        public UpdateTurmaCommand(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public UpdateTurmaCommand() { }

        public Guid Id { get; set; }
        public string Nome { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 1, "Nome", "Nome deve conter pelo menos 1 caracteres")
                );
        }
    }
}