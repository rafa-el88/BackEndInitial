using System.Collections.Generic;
using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Domain.Entities;
using PositivoCore.Domain.Enums;
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
        public string RazaoSocial { get; set; }
        public string INEP { get; set; }
        public string INEPDescricao { get; set; }
        public string InscricaoEstadual { get; set; }
        public string CodSGE { get; set; }
        public TipoEscola TipoEscola { get; set; }
        public virtual List<Turma> Turmas { get; set; }
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