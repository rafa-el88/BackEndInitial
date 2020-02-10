using System;
using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands
{
    public class UpdateSerieCommand : Notifiable, ICommand
    {
        public UpdateSerieCommand(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public UpdateSerieCommand() { }

        public Guid Id { get; set; }
        public string Nome { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres")
                );
        }
    }
}