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
    public class PeriodoLetivoTipoHandler : Notifiable,
    IHandler<CreatePeriodoLetivoTipoCommand>,
    IHandler<DeletePeriodoLetivoTipoCommand>,
    IHandler<UpdatePeriodoLetivoTipoCommand>
    {
        private readonly IPeriodoLetivoTipoRepository _repository;
        private readonly IMapper _mapper;

        public PeriodoLetivoTipoHandler(IPeriodoLetivoTipoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICommandResult> Handle(CreatePeriodoLetivoTipoCommand command)
        {
            //Check Command
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            var periodoLetivoTipo = _mapper.Map<PeriodoLetivoTipo>(command);

            _repository.Insert(periodoLetivoTipo);

            return new CommandResult(true, "Tipo do periodo letivo criado com sucesso.", _mapper.Map<PeriodoLetivoTipoViewModel>(periodoLetivoTipo));
        }

        public async Task<ICommandResult> Handle(DeletePeriodoLetivoTipoCommand command)
        {
            command.Validate();

            var colecao = await _repository.Find(command.Id);

            if (colecao == null)
                AddNotification("PeriodoLetivoTipo", "Não foi possível encontrar o tipo do periodo letivo vinculado a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            _repository.Delete(colecao);

            return new CommandResult(true, "Tipo do periodo letivo excluído com sucesso", null);
        }

        public async Task<ICommandResult> Handle(UpdatePeriodoLetivoTipoCommand command)
        {
            command.Validate();

            var periodoLetivoTipo = await _repository.Find(command.Id); 

            if (periodoLetivoTipo == null)
                AddNotification("PeriodoLetivoTipo", "Não foi possível encontrar o tipo do periodo letivo vinculada a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            periodoLetivoTipo.UpdateFields(_mapper.Map<PeriodoLetivoTipo>(command));

            _repository.Update(periodoLetivoTipo);

            return new CommandResult(true, "Nome atualizado com sucesso.", new { periodoLetivoTipo.Id, periodoLetivoTipo.Nome, Updated = periodoLetivoTipo.DataAtualizacao });
        }
    }
}