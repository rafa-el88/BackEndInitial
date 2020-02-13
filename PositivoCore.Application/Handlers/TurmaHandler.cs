using AutoMapper;
using Flunt.Notifications;
using PositivoCore.Application.Commands;
using PositivoCore.Application.Interface.Repository;
using PositivoCore.Application.ViewModels;
using PositivoCore.Domain.Entities;
using PositivoCore.Shared.Commands;
using PositivoCore.Shared.Handlers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Handler
{
    public class TurmaHandler : Notifiable, IHandler<CreateTurmaCommand>, IHandler<DeleteTurmaCommand>, IHandler<AttachTurmaDisciplinaProfessorCommand>, IHandler<UpdateTurmaCommand>
    {
        private readonly ITurmaRepository _repository;
        private readonly ITurmaDisciplinaProfessorRepository _repositoryTurmaDisciplinaProfessor;
        private readonly IMapper _mapper;

        public TurmaHandler(ITurmaRepository repository, ITurmaDisciplinaProfessorRepository repositoryTurmaDisciplinaProfessor, IMapper mapper)
        {
            _repository = repository;
            _repositoryTurmaDisciplinaProfessor = repositoryTurmaDisciplinaProfessor;
            _mapper = mapper;
        }

        public async Task<ICommandResult> Handle(CreateTurmaCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            var turma = new Turma(command.Nome, command.IdEscola, command.IdSerie);

            _repository.Insert(turma);

            return new CommandResult(true, "Turma inserida com sucesso.", _mapper.Map<TurmaViewModel>(turma));
        }

        public async Task<ICommandResult> Handle(DeleteTurmaCommand command)
        {
            command.Validate();

            var turma = await _repository.Find(command.Id);

            if (turma == null)
                AddNotification("Serie", "Não foi possível encontrar o Nível de ensino vinculado a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            _repository.Delete(turma);

            return new CommandResult(true, "Turma excluída com sucesso.", null);
        }

        public async Task<ICommandResult> Handle(UpdateTurmaCommand command)
        {
            command.Validate();

            var turma = await _repository.Find(command.Id);

            if (turma == null)
                AddNotification("serie", "Não foi encontrado uma turma vinculada a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            turma.UpdateNome(command.Nome);

            _repository.Update(turma);

            return new CommandResult(true, "Nível de Ensino atualizado com sucesso.", new { turma.Id, turma.Nome, Updated = turma.DataAtualizacao });
        }

        public async Task<ICommandResult> Handle(AttachTurmaDisciplinaProfessorCommand command)
        {
            List<TurmaDisciplinaProfessor> lst = new List<TurmaDisciplinaProfessor>();
            foreach (var item in command.TurmasDisciplinasProfessores)
            {
                var tdp = new TurmaDisciplinaProfessor(item.Turma.Id.Value, item.Disciplina.Id.Value, item.Professor.Id.Value);
                lst.Add(tdp);
            }

            lst = _repositoryTurmaDisciplinaProfessor.InsertList(lst);

            return new CommandResult(true, "Vinculo turma/disciplina/professor criados com sucesso.", lst);
        }
    }
}