using System;
using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands
{
    public class UpdateDisiplinaCommand : Notifiable, ICommand
    {
        public UpdateDisiplinaCommand(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public UpdateDisiplinaCommand() { }

        public string Nome { get; set; }
        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres")
            );
        }
    }
}