using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PositivoCore.Application.Commands.ConvidadosEventos;
using PositivoCore.Application.Interface.Services;
using PositivoCore.Application.Queries;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Commands;
using PositivoCore.Shared.Handlers;

namespace PositivoCore.Application.Services
{
    public class ConvidadosEventoServices : IConvidadosEventoServices
    {
        private readonly IMapper _mapper;
        private readonly IConvidadosEventoQuery _convidadosEventoQuery;
        private readonly IHandler<DeleteConvidadosEventoCommand> _handlerDeleteConvidadosEvento;
        private readonly IHandler<CreateConvidadosEventoCommand> _handlerCreateConvidadosEvento;
        private readonly IHandler<UpdateConvidadosEventoCommand> _handlerUpdateConvidadosEvento;

        public ConvidadosEventoServices(
            IMapper mapper,
            IConvidadosEventoQuery convidadosEventoQuery,
            IHandler<DeleteConvidadosEventoCommand> handlerDeleteConvidadosEvento,
            IHandler<CreateConvidadosEventoCommand> handlerCreateConvidadosEvento,
            IHandler<UpdateConvidadosEventoCommand> handlerUpdateConvidadosEvento)
        {
            _mapper = mapper;
            _convidadosEventoQuery = convidadosEventoQuery;
            _handlerCreateConvidadosEvento = handlerCreateConvidadosEvento;
            _handlerDeleteConvidadosEvento = handlerDeleteConvidadosEvento;
            _handlerUpdateConvidadosEvento = handlerUpdateConvidadosEvento;
        }
        public async Task<IEnumerable<ConvidadosEventoViewModel>> GetAllConvidadosEventos() =>
            _mapper.Map<List<ConvidadosEventoViewModel>>(await _convidadosEventoQuery.GetAllConvidadosEvento());

        public async Task<ConvidadosEventoViewModel> GetConvidadosEventoByID(Guid idConvidadosEvento) =>
            _mapper.Map<ConvidadosEventoViewModel>(await _convidadosEventoQuery.GetConvidadosEventoById(idConvidadosEvento));
        public async Task<IEnumerable<ConvidadosEventoViewModel>> GetConvidadosEventoByNome(string nome) =>
            _mapper.Map<List<ConvidadosEventoViewModel>>(await _convidadosEventoQuery.GetConvidadosEventoByNome(nome));
        public async Task<ICommandResult> NewConvidadosEvento(CreateConvidadosEventoCommand command) =>
            await _handlerCreateConvidadosEvento.Handle(command);
        public async Task<ICommandResult> UpdateConvidadosEvento(UpdateConvidadosEventoCommand command) =>
            await _handlerUpdateConvidadosEvento.Handle(command);
        public Task<ICommandResult> DeletarConvidadosEvento(Guid idConvidadosEvento)
        {
            DeleteConvidadosEventoCommand command = new DeleteConvidadosEventoCommand(idConvidadosEvento);
            return _handlerDeleteConvidadosEvento.Handle(command);
        }
    }
}