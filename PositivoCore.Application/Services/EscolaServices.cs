using AutoMapper;
using PositivoCore.Application.Commands;
using PositivoCore.Application.Interface.Services;
using PositivoCore.Application.Queries;
using PositivoCore.Application.ViewModels;
using PositivoCore.Domain.ValueObjects;
using PositivoCore.Shared.Commands;
using PositivoCore.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Services
{
    public class EscolaServices : IEscolaServices
    {
        private readonly IEscolaQuery _escolaQuery;
        private readonly IMapper _mapper;
        private readonly IHandler<CreateEscolaCommand> _handlerCreateEscola;
        private readonly IHandler<DeleteEscolaCommand> _handlerDeleteEscola;
        private readonly IHandler<CreateEscolasCommand> _handlerCreateEscolas;
        private readonly IHandler<UpdateEscolaCommand> _handlerUpdateEscola;

        public EscolaServices(IEscolaQuery escolaQuery,
            IMapper mapper,
            IHandler<CreateEscolaCommand> handlerCreateEscola,
            IHandler<DeleteEscolaCommand> handlerDeleteEscola,
            IHandler<CreateEscolasCommand> handlerCreateEscolas,
            IHandler<UpdateEscolaCommand> handlerUpdateEscola)
        {
            _escolaQuery = escolaQuery;
            _mapper = mapper;
            _handlerCreateEscola = handlerCreateEscola;
            _handlerDeleteEscola = handlerDeleteEscola;
            _handlerCreateEscolas = handlerCreateEscolas;
            _handlerUpdateEscola = handlerUpdateEscola;
        }

        public async Task<IEnumerable<EscolaViewModel>> GetAllEscolas()
        {
            return _mapper.Map<IEnumerable<EscolaViewModel>>(await _escolaQuery.GetAllEscola());
        }

        public async Task<EscolaViewModel> GetEscolaById(Guid idEscola)
        {
            return _mapper.Map<EscolaViewModel>(await _escolaQuery.GetEscolaPorId(idEscola));
        }

        public async Task<EscolaViewModel> GetEscolaByCNPJ(string cnpj)
        {
            return CNPJ.ValidarCNPJ(cnpj) ? _mapper.Map<EscolaViewModel>(await _escolaQuery.GetEscolaPorCNPJ(cnpj)) : null;
        }

        public async Task<IEnumerable<EscolaViewModel>> GetEscolaByNome(string nome)
        {
            return _mapper.Map<List<EscolaViewModel>>(await _escolaQuery.GetEscolaPorNome(nome));
        }

        public async Task<ICommandResult> CreateEscola(CreateEscolaCommand command)
        {
            var result = await _handlerCreateEscola.Handle(command);
            return result;
        }

        public async Task<ICommandResult> CreateEscolasFromList(List<EscolaViewModel> lst)
        {
            CreateEscolasCommand command = new CreateEscolasCommand(lst);
            return await _handlerCreateEscolas.Handle(command);
        }

        public async Task<ICommandResult> UpdateEscola(UpdateEscolaCommand command)
        {
            return await _handlerUpdateEscola.Handle(command);
        }

        public async Task<ICommandResult> DeleteEscola(Guid idEscola)
        {
            DeleteEscolaCommand command = new DeleteEscolaCommand(idEscola);
            return await _handlerDeleteEscola.Handle(command);
        }
    }
}
