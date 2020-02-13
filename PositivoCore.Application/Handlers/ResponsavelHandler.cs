

using AutoMapper;
using Flunt.Notifications;
using PositivoCore.Application.Commands;
using PositivoCore.Application.Commands.Responsavel;
using PositivoCore.Application.Interface.Repository;
using PositivoCore.Domain.Entities;
using PositivoCore.Shared.Commands;
using PositivoCore.Shared.Handlers;
using System.Threading.Tasks;

namespace PositivoCore.Application.Handlers
{
	public class ResponsavelHandler : Notifiable, 
		IHandler<CreateResponsavelCommand>, 
		IHandler<DeleteResponsavelCommand>, 
		IHandler<UpdateResponsavelCommand>
	{
		private readonly IResponsavelRepository _repository;
		private readonly IMapper _mapper;

		public ResponsavelHandler(IResponsavelRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<ICommandResult> Handle(CreateResponsavelCommand command)
		{
			command.Validate();
			if (command.Invalid)
				return new CommandResult(false, "...Ops!", null);

			var responsavel = new Responsavel(command.Nome, command.Email, command.DataNascimento, command.CPF);

			if (Invalid)
				return new CommandResult(false, "Ops...", Notifications);

			_repository.Insert(responsavel);
			return new CommandResult(true, "Responsável cadastrado com sucesso!", new 
			{
				responsavel.Id,
				responsavel.Nome,
				Cpf = responsavel.CPF,
				Email = responsavel.Email,
				DataNascimento = responsavel.DataNascimento,
				Status = responsavel.Ativo,
				Create = responsavel.DataCadastro
			});
		}

		public async Task<ICommandResult> Handle(DeleteResponsavelCommand command)
		{
			command.Validate();
			if (command.Invalid)
				return new CommandResult(false, "...Ops!", Notifications);

			var responsavel = await _repository.Find(command.Id);

			if (responsavel == null)
				AddNotification("Responsavel", "Não foi encontrado nenhum responsável vinculada a este id.");

			if (Invalid)
				return new CommandResult(false, "Ops...", Notifications);

			_repository.Delete(responsavel);

			return new CommandResult(true, "Responsável excluido com sucesso!", null);
		}

		public async Task<ICommandResult> Handle(UpdateResponsavelCommand command)
		{
			command.Validate();
			if (command.Invalid)
				return new CommandResult(false, "...Ops!", Notifications);

			var responsavel = await _repository.Find(command.Id);

			if (responsavel == null)
				AddNotification("Responsavel", "Não foi encontrado nenhum responsável vinculada a este id.");

			if (Invalid)
				return new CommandResult(false, "Ops...", Notifications);

			responsavel.UpdateNome(command.Nome);
			_repository.Update(responsavel);

			return new CommandResult(true, "Responsável atualizado com sucesso!", new
			{
				responsavel.Id,
				responsavel.Nome,
				Cpf = responsavel.CPF,
				Email = responsavel.Email,
				DataNascimento = responsavel.DataNascimento,
				Status = responsavel.Ativo,
				Updated = responsavel.DataAtualizacao
			});
		}
	}
}
