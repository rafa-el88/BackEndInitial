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
    public class NivelEnsinoServices : INivelEnsinoServices
    {
        private readonly INivelEnsinoQuery _nivelEnsinoQuery;
        private readonly IMapper _mapper;
        private readonly IHandler<CreateNivelEnsinoCommand> _handlerCriarNivelEnsino;
        private readonly IHandler<DeleteNivelEnsinoCommand> _handlerDeletarNivelEnsino;
        private readonly IHandler<UpdateNivelEnsinoCommand> _handlerEditarNivelEnsino;

        public NivelEnsinoServices(INivelEnsinoQuery nivelEnsinoQuery,
        IMapper mapper,
        IHandler<CreateNivelEnsinoCommand> handlerCriarNivelEnsino,
        IHandler<DeleteNivelEnsinoCommand> handlerDeletarNivelEnsino,
        IHandler<UpdateNivelEnsinoCommand> handlerEditarNivelEnsino)
        {
            _nivelEnsinoQuery = nivelEnsinoQuery;
            _mapper = mapper;
            _handlerCriarNivelEnsino = handlerCriarNivelEnsino;
            _handlerDeletarNivelEnsino = handlerDeletarNivelEnsino;
            _handlerEditarNivelEnsino = handlerEditarNivelEnsino;
        }

        public async Task<IEnumerable<NivelEnsinoViewModel>> GetAllNiveisEnsino()
        {
            return _mapper.Map<List<NivelEnsinoViewModel>>(await _nivelEnsinoQuery.GetAllNiveisEnsino());
        }

        public async Task<NivelEnsinoViewModel> GetNivelEnsinoByID(Guid idNivelEnsino)
        {
            return _mapper.Map<NivelEnsinoViewModel>(await _nivelEnsinoQuery.GetNivelEnsinoByID(idNivelEnsino));
        }

        public async Task<IEnumerable<NivelEnsinoViewModel>> GetNivelEnsinoByNome(string nome)
        {
            return _mapper.Map<List<NivelEnsinoViewModel>>(await _nivelEnsinoQuery.GetNivelEnsinoByNome(nome));
        }

        public async Task<ICommandResult> NewNivelEnsino(CreateNivelEnsinoCommand command)
        {
            return await _handlerCriarNivelEnsino.Handle(command);
        }

        public async Task<ICommandResult> UpdateNivelEnsino(UpdateNivelEnsinoCommand command)
        {
            return await _handlerEditarNivelEnsino.Handle(command);
        }

        public async Task<ICommandResult> DeletarNivelEnsino(Guid idNivelEnsino)
        {
            DeleteNivelEnsinoCommand command = new DeleteNivelEnsinoCommand(idNivelEnsino);
            return await _handlerDeletarNivelEnsino.Handle(command);
        }
    }
}
