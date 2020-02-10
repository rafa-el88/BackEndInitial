using System;
using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands
{
    public class UpdateEscolaCommand : Notifiable, ICommand
    {
        public UpdateEscolaCommand(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public UpdateEscolaCommand() { }

        public string Nome { get; set; }
        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "Escola deve conter pelo menos 3 caracteres")
            );
        }
    }
}