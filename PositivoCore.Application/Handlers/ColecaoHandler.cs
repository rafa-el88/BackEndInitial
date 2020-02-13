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
    public class ColecaoHandler : Notifiable,
    IHandler<CreateColecaoCommand>,
    IHandler<DeleteColecaoCommand>,
    IHandler<UpdateColecaoCommand>
    {
        private readonly IColecaoRepository _repository;
        private readonly IMapper _mapper;

        public ColecaoHandler(IColecaoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICommandResult> Handle(CreateColecaoCommand command)
        {
            //Check Command
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            var colecao = _mapper.Map<Colecao>(command);

            _repository.Insert(colecao);

            return new CommandResult(true, "Coleção criada com sucesso.", _mapper.Map<ColecaoViewModel>(colecao));
        }

        public async Task<ICommandResult> Handle(DeleteColecaoCommand command)
        {
            command.Validate();

            var colecao = await _repository.Find(command.Id);

            if (colecao == null)
                AddNotification("Aluno", "Não foi possível encontrar a colecão vinculada a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            _repository.Delete(colecao);

            return new CommandResult(true, "Coleção excluída com sucesso", null);
        }

        public async Task<ICommandResult> Handle(UpdateColecaoCommand command)
        {
            command.Validate();

            var colecao = await _repository.Find(command.Id); 

            if (colecao == null)
                AddNotification("Colecao", "Não foi possível encontrar a coleção vinculada a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            colecao.UpdateFields(_mapper.Map<Colecao>(command));

            _repository.Update(colecao);

            return new CommandResult(true, "Nome atualizado com sucesso.", new { colecao.Id, colecao.Nome, Updated = colecao.DataAtualizacao });
        }
    }
}