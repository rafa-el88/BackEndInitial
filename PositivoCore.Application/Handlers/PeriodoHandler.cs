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
    public class PeriodoHandler : Notifiable,
    IHandler<CreatePeriodoCommand>,
    IHandler<DeletePeriodoCommand>,
    IHandler<UpdatePeriodoCommand>
    {
        private readonly IPeriodoRepository _repository;
        private readonly IMapper _mapper;

        public PeriodoHandler(IPeriodoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICommandResult> Handle(CreatePeriodoCommand command)
        {
            //Check Command
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            var periodo = _mapper.Map<Periodo>(command);

            _repository.Insert(periodo);

            return new CommandResult(true, "Tipo do periodo letivo criado com sucesso.", _mapper.Map<PeriodoViewModel>(periodo));
        }

        public async Task<ICommandResult> Handle(DeletePeriodoCommand command)
        {
            command.Validate();

            var periodo = await _repository.Find(command.Id);

            if (periodo == null)
                AddNotification("Periodo", "Não foi possível encontrar o tipo do periodo letivo vinculado a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            _repository.Delete(periodo);

            return new CommandResult(true, "Tipo do periodo letivo excluído com sucesso", null);
        }

        public async Task<ICommandResult> Handle(UpdatePeriodoCommand command)
        {
            command.Validate();

            var periodo = await _repository.Find(command.Id); 

            if (periodo == null)
                AddNotification("Periodo", "Não foi possível encontrar periodo letivo vinculada a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            periodo.UpdateFields(_mapper.Map<Periodo>(command));

            _repository.Update(periodo);

            return new CommandResult(true, "Nome atualizado com sucesso.", new { periodo.Id, periodo.Nome, Updated = periodo.DataAtualizacao });
        }
    }
}