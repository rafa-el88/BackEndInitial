using System;
using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands
{
    public class UpdatePeriodoCommand : Notifiable, ICommand
    {
        public UpdatePeriodoCommand() { }

        public UpdatePeriodoCommand(Guid id, string nome, Guid idPeriodoLetivoTipo)
        {
            Id = id;
            Nome = nome;
            IdPeriodoLetivoTipo = idPeriodoLetivoTipo;
        }

        public Guid Id { get; set; }
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