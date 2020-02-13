using System.Threading.Tasks;
using AutoMapper;
using Flunt.Notifications;
using PositivoCore.Application.Commands;
using PositivoCore.Application.Interface.Repository;
using PositivoCore.Application.ViewModels;
using PositivoCore.Domain.Entities;
using PositivoCore.Shared.Commands;
using PositivoCore.Shared.Handlers;

namespace PositivoCore.Application.Handler
{
    public class DestinatarioMensagemHandler : Notifiable,
    IHandler<CreateDestinatarioMensagemCommand>,
    IHandler<DeleteDestinatarioMensagemCommand>,
    IHandler<UpdateDestinatarioMensagemCommand>
    {
        private readonly IDestinatarioMensagemRepository _repository;
        private readonly IMapper _mapper;

        public DestinatarioMensagemHandler(IDestinatarioMensagemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICommandResult> Handle(CreateDestinatarioMensagemCommand command)
        {
            //Check Command
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            var destinatarioMensagem = _mapper.Map<DestinatarioMensagem>(command);

            _repository.Insert(destinatarioMensagem);

            return new CommandResult(true, "Destinatario da mensagem criado com sucesso.", _mapper.Map<DestinatarioMensagemViewModel>(destinatarioMensagem));
        }

        public async Task<ICommandResult> Handle(DeleteDestinatarioMensagemCommand command)
        {
            command.Validate();

            var destinatarioMensagem = await _repository.Find(command.Id);

            if (destinatarioMensagem == null)
                AddNotification("DestinatarioMensagem", "Não foi possível encontrar a mensagem vinculada a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            _repository.Delete(destinatarioMensagem);

            return new CommandResult(true, "Destinatario da mensagem excluído com sucesso", null);
        }

        public async Task<ICommandResult> Handle(UpdateDestinatarioMensagemCommand command)
        {
            command.Validate();

            var destinatarioMensagem = await _repository.Find(command.Id); 

            if (destinatarioMensagem == null)
                AddNotification("DestinatarioMensagem", "Não foi possível encontrar a mensagem vinculada a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            destinatarioMensagem.UpdateFields(_mapper.Map<DestinatarioMensagem>(command));

            _repository.Update(destinatarioMensagem);

            return new CommandResult(true, "DestinatarioMensagem atualizado com sucesso.", new { destinatarioMensagem.Id, destinatarioMensagem.IdDestinatario, Updated = destinatarioMensagem.DataAtualizacao });
        }
    }
}