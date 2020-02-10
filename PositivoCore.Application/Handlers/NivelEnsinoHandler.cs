using AutoMapper;
using Flunt.Notifications;
using PositivoCore.Application.Commands;
using PositivoCore.Application.Interface.Repository;
using PositivoCore.Application.ViewModels;
using PositivoCore.Domain.Entities;
using PositivoCore.Shared.Commands;
using PositivoCore.Shared.Handlers;
using System.Threading.Tasks;

namespace PositivoCore.Application.Handler
{
    public class NivelEnsinoHandler : Notifiable, IHandler<CreateNivelEnsinoCommand>, IHandler<DeleteNivelEnsinoCommand>, IHandler<UpdateNivelEnsinoCommand>
    {
        private readonly INivelEnsinoRepository _repository;
        private readonly IMapper _mapper;

        public NivelEnsinoHandler(INivelEnsinoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICommandResult> Handle(CreateNivelEnsinoCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            var nivelEnsino = new NivelEnsino(command.Nome);

            await Task.Run(() => _repository.Insert(nivelEnsino));

            return new CommandResult(true, "Nível de ensino inserido com sucesso.", _mapper.Map<NivelEnsinoViewModel>(nivelEnsino));
        }

        public async Task<ICommandResult> Handle(DeleteNivelEnsinoCommand command)
        {
            command.Validate();

            var nivelEnsino = await Task.Run(() => _repository.Find(command.Id));

            if (nivelEnsino == null)
                AddNotification("NivelEnsino", "Não foi possível encontrar o nível de ensino vinculado a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            _repository.Delete(nivelEnsino);
            return new CommandResult(true, "Nível de ensino excluído com sucesso.", null);
        }

        public async Task<ICommandResult> Handle(UpdateNivelEnsinoCommand command)
        {
            command.Validate();

            var nivelEnsino = await Task.Run(() => _repository.Find(command.Id));

            if (nivelEnsino == null)
                AddNotification("NivelEnsino", "Não foi encontrado Nível de Ensino vinculada a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            nivelEnsino.UpdateNome(command.Nome);

            _repository.Update(nivelEnsino);

            return new CommandResult(true, "Nível de Ensino atualizado com sucesso.", new { nivelEnsino.Id, nivelEnsino.Nome, Updated = nivelEnsino.DataAtualizacao });
        }
    }
}