using System.Threading.Tasks;
using AutoMapper;
using Flunt.Notifications;
using PositivoCore.Application.Commands;
using PositivoCore.Application.Commands.ConvidadosEventos;
using PositivoCore.Application.Interface.Repository;
using PositivoCore.Domain.Entities;
using PositivoCore.Shared.Commands;
using PositivoCore.Shared.Handlers;

namespace PositivoCore.Application.Handlers
{
    public class ConvidadosEventoHandler : Notifiable,
        IHandler<CreateConvidadosEventoCommand>,
        IHandler<UpdateConvidadosEventoCommand>,
        IHandler<DeleteConvidadosEventoCommand>
    {
        private readonly IConvidadosEventoRepository _repository;
        private readonly IMapper _mapper;
        public ConvidadosEventoHandler(IConvidadosEventoRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ICommandResult> Handle(CreateConvidadosEventoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "...Ops!", null);

            var convidadosEvento = new ConvidadosEvento(command.Nome, command.TipoPerfil, command.IdConvidado);

            _repository.Insert(convidadosEvento);
            return new CommandResult(true, "Convidado criado com sucesso!", new
            {
                convidadosEvento.Id,
                convidadosEvento.Nome,
                TipoPerfil = convidadosEvento.TipoPerfil,
                IdConvidado = convidadosEvento.IdConvidado,
                Create = convidadosEvento.DataCadastro
            });
        }
        public async Task<ICommandResult> Handle(UpdateConvidadosEventoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "...Ops!", null);

            var convidadosEvento = await _repository.Find(command.Id);
            if (convidadosEvento == null)
                return new CommandResult(false, "Não foi encotnrado nenhum convidado vinculado a este id", null);

            convidadosEvento.Update(command.Nome);
            _repository.Update(convidadosEvento);

            return new CommandResult(true, "Convidado atualizado com sucesso!", new
            {
                convidadosEvento.Id,
                convidadosEvento.Nome,
                TipoPerfil = convidadosEvento.TipoPerfil,
                IdConvidado = convidadosEvento.IdConvidado,
                DateUpdate = convidadosEvento.DataAtualizacao
            });
        }

        public async Task<ICommandResult> Handle(DeleteConvidadosEventoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "...Ops!", null);

            var convidadosEventoExiste = await _repository.Find(command.Id);
            if (convidadosEventoExiste != null)
                return new CommandResult(false, "Não foi encotnrado nenhum convidado vinculado a este id", null);
            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            _repository.Delete(convidadosEventoExiste);
            return new CommandResult(true, "Convidado deletado com sucesso!", null);
        }
    }
}