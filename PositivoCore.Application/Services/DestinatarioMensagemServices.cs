using AutoMapper;
using PositivoCore.Application.Commands;
using PositivoCore.Application.Interface.Services;
using PositivoCore.Application.Queries;
using PositivoCore.Application.ViewModels;
using PositivoCore.Domain.Enums;
using PositivoCore.Shared.Commands;
using PositivoCore.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Services
{
    public class DestinatarioMensagemServices : IDestinatarioMensagemServices
    {
        private readonly IDestinatarioMensagemQuery _mensagemQuery;
        private readonly IMapper _mapper;
        private readonly IHandler<CreateDestinatarioMensagemCommand> _handlerCreateDestinatarioMensagem;
        private readonly IHandler<DeleteDestinatarioMensagemCommand> _handlerDeleteDestinatarioMensagem;
        private readonly IHandler<UpdateDestinatarioMensagemCommand> _handlerUpdateDestinatarioMensagem;

        public DestinatarioMensagemServices(IDestinatarioMensagemQuery mensagemQuery, IMapper mapper, IHandler<CreateDestinatarioMensagemCommand> handlerCreateDestinatarioMensagem, IHandler<DeleteDestinatarioMensagemCommand> handlerDeleteDestinatarioMensagem, IHandler<UpdateDestinatarioMensagemCommand> handlerUpdateDestinatarioMensagem)
        {
            _mensagemQuery = mensagemQuery;
            _mapper = mapper;
            _handlerCreateDestinatarioMensagem = handlerCreateDestinatarioMensagem;
            _handlerDeleteDestinatarioMensagem = handlerDeleteDestinatarioMensagem;
            _handlerUpdateDestinatarioMensagem = handlerUpdateDestinatarioMensagem;
        }

        public async Task<IEnumerable<DestinatarioMensagemViewModel>> GetAllDestinatarioMensagens()
        {
            return _mapper.Map<IEnumerable<DestinatarioMensagemViewModel>>(await _mensagemQuery.GetAllDestinatarioMensagens());
        }

        public async Task<DestinatarioMensagemViewModel> GetDestinatarioMensagemById(Guid idDestinatarioMensagem)
        {
            return _mapper.Map<DestinatarioMensagemViewModel>(await _mensagemQuery.GetDestinatarioMensagemById(idDestinatarioMensagem));
        }

        public async Task<IEnumerable<DestinatarioMensagemViewModel>> GetDestinatarioMensagemByTipoPerfil(ETipoPerfil tipoPerfil)
        {
            return _mapper.Map<List<DestinatarioMensagemViewModel>>(await _mensagemQuery.GetDestinatarioMensagemByTipoPerfil(tipoPerfil));
        }

        public async Task<IEnumerable<DestinatarioMensagemViewModel>> GetDestinatarioMensagemByMensagem(Guid idMensagem)
        {
            return _mapper.Map<List<DestinatarioMensagemViewModel>>(await _mensagemQuery.GetDestinatarioMensagemByMensagem(idMensagem));
        }

        public async Task<ICommandResult> CreateDestinatarioMensagem(CreateDestinatarioMensagemCommand command)
        {
            var result = await _handlerCreateDestinatarioMensagem.Handle(command);
            return result;
        }

        public async Task<ICommandResult> UpdateDestinatarioMensagem(UpdateDestinatarioMensagemCommand command)
        {
            return await _handlerUpdateDestinatarioMensagem.Handle(command);
        }

        public async Task<ICommandResult> DeleteDestinatarioMensagem(Guid idDestinatarioMensagem)
        {
            DeleteDestinatarioMensagemCommand command = new DeleteDestinatarioMensagemCommand(idDestinatarioMensagem);
            return await _handlerDeleteDestinatarioMensagem.Handle(command);
        }
    }
}
