using AutoMapper;
using Flunt.Notifications;
using PositivoCore.Application.Commands;
using PositivoCore.Application.Events;
using PositivoCore.Application.Interface.Repository;
using PositivoCore.Application.Queries;
using PositivoCore.Application.ViewModels;
using PositivoCore.Domain.Entities;
using PositivoCore.Domain.ValueObjects;
using PositivoCore.Shared.Commands;
using PositivoCore.Shared.Handlers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Handler
{
    public class EscolaHandler : Notifiable,
    IHandler<CreateEscolaCommand>,
    IHandler<DeleteEscolaCommand>,
    IHandler<CreateEscolasCommand>,
    IHandler<UpdateEscolaCommand>
    {
        private readonly IEscolaRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEscolaQuery _escolaQuery;

        public EscolaHandler(IEscolaRepository repository, IMapper mapper, IEscolaQuery escolaQuery)
        {
            _mapper = mapper;
            _repository = repository;
            _escolaQuery = escolaQuery;
        }

        public async Task<ICommandResult> Handle(CreateEscolaCommand command)
        {
            //Check Command
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            //Verifica se escola existe
            var escolaExiste = await _escolaQuery.GetEscolaPorCNPJ(command.CNPJ);
            if (escolaExiste != null)
                AddNotification("Escola", "Já existe uma escola cadastrada com este CNPJ!");

            //Define os VOs
            var cnpj = new CNPJ(command.CNPJ);

            //Define as Entidades
            var escola = new Escola(command.Nome, cnpj);

            //Adiciona as Notificações dos Validates
            AddNotifications(cnpj.Notifications);
            AddNotifications(escola.Notifications);

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            // Persiste no banco
            _repository.Insert(escola);

            return new CommandResult(true, "Escola criada com sucesso", new 
            {
                escola.Id,
                escola.Nome,
                CNPJ = escola.CNPJ.Number,
                Status = escola.Ativo,
                Create = escola.DataCadastro
            });
        }

        public async Task<ICommandResult> Handle(CreateEscolasCommand command)
        {
            //Check Command
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            List<Escola> lst = new List<Escola>();
            List<EventsResult> events = new List<EventsResult>();

            foreach (var item in command.Escolas)
            {
                //Verifica se escola existe
                var escolaExiste = await _escolaQuery.GetEscolaPorCNPJ(item.Cnpj);
                if (escolaExiste != null)
                    AddNotification("Escola", "Já existe uma escola cadastrada com este CNPJ...");

                //Define os VOs
                var cnpj = new CNPJ(item.Cnpj);

                //Define as Entidades
                var escola = new Escola(item.Nome, cnpj);

                //Adiciona as Notificações dos Validates
                AddNotifications(cnpj.Notifications);
                AddNotifications(escola.Notifications);

                if (Invalid)
                    events.Add(_mapper.Map<EventsResult>(new CommandResult(false, $"Escola: {item.Nome} - {item.Cnpj}", "")));

                //Adiciona na Lista

                lst.Add(escola);
            }

            if (events.Count != 0)
                return new CommandResult(false, $"Econtramos {lst.Count} escolas com dados inválidos, realizar a operação novamente!.", events);

            // Persiste no banco
            lst = _repository.InsertList(lst);

            return new CommandResult(true, $"Criado {lst.Count} escolas com sucesso.", _mapper.Map<List<EscolaViewModel>>(lst));
        }

        public async Task<ICommandResult> Handle(UpdateEscolaCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            var escola = await Task.Run(() => _repository.Find(command.Id));

            if (escola == null)
                AddNotification("Escola", "Não foi encontrado escola vinculada a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            escola.UpdateNome(command.Nome);

            _repository.Update(escola);

            return new CommandResult(true, "Escola atualizada com sucesso.", new 
            {
                escola.Id,
                escola.Nome,
                CNPJ = escola.CNPJ.Number,
                Status = escola.Ativo,
                Updated = escola.DataAtualizacao 
            });
        }

        public async Task<ICommandResult> Handle(DeleteEscolaCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            var escola = await Task.Run(() => _repository.Find(command.Id));

            if (escola == null)
                AddNotification("Escola", "Não foi possível encontrar a escola vinculada a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            _repository.Delete(escola);
            return new CommandResult(true, "Escola excluída com sucesso.", null);
        }
    }
}
