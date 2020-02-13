using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands
{
    public class CreatePeriodoCommand : Notifiable, ICommand
    {
        public CreatePeriodoCommand() { }

        public CreatePeriodoCommand(string nome, Guid idPeriodoLetivoTipo)
        {
            Nome = nome;
            IdPeriodoLetivoTipo = idPeriodoLetivoTipo;
        }

        public string Nome { get; set; }
        public Guid IdPeriodoLetivoTipo { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMaxLen(Nome, 20, "Nome", "Nome deve conter no máximo 20 caracteres")
            );
        }
    }
}