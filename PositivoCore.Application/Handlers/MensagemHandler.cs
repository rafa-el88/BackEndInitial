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
    public class MensagemHandler : Notifiable,
    IHandler<CreateMensagemCommand>,
    IHandler<DeleteMensagemCommand>,
    IHandler<UpdateMensagemCommand>
    {
        private readonly IMensagemRepository _repository;
        private readonly IMapper _mapper;

        public MensagemHandler(IMensagemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICommandResult> Handle(CreateMensagemCommand command)
        {
            //Check Command
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            var mensagem = _mapper.Map<Mensagem>(command);

            _repository.Insert(mensagem);

            return new CommandResult(true, "Mensagem criada com sucesso.", _mapper.Map<MensagemViewModel>(mensagem));
        }

        public async Task<ICommandResult> Handle(DeleteMensagemCommand command)
        {
            command.Validate();

            var mensagem = await _repository.Find(command.Id);

            if (mensagem == null)
                AddNotification("Mensagem", "Não foi possível encontrar a mensagem vinculada a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            _repository.Delete(mensagem);

            return new CommandResult(true, "Mensagem excluída com sucesso", null);
        }

        public async Task<ICommandResult> Handle(UpdateMensagemCommand command)
        {
            command.Validate();

            var mensagem = await _repository.Find(command.Id); 

            if (mensagem == null)
                AddNotification("Mensagem", "Não foi possível encontrar a mensagem vinculada a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            mensagem.UpdateFields(_mapper.Map<Mensagem>(command));

            _repository.Update(mensagem);

            return new CommandResult(true, "Mensagem atualizado com sucesso.", new { mensagem.Id, mensagem.Assunto, Updated = mensagem.DataAtualizacao });
        }
    }
}