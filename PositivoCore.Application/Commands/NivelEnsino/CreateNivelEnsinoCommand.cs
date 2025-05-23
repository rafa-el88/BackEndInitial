using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands
{
    public class CreateNivelEnsinoCommand : Notifiable, ICommand
    {
        public CreateNivelEnsinoCommand(string nome)
        {
            Nome = nome;
        }
        public CreateNivelEnsinoCommand() { }

        public string Nome { get;  set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres")
            );
        }
    }
}