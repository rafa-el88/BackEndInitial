

using Flunt.Notifications;
using PositivoCore.Shared.Commands;
using System;

namespace PositivoCore.Application.Commands.Responsavel
{
	public class DeleteResponsavelCommand : Notifiable, ICommand
	{
		public DeleteResponsavelCommand(Guid id) => Id = id;
		public DeleteResponsavelCommand() { }
		public Guid Id { get; set; }
		public void Validate() {}
	}
}
