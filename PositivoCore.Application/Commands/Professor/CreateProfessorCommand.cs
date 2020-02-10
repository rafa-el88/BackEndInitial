using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands
{
    public class CreateProfessorCommand : Notifiable, ICommand
    {
        public CreateProfessorCommand(string nome, string cpf)
        {
            Nome = nome;
            CPF = cpf;
        }
        public CreateProfessorCommand() { }
        
        public string Nome { get; set; }
        public string CPF { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(CPF, 11, "CPF", "CPF deve conter até 11 caracteres")
            );
        }
    }
}