using System;
using Flunt.Notifications;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands.ConvidadosEventos
{
    public class DeleteConvidadosEventoCommand : Notifiable, ICommand
    {
        public DeleteConvidadosEventoCommand(Guid id) => Id = id;
        public Guid Id { get; set; }
        public void Validate() { }
    }
}