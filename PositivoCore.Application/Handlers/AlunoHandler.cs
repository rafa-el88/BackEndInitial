using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Flunt.Notifications;
using PositivoCore.Application.Commands;
using PositivoCore.Application.Commands.Aluno;
using PositivoCore.Application.Events;
using PositivoCore.Application.Interface.Repository;
using PositivoCore.Application.ViewModels;
using PositivoCore.Domain.Entities;
using PositivoCore.Shared.Commands;
using PositivoCore.Shared.Handlers;

namespace PositivoCore.Application.Handler
{
    public class AlunoHandler : Notifiable,
    IHandler<CreateAlunoCommand>,
    IHandler<DeleteAlunoCommand>,
    IHandler<UpdateAlunoCommand>,
    IHandler<CreateListStudentsCommand>,
    IHandler<UpdateListStudentsCommand>,
    IHandler<DeleteListStudentsCommand>
    {
        private readonly IAlunoRepository _repository;
        private readonly IMapper _mapper;

        public AlunoHandler(IAlunoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICommandResult> Handle(CreateAlunoCommand command)
        {
            //Check Command
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            var aluno = new Aluno(command.Nome);

            await Task.Run(() => _repository.Insert(aluno));

            return new CommandResult(true, "Aluno criado com sucesso.", _mapper.Map<AlunoViewModel>(aluno));
        }

        public async Task<ICommandResult> Handle(DeleteAlunoCommand command)
        {
            command.Validate();

            var aluno = await Task.Run(() => _repository.Find(command.Id));

            if (aluno == null)
                AddNotification("Aluno", "Não foi possível encontrar o aluno vinculado a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            _repository.Delete(aluno);
            return new CommandResult(true, "Aluno excluído com sucesso", null);
        }

        public async Task<ICommandResult> Handle(UpdateAlunoCommand command)
        {
            command.Validate();

            var aluno = await Task.Run(() => _repository.Find(command.Id)); 

            if (aluno == null)
                AddNotification("Aluno", "Não foi possível encontrar o aluno vinculado a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            aluno.UpdateNome(command.Nome);

            _repository.Update(aluno);

            return new CommandResult(true, "Nome atualizado com sucesso.", new { aluno.Id, aluno.Nome, Updated = aluno.DataAtualizacao });
        }

        public async Task<ICommandResult> Handle(CreateListStudentsCommand command)
        {
            //Check Command
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            List<Aluno> lst = new List<Aluno>();
            List<EventsResult> events = new List<EventsResult>();

            foreach (var item in command.Alunos)
            {
                //Define as Entidades
                var aluno = new Aluno(item.Nome);

                //Adiciona as Notificações dos Validates
                AddNotifications(aluno.Notifications);

                if (Invalid)
                    events.Add(_mapper.Map<EventsResult>(new CommandResult(false, $"Aluno: {item.Nome}", "")));

                //Adiciona na Lista
                lst.Add(aluno);
            }

            if (events.Count != 0)
                return new CommandResult(false, $"Econtramos {lst.Count} alunos com dados inválidos, realizar a operação novamente!.", events);

            // Persiste no banco
            lst = await Task.Run(() => _repository.InsertList(lst));

            return new CommandResult(true, $"Criado {lst.Count} alunos com sucesso.", lst);
        }

        public async Task<ICommandResult> Handle(UpdateListStudentsCommand command)
        {
            //Check Command
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            List<Aluno> lst = new List<Aluno>();
            List<EventsResult> events = new List<EventsResult>();

            foreach (var item in command.Alunos)
            {
                var aluno = _repository.Find(item.Id);
                aluno.UpdateNome(item.Nome);

                //Adiciona as Notificações dos Validates
                AddNotifications(aluno.Notifications);

                if (Invalid)
                    events.Add(_mapper.Map<EventsResult>(new CommandResult(false, $"Aluno: {item.Nome}", "")));

                //Adiciona na Lista
                lst.Add(aluno);
            }

            if (events.Count != 0)
                return new CommandResult(false, $"Econtramos {lst.Count} alunos com dados inválidos, realizar a operação novamente!.", events);

            // Persiste no banco
            lst = await Task.Run(() => _repository.UpdateList(lst));

            return new CommandResult(true, $"Alterado {lst.Count} alunos com sucesso.", lst);
        }

        public async Task<ICommandResult> Handle(DeleteListStudentsCommand command)
        {
            //Check Command
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            List<Aluno> lst = new List<Aluno>();
            List<EventsResult> events = new List<EventsResult>();

            foreach (var item in command.Id)
            {
                var aluno = await Task.Run(() => _repository.Find(item)); 

                if (aluno == null)
                    AddNotification("Aluno", "Não foi possível encontrar o aluno vinculado a este id.");
                else
                    AddNotifications(aluno.Notifications); //Adiciona as Notificações dos Validates

                if (Invalid)
                    events.Add(_mapper.Map<EventsResult>(new CommandResult(false, $"Aluno: {item}", "")));

                //Adiciona na Lista
                lst.Add(aluno);
            }

            if (events.Count != 0)
                return new CommandResult(false, $"Econtramos {lst.Count} alunos com dados inválidos, realizar a operação novamente!.", events);

            // Persiste no banco
            _repository.DeleteList(lst);

            return new CommandResult(true, $"Deletado {lst.Count} alunos com sucesso.", null);
        }
    }
}