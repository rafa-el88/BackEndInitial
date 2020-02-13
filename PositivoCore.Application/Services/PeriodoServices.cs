using AutoMapper;
using PositivoCore.Application.Commands;
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
    public class PeriodoServices : IPeriodoServices
    {
        private readonly IPeriodoQuery _periodoQuery;
        private readonly IMapper _mapper;
        private readonly IHandler<CreatePeriodoCommand> _handlerCriarPeriodo;
        private readonly IHandler<DeletePeriodoCommand> _handlerDeletarPeriodo;
        private readonly IHandler<UpdatePeriodoCommand> _handlerEditarPeriodo;

        public PeriodoServices(IPeriodoQuery periodoQuery, IMapper mapper, IHandler<CreatePeriodoCommand> handlerCriarPeriodo, IHandler<DeletePeriodoCommand> handlerDeletarPeriodo, IHandler<UpdatePeriodoCommand> handlerEditarPeriodo)
        {
            _periodoQuery = periodoQuery;
            _mapper = mapper;
            _handlerCriarPeriodo = handlerCriarPeriodo;
            _handlerDeletarPeriodo = handlerDeletarPeriodo;
            _handlerEditarPeriodo = handlerEditarPeriodo;
        }

        public async Task<IEnumerable<PeriodoViewModel>> GetAllPeriodos()
        {
            var entity = await _periodoQuery.GetAllPeriodos();
            return _mapper.Map<IEnumerable<PeriodoViewModel>>(entity);
        }

        public async Task<PeriodoViewModel> GetPeriodoById(Guid idPeriodo)
        {
            var entity = await _periodoQuery.GetPeriodoPorId(idPeriodo);
            return _mapper.Map<PeriodoViewModel>(entity);
        }

        public async Task<IEnumerable<PeriodoViewModel>> GetPeriodoByNome(string nome)
        {
            return _mapper.Map<List<PeriodoViewModel>>(await _periodoQuery.GetPeriodoPorNome(nome));
        }

        public async Task<ICommandResult> NewPeriodo(CreatePeriodoCommand command)
        {
            var result = await _handlerCriarPeriodo.Handle(command);
            return result;
        }

        public async Task<ICommandResult> UpdatePeriodo(UpdatePeriodoCommand command)
        {
            return await _handlerEditarPeriodo.Handle(command);
        }

        public async Task<ICommandResult> DeletarPeriodo(Guid idPeriodo)
        {
            DeletePeriodoCommand command = new DeletePeriodoCommand(idPeriodo);
            return await _handlerDeletarPeriodo.Handle(command);
        }

        public async Task<IEnumerable<PeriodoViewModel>> GetPeriodoByTipo(Guid idPeriodoLetivoTipo)
        {
            var entity = await _periodoQuery.GetPeriodoByTipo(idPeriodoLetivoTipo);
            return _mapper.Map<List<PeriodoViewModel>>(entity);
        }

    }
}
