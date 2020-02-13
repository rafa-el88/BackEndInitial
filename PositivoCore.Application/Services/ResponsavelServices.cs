

using AutoMapper;
using PositivoCore.Application.Commands.Responsavel;
using PositivoCore.Application.Interface.Services;
using PositivoCore.Application.Queries;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Commands;
using PositivoCore.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Services
{
	public class ResponsavelServices : IResponsavelServices
	{
		private readonly IResponsavelQuery _responsavelQuery;
		private readonly IMapper _mapper;
		private readonly IHandler<CreateResponsavelCommand> _handlerCreateResponsavel;
		private readonly IHandler<UpdateResponsavelCommand> _handlerUpdateResponsavel;
		private readonly IHandler<DeleteResponsavelCommand> _handlerDeleteResponsavel;

		public ResponsavelServices(
			IMapper mapper,
			IResponsavelQuery responsavelQuery,
			IHandler<CreateResponsavelCommand> handlerCreateResponsavel, 
			IHandler<UpdateResponsavelCommand> handlerUpdateResponsavel, 
			IHandler<DeleteResponsavelCommand> handlerDeleteResponsavel)
		{
			_mapper = mapper;
			_responsavelQuery = responsavelQuery;
			_handlerCreateResponsavel = handlerCreateResponsavel;
			_handlerUpdateResponsavel = handlerUpdateResponsavel;
			_handlerDeleteResponsavel = handlerDeleteResponsavel;
		}

		public async Task<ICommandResult> DeleteResponsavel(Guid idResponsavel)
		{
			DeleteResponsavelCommand command = new DeleteResponsavelCommand(idResponsavel);
			return await _handlerDeleteResponsavel.Handle(command);
		}

		public async Task<IEnumerable<ResponsavelViewModel>> GetAllResponsavels()
		{
			return _mapper.Map<IEnumerable<ResponsavelViewModel>>(await _responsavelQuery.GetAllResponsavel());
		}

		public async Task<ResponsavelViewModel> GetResponsavelById(Guid idResponsavel)
		{
			return _mapper.Map<ResponsavelViewModel>(await _responsavelQuery.GetResponsavelPorId(idResponsavel));
		}

		public async Task<IEnumerable<ResponsavelViewModel>> GetResponsavelByNome(string nome)
		{
			return _mapper.Map<IEnumerable<ResponsavelViewModel>>(await _responsavelQuery.GetResponsavelPorNome(nome));
		}

		public async  Task<ICommandResult> NewResponsavel(CreateResponsavelCommand command)
		{
			return await _handlerCreateResponsavel.Handle(command);
		}

		public async Task<ICommandResult> UpdateResponsavel(UpdateResponsavelCommand command)
		{
			return await _handlerUpdateResponsavel.Handle(command);
		}
	}
}
