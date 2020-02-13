using System;
using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands
{
    public class UpdatePeriodoLetivoTipoCommand : Notifiable, ICommand
    {
        public UpdatePeriodoLetivoTipoCommand() { }

        public UpdatePeriodoLetivoTipoCommand(Guid id, string nome)
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
                .HasMinLen(Nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Nome, 100, "Nome", "Nome deve conter no máximo 100 caracteres")
            );
        }
    }
}