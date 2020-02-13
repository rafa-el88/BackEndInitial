using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands
{
    public class CreateColecaoCommand : Notifiable, ICommand
    {
        public CreateColecaoCommand() { }

        public CreateColecaoCommand(string nome, bool padrao)
        {
            Nome = nome;
            Padrao = padrao;
        }

        public string Nome { get; set; }
        public bool Padrao { get; set; }

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