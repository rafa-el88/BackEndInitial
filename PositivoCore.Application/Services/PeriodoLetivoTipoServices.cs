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
    public class PeriodoLetivoTipoServices : IPeriodoLetivoTipoServices
    {
        private readonly IPeriodoLetivoTipoQuery _periodoLetivoTipoQuery;
        private readonly IMapper _mapper;
        private readonly IHandler<CreatePeriodoLetivoTipoCommand> _handlerCriarPeriodoLetivoTipo;
        private readonly IHandler<DeletePeriodoLetivoTipoCommand> _handlerDeletarPeriodoLetivoTipo;
        private readonly IHandler<UpdatePeriodoLetivoTipoCommand> _handlerEditarPeriodoLetivoTipo;

        public PeriodoLetivoTipoServices(IPeriodoLetivoTipoQuery periodoLetivoTipoQuery, IMapper mapper, IHandler<CreatePeriodoLetivoTipoCommand> handlerCriarPeriodoLetivoTipo, IHandler<DeletePeriodoLetivoTipoCommand> handlerDeletarPeriodoLetivoTipo, IHandler<UpdatePeriodoLetivoTipoCommand> handlerEditarPeriodoLetivoTipo)
        {
            _periodoLetivoTipoQuery = periodoLetivoTipoQuery;
            _mapper = mapper;
            _handlerCriarPeriodoLetivoTipo = handlerCriarPeriodoLetivoTipo;
            _handlerDeletarPeriodoLetivoTipo = handlerDeletarPeriodoLetivoTipo;
            _handlerEditarPeriodoLetivoTipo = handlerEditarPeriodoLetivoTipo;
        }

        public async Task<IEnumerable<PeriodoLetivoTipoViewModel>> GetAllPeriodoLetivoTipos()
        {
            var entity = await _periodoLetivoTipoQuery.GetAllPeriodoLetivoTipos();
            return _mapper.Map<IEnumerable<PeriodoLetivoTipoViewModel>>(entity);
        }

        public async Task<PeriodoLetivoTipoViewModel> GetPeriodoLetivoTipoById(Guid idPeriodoLetivoTipo)
        {
            var entity = await _periodoLetivoTipoQuery.GetPeriodoLetivoTipoPorId(idPeriodoLetivoTipo);
            return _mapper.Map<PeriodoLetivoTipoViewModel>(entity);
        }

        public async Task<IEnumerable<PeriodoLetivoTipoViewModel>> GetPeriodoLetivoTipoByNome(string nome)
        {
            return _mapper.Map<List<PeriodoLetivoTipoViewModel>>(await _periodoLetivoTipoQuery.GetPeriodoLetivoTipoPorNome(nome));
        }

        public async Task<ICommandResult> NewPeriodoLetivoTipo(CreatePeriodoLetivoTipoCommand command)
        {
            var result = await _handlerCriarPeriodoLetivoTipo.Handle(command);
            return result;
        }

        public async Task<ICommandResult> UpdatePeriodoLetivoTipo(UpdatePeriodoLetivoTipoCommand command)
        {
            return await _handlerEditarPeriodoLetivoTipo.Handle(command);
        }

        public async Task<ICommandResult> DeletarPeriodoLetivoTipo(Guid idPeriodoLetivoTipo)
        {
            DeletePeriodoLetivoTipoCommand command = new DeletePeriodoLetivoTipoCommand(idPeriodoLetivoTipo);
            return await _handlerDeletarPeriodoLetivoTipo.Handle(command);
        }
    }
}
