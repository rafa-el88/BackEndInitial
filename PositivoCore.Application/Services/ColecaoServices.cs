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
    public class ColecaoServices : IColecaoServices
    {
        private readonly IColecaoQuery _colecaoQuery;
        private readonly IMapper _mapper;
        private readonly IHandler<CreateColecaoCommand> _handlerCriarColecao;
        private readonly IHandler<DeleteColecaoCommand> _handlerDeletarColecao;
        private readonly IHandler<UpdateColecaoCommand> _handlerEditarColecao;

        public ColecaoServices(IColecaoQuery colecaoQuery, IMapper mapper, IHandler<CreateColecaoCommand> handlerCriarColecao, IHandler<DeleteColecaoCommand> handlerDeletarColecao, IHandler<UpdateColecaoCommand> handlerEditarColecao)
        {
            _colecaoQuery = colecaoQuery;
            _mapper = mapper;
            _handlerCriarColecao = handlerCriarColecao;
            _handlerDeletarColecao = handlerDeletarColecao;
            _handlerEditarColecao = handlerEditarColecao;
        }

        public async Task<IEnumerable<ColecaoViewModel>> GetAllColecoes()
        {
            var entity = await _colecaoQuery.GetAllColecoes();
            return _mapper.Map<IEnumerable<ColecaoViewModel>>(entity);
        }

        public async Task<ColecaoViewModel> GetColecaoById(Guid idColecao)
        {
            var entity = await _colecaoQuery.GetColecaoPorId(idColecao);
            return _mapper.Map<ColecaoViewModel>(entity);
        }

        public async Task<IEnumerable<ColecaoViewModel>> GetColecaoByNome(string nome)
        {
            return _mapper.Map<List<ColecaoViewModel>>(await _colecaoQuery.GetColecaoPorNome(nome));
        }

        public async Task<ICommandResult> NewColecao(CreateColecaoCommand command)
        {
            var result = await _handlerCriarColecao.Handle(command);
            return result;
        }

        public async Task<ICommandResult> UpdateColecao(UpdateColecaoCommand command)
        {
            return await _handlerEditarColecao.Handle(command);
        }

        public async Task<ICommandResult> DeletarColecao(Guid idColecao)
        {
            DeleteColecaoCommand command = new DeleteColecaoCommand(idColecao);
            return await _handlerDeletarColecao.Handle(command);
        }
    }
}
