using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands
{
    public class CreateDisciplinaCommand : Notifiable, ICommand
    {
        public CreateDisciplinaCommand(string nome)
        {
            Nome = nome;
        }
        public CreateDisciplinaCommand() { }

        public string Nome { get;  set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "Disciplina deve conter pelo menos 3 caracteres")
            );
        }
    }
}