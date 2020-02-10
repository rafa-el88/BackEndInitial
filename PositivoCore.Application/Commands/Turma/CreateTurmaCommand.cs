using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands
{
    public class CreateTurmaCommand : Notifiable, ICommand
    {
        public CreateTurmaCommand(string nome, Guid idEscola, Guid idSerie)
        {
            Nome = nome;
            IdEscola = idEscola;
            IdSerie = idSerie;
        }
        public CreateTurmaCommand() { }

        public string Nome { get;  set; }
        public Guid IdEscola { get; set; }
        public Guid IdSerie { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres")
            );
        }
    }
}