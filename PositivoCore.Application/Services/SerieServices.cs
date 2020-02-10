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
    public class SerieServices : ISerieServices
    {
        private readonly ISerieQuery _serieQuery;
        private readonly IMapper _mapper;
        private readonly IHandler<CreateSerieCommand> _handlerCriarSerie;
        private readonly IHandler<DeleteSerieCommand> _handlerDeletarSerie;
        private readonly IHandler<UpdateSerieCommand> _handlerEditarSerie;

        public SerieServices(ISerieQuery serieQuery,
        IMapper mapper,
        IHandler<CreateSerieCommand> handlerCriarSerie,
        IHandler<DeleteSerieCommand> handlerDeletarSerie,
        IHandler<UpdateSerieCommand> handlerEditarSerie)
        {
            _serieQuery = serieQuery;
            _mapper = mapper;
            _handlerCriarSerie = handlerCriarSerie;
            _handlerDeletarSerie = handlerDeletarSerie;
            _handlerEditarSerie = handlerEditarSerie;
        }

        public async Task<IEnumerable<SerieViewModel>> GetAllSeries()
        {
            return _mapper.Map<List<SerieViewModel>>(await _serieQuery.GetAllSeries());
        }

        public async Task<SerieViewModel> GetSerieByID(Guid idSerie)
        {
            return _mapper.Map<SerieViewModel>(await _serieQuery.GetSerieByID(idSerie));
        }

        public async Task<IEnumerable<SerieViewModel>> GetSerieByNome(string nome)
        {
            return _mapper.Map<List<SerieViewModel>>(await _serieQuery.GetSerieByNome(nome));
        }

        public async Task<ICommandResult> NewSerie(CreateSerieCommand command)
        {
            return await _handlerCriarSerie.Handle(command);
        }

        public async Task<ICommandResult> UpdateSerie(UpdateSerieCommand command)
        {
            return await _handlerEditarSerie.Handle(command);
        }

        public async Task<ICommandResult> DeletarSerie(Guid idSerie)
        {
            DeleteSerieCommand command = new DeleteSerieCommand(idSerie);
            return await _handlerDeletarSerie.Handle(command);
        }
    }
}
