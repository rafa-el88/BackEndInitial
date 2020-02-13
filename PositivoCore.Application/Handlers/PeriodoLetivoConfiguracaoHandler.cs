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
    public class PeriodoLetivoConfiguracaoHandler : Notifiable,
    IHandler<CreatePeriodoLetivoConfiguracaoCommand>,
    IHandler<DeletePeriodoLetivoConfiguracaoCommand>,
    IHandler<UpdatePeriodoLetivoConfiguracaoCommand>
    {
        private readonly IPeriodoLetivoConfiguracaoRepository _repository;
        private readonly IMapper _mapper;

        public PeriodoLetivoConfiguracaoHandler(IPeriodoLetivoConfiguracaoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICommandResult> Handle(CreatePeriodoLetivoConfiguracaoCommand command)
        {
            //Check Command
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            var periodoLetivoConfiguracao = _mapper.Map<PeriodoLetivoConfiguracao>(command);

            _repository.Insert(periodoLetivoConfiguracao);

            return new CommandResult(true, "Configuração do periodo letivo criado com sucesso.", _mapper.Map<PeriodoLetivoConfiguracaoViewModel>(periodoLetivoConfiguracao));
        }

        public async Task<ICommandResult> Handle(DeletePeriodoLetivoConfiguracaoCommand command)
        {
            command.Validate();

            var colecao = await _repository.Find(command.Id);

            if (colecao == null)
                AddNotification("PeriodoLetivoConfiguracao", "Não foi possível encontrar a configuração do periodo letivo vinculado a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            _repository.Delete(colecao);

            return new CommandResult(true, "Configuração do periodo letivo excluído com sucesso", null);
        }

        public async Task<ICommandResult> Handle(UpdatePeriodoLetivoConfiguracaoCommand command)
        {
            command.Validate();

            var periodoLetivoConfiguracao = await _repository.Find(command.Id); 

            if (periodoLetivoConfiguracao == null)
                AddNotification("PeriodoLetivoConfiguracao", "Não foi possível encontrar a configuração do periodo letivo vinculada a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            periodoLetivoConfiguracao.UpdateFields(_mapper.Map<PeriodoLetivoConfiguracao>(command));

            _repository.Update(periodoLetivoConfiguracao);

            return new CommandResult(true, "Nome atualizado com sucesso.", new { periodoLetivoConfiguracao.Id, Updated = periodoLetivoConfiguracao.DataAtualizacao });
        }
    }
}