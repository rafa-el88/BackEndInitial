using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands
{
    public class CreateSerieCommand : Notifiable, ICommand
    {
        public CreateSerieCommand(string nome, Guid idNivelEnsino)
        {
            Nome = nome;
            IdNivelEnsino = idNivelEnsino;
        }
        public CreateSerieCommand() { }

        public string Nome { get;  set; }
        public Guid IdNivelEnsino { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres")
            );
        }
    }
}