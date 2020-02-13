using System;
using System.Collections.Generic;
using Flunt.Notifications;
using Flunt.Validations;
using PositivoCore.Domain.Entities;
using PositivoCore.Domain.Enums;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands
{
    public class UpdateEscolaCommand : Notifiable, ICommand
    {
        public UpdateEscolaCommand(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public UpdateEscolaCommand() { }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string INEP { get; set; }
        public string INEPDescricao { get; set; }
        public string InscricaoEstadual { get; set; }
        public string CodSGE { get; set; }
        public TipoEscola TipoEscola { get; set; }
        public Guid Id { get; set; }
        public virtual List<Turma> Turmas { get; set; }
        public void Validate() {}
    }
}