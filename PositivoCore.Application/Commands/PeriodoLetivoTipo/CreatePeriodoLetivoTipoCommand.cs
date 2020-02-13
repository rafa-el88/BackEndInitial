using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands
{
    public class CreatePeriodoLetivoTipoCommand : Notifiable, ICommand
    {
        public CreatePeriodoLetivoTipoCommand() { }

        public CreatePeriodoLetivoTipoCommand(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMaxLen(Nome, 30, "Nome", "Nome deve conter no máximo 30 caracteres")
            );
        }
    }
}