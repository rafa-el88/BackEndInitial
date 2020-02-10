using System;
using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands
{
    public class UpdateNivelEnsinoCommand : Notifiable, ICommand
    {
        public UpdateNivelEnsinoCommand()
        {
        }

        public UpdateNivelEnsinoCommand(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        public Guid Id { get; set; }
        public String Nome { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "Disciplina deve conter pelo menos 3 caracteres")
                .HasMaxLen(Nome, 20, "Nome", "Disciplina deve conter no máximo 20 caracteres")
                );
        }
    }
}