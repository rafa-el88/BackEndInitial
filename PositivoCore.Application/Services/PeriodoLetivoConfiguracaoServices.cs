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
    public class PeriodoLetivoConfiguracaoServices : IPeriodoLetivoConfiguracaoServices
    {
        private readonly IPeriodoLetivoConfiguracaoQuery _periodoLetivoConfiguracaoQuery;
        private readonly IMapper _mapper;
        private readonly IHandler<CreatePeriodoLetivoConfiguracaoCommand> _handlerCriarPeriodoLetivoConfiguracao;
        private readonly IHandler<DeletePeriodoLetivoConfiguracaoCommand> _handlerDeletarPeriodoLetivoConfiguracao;
        private readonly IHandler<UpdatePeriodoLetivoConfiguracaoCommand> _handlerEditarPeriodoLetivoConfiguracao;

        public PeriodoLetivoConfiguracaoServices(IPeriodoLetivoConfiguracaoQuery periodoLetivoConfiguracaoQuery, IMapper mapper, IHandler<CreatePeriodoLetivoConfiguracaoCommand> handlerCriarPeriodoLetivoConfiguracao, IHandler<DeletePeriodoLetivoConfiguracaoCommand> handlerDeletarPeriodoLetivoConfiguracao, IHandler<UpdatePeriodoLetivoConfiguracaoCommand> handlerEditarPeriodoLetivoConfiguracao)
        {
            _periodoLetivoConfiguracaoQuery = periodoLetivoConfiguracaoQuery;
            _mapper = mapper;
            _handlerCriarPeriodoLetivoConfiguracao = handlerCriarPeriodoLetivoConfiguracao;
            _handlerDeletarPeriodoLetivoConfiguracao = handlerDeletarPeriodoLetivoConfiguracao;
            _handlerEditarPeriodoLetivoConfiguracao = handlerEditarPeriodoLetivoConfiguracao;
        }

        public async Task<IEnumerable<PeriodoLetivoConfiguracaoViewModel>> GetAllPeriodoLetivoConfiguracoes()
        {
            var entity = await _periodoLetivoConfiguracaoQuery.GetAllPeriodoLetivoConfiguracoes();
            return _mapper.Map<IEnumerable<PeriodoLetivoConfiguracaoViewModel>>(entity);
        }

        public async Task<PeriodoLetivoConfiguracaoViewModel> GetPeriodoLetivoConfiguracaoById(Guid idPeriodoLetivoConfiguracao)
        {
            var entity = await _periodoLetivoConfiguracaoQuery.GetPeriodoLetivoConfiguracaoPorId(idPeriodoLetivoConfiguracao);
            return _mapper.Map<PeriodoLetivoConfiguracaoViewModel>(entity);
        }

        public async Task<ICommandResult> NewPeriodoLetivoConfiguracao(CreatePeriodoLetivoConfiguracaoCommand command)
        {
            var result = await _handlerCriarPeriodoLetivoConfiguracao.Handle(command);
            return result;
        }

        public async Task<ICommandResult> UpdatePeriodoLetivoConfiguracao(UpdatePeriodoLetivoConfiguracaoCommand command)
        {
            return await _handlerEditarPeriodoLetivoConfiguracao.Handle(command);
        }

        public async Task<ICommandResult> DeletarPeriodoLetivoConfiguracao(Guid idPeriodoLetivoConfiguracao)
        {
            DeletePeriodoLetivoConfiguracaoCommand command = new DeletePeriodoLetivoConfiguracaoCommand(idPeriodoLetivoConfiguracao);
            return await _handlerDeletarPeriodoLetivoConfiguracao.Handle(command);
        }
    }
}
