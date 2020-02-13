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
    public class ProfessorHandler : Notifiable,
    IHandler<CreateProfessorCommand>,
    IHandler<DeleteProfessorCommand>,
    IHandler<UpdateProfessorCommand>
    {
        private readonly IProfessorRepository _repository;
        private readonly IMapper _mapper;

        public ProfessorHandler(IProfessorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICommandResult> Handle(CreateProfessorCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            var professor = _mapper.Map<Professor>(command);

            _repository.Insert(professor);

            return new CommandResult(true, "Professor criado com sucesso.", _mapper.Map<ProfessorViewModel>(professor));
        }

        public async Task<ICommandResult> Handle(DeleteProfessorCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            var professor = await _repository.Find(command.Id);

            if (professor == null)
                AddNotification("Professor", "Não foi possível encontrar o professor vinculado a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            _repository.Delete(professor);
            return new CommandResult(true, "Professor excluído com sucesso", null);
        }

        public async Task<ICommandResult> Handle(UpdateProfessorCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            var professor = await _repository.Find(command.Id);

            if (professor == null)
                AddNotification("Professor", "Não foi encontrar o professor vinculado a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            professor.UpdateFields(_mapper.Map<Professor>(command));

            _repository.Update(professor);

            return new CommandResult(true, "Nome atualizado com sucesso.", new { professor.Id, professor.Nome, Updated = professor.DataAtualizacao });
        }
    }
}