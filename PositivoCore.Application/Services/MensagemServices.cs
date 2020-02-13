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
    public class MensagemServices : IMensagemServices
    {
        private readonly IMensagemQuery _mensagemQuery;
        private readonly IMapper _mapper;
        private readonly IHandler<CreateMensagemCommand> _handlerCreateMensagem;
        private readonly IHandler<DeleteMensagemCommand> _handlerDeleteMensagem;
        private readonly IHandler<UpdateMensagemCommand> _handlerUpdateMensagem;

        public MensagemServices(IMensagemQuery mensagemQuery, IMapper mapper, IHandler<CreateMensagemCommand> handlerCreateMensagem, IHandler<DeleteMensagemCommand> handlerDeleteMensagem, IHandler<UpdateMensagemCommand> handlerUpdateMensagem)
        {
            _mensagemQuery = mensagemQuery;
            _mapper = mapper;
            _handlerCreateMensagem = handlerCreateMensagem;
            _handlerDeleteMensagem = handlerDeleteMensagem;
            _handlerUpdateMensagem = handlerUpdateMensagem;
        }

        public async Task<IEnumerable<MensagemViewModel>> GetAllMensagens()
        {
            return _mapper.Map<IEnumerable<MensagemViewModel>>(await _mensagemQuery.GetAllMensagens());
        }

        public async Task<MensagemViewModel> GetMensagemById(Guid idMensagem)
        {
            return _mapper.Map<MensagemViewModel>(await _mensagemQuery.GetMensagemById(idMensagem));
        }

        public async Task<IEnumerable<MensagemViewModel>> GetMensagemByAssunto(string assunto)
        {
            return _mapper.Map<List<MensagemViewModel>>(await _mensagemQuery.GetMensagemByAssunto(assunto));
        }

        public async Task<ICommandResult> CreateMensagem(CreateMensagemCommand command)
        {
            var result = await _handlerCreateMensagem.Handle(command);
            return result;
        }

        public async Task<ICommandResult> UpdateMensagem(UpdateMensagemCommand command)
        {
            return await _handlerUpdateMensagem.Handle(command);
        }

        public async Task<ICommandResult> DeleteMensagem(Guid idMensagem)
        {
            DeleteMensagemCommand command = new DeleteMensagemCommand(idMensagem);
            return await _handlerDeleteMensagem.Handle(command);
        }
    }
}
