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
    public class DisciplinaHandler : Notifiable, IHandler<CreateDisciplinaCommand>, IHandler<DeleteDisciplinaCommand>, IHandler<UpdateDisiplinaCommand>
    {
        private readonly IDisciplinaRepository _repository;
        private readonly IMapper _mapper;

        public DisciplinaHandler(IDisciplinaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICommandResult> Handle(CreateDisciplinaCommand command)
        {
            //Check Command
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            var disciplina = new Disciplina(command.Nome);

            _repository.Insert(disciplina);

            return new CommandResult(true, "Disciplina criada com sucesso.", _mapper.Map<DisciplinaViewModel>(disciplina));
        }

        public async Task<ICommandResult> Handle(DeleteDisciplinaCommand command)
        {
            command.Validate();

            var disciplina = await _repository.Find(command.Id);

            if (disciplina == null)
                AddNotification("Disciplina", "Não foi possível encontrar a disciplina vinculada a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            _repository.Delete(disciplina);
            return new CommandResult(true, "Disciplina excluída com sucesso.", null);
        }

        public async Task<ICommandResult> Handle(UpdateDisiplinaCommand command)
        {
            command.Validate();

            var disciplina = await _repository.Find(command.Id);

            if (disciplina == null)
                AddNotification("Disciplina", "Não foi possível encontrar a disciplina vinculada a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            disciplina.UpdateNome(command.Nome);

            _repository.Update(disciplina);

            return new CommandResult(true, "disicplina atualizada com sucesso.", new { disciplina.Id, disciplina.Nome, Updated = disciplina.DataAtualizacao });
        }
    }
}