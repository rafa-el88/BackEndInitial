using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Flunt.Notifications;
using PositivoCore.Application.Commands;
using PositivoCore.Application.Events;
using PositivoCore.Application.Interface.Repository;
using PositivoCore.Application.ViewModels;
using PositivoCore.Domain.Entities;
using PositivoCore.Shared.Commands;
using PositivoCore.Shared.Handlers;

namespace PositivoCore.Application.Handler
{
    public class AdministradorHandler : Notifiable,
    IHandler<CreateAdministradorCommand>,
    IHandler<DeleteAdministradorCommand>,
    IHandler<UpdateAdministradorCommand>,
    IHandler<CreateListAdministradoresCommand>,
    IHandler<UpdateListAdministradoresCommand>,
    IHandler<DeleteListAdministradoresCommand>
    {
        private readonly IAdministradorRepository _repository;
        private readonly IMapper _mapper;

        public AdministradorHandler(IAdministradorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICommandResult> Handle(CreateAdministradorCommand command)
        {
            //Check Command
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            var administrador = _mapper.Map<Administrador>(command);

            _repository.Insert(administrador);

            return new CommandResult(true, "Administrador criado com sucesso.", _mapper.Map<AdministradorViewModel>(administrador));
        }

        public async Task<ICommandResult> Handle(DeleteAdministradorCommand command)
        {
            command.Validate();

            var administrador = await _repository.Find(command.Id);

            if (administrador == null)
                AddNotification("Aluno", "Não foi possível encontrar o administrador vinculado a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            _repository.Delete(administrador);

            return new CommandResult(true, "Administrador excluído com sucesso", null);
        }

        public async Task<ICommandResult> Handle(UpdateAdministradorCommand command)
        {
            command.Validate();

            var administrador = await _repository.Find(command.Id); 

            if (administrador == null)
                AddNotification("Administrador", "Não foi possível encontrar o administrador vinculado a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            administrador.UpdateFields(_mapper.Map<Administrador>(command));

            _repository.Update(administrador);

            return new CommandResult(true, "Nome atualizado com sucesso.", new { administrador.Id, administrador.Nome, Updated = administrador.DataAtualizacao });
        }

        public async Task<ICommandResult> Handle(CreateListAdministradoresCommand command)
        {
            //Check Command
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            List<Administrador> lst = new List<Administrador>();
            List<EventsResult> events = new List<EventsResult>();

            foreach (var item in command.Administradores)
            {
                //Define as Entidades
                var administrador = _mapper.Map<Administrador>(item);

                //Adiciona as Notificações dos Validates
                AddNotifications(administrador.Notifications);

                if (Invalid)
                    events.Add(_mapper.Map<EventsResult>(new CommandResult(false, $"Administrador: {item.Nome}", "")));

                //Adiciona na Lista
                lst.Add(administrador);
            }

            if (events.Count != 0)
                return new CommandResult(false, $"Econtramos {lst.Count} administradores com dados inválidos, realizar a operação novamente!.", events);

            // Persiste no banco
            lst = _repository.InsertList(lst);

            return new CommandResult(true, $"Criado {lst.Count} administradores com sucesso.", lst);
        }

        public async Task<ICommandResult> Handle(UpdateListAdministradoresCommand command)
        {
            //Check Command
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            List<Administrador> lst = new List<Administrador>();
            List<EventsResult> events = new List<EventsResult>();

            foreach (var item in command.Administradores)
            {
                var administrador = await _repository.Find(item.Id);

                administrador.UpdateFields(_mapper.Map<Administrador>(item));

                //Adiciona as Notificações dos Validates
                AddNotifications(administrador.Notifications);

                if (Invalid)
                    events.Add(_mapper.Map<EventsResult>(new CommandResult(false, $"Administrador: {item.Nome}", "")));

                //Adiciona na Lista
                lst.Add(administrador);
            }

            if (events.Count != 0)
                return new CommandResult(false, $"Econtramos {lst.Count} administradores com dados inválidos, realizar a operação novamente!.", events);

            // Persiste no banco
            lst = _repository.UpdateList(lst);

            return new CommandResult(true, $"Alterado {lst.Count} administradores com sucesso.", lst);
        }

        public async Task<ICommandResult> Handle(DeleteListAdministradoresCommand command)
        {
            //Check Command
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            List<Administrador> lst = new List<Administrador>();
            List<EventsResult> events = new List<EventsResult>();

            foreach (var item in command.Id)
            {
                var administrador = await _repository.Find(item); 

                if (administrador == null)
                    AddNotification("Administrador", "Não foi possível encontrar o administrador vinculado a este id.");
                else
                    AddNotifications(administrador.Notifications); //Adiciona as Notificações dos Validates

                if (Invalid)
                    events.Add(_mapper.Map<EventsResult>(new CommandResult(false, $"Administrador: {item}", "")));

                //Adiciona na Lista
                lst.Add(administrador);
            }

            if (events.Count != 0)
                return new CommandResult(false, $"Econtramos {lst.Count} administradores com dados inválidos, realizar a operação novamente!.", events);

            // Persiste no banco
            _repository.DeleteList(lst);

            return new CommandResult(true, $"Deletado {lst.Count} administradores com sucesso.", null);
        }
    }
}