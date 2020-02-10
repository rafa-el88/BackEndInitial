using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands
{
    public class CreateEscolaCommand : Notifiable, ICommand
    {
        public CreateEscolaCommand(string nome, string cnpj)
        {
            Nome = nome;
            CNPJ = cnpj;
        }
        public CreateEscolaCommand() { }

        public string Nome { get; set; }
        public string CNPJ { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres")
                .HasLen(CNPJ, 14, "CNPJ", "CNPJ deve conter até 14 caracteres")
            );
        }
    }
}