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
    public class SerieHandler : Notifiable, IHandler<CreateSerieCommand>, IHandler<DeleteSerieCommand>, IHandler<UpdateSerieCommand>
    {
        private readonly ISerieRepository _repository;
        private readonly IMapper _mapper;

        public SerieHandler(ISerieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICommandResult> Handle(CreateSerieCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            var serie = new Serie(command.Nome, command.IdNivelEnsino);

            _repository.Insert(serie);

            return new CommandResult(true, "Serie inserida com sucesso.", _mapper.Map<SerieViewModel>(serie));
        }

        public async Task<ICommandResult> Handle(DeleteSerieCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            var serie = await _repository.Find(command.Id);

            if (serie == null)
                AddNotification("Serie", "Não foi possível encontrar o Nível de ensino vinculado a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            _repository.Delete(serie);
            return new CommandResult(true, "Serie excluída com sucesso.", null);
        }

        public async Task<ICommandResult> Handle(UpdateSerieCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Ops...", command.Notifications);

            var serie = await _repository.Find(command.Id);

            if (serie == null)
                AddNotification("serie", "Não foi encontrado uma série vinculada a este id.");

            if (Invalid)
                return new CommandResult(false, "Ops...", Notifications);

            serie.UpdateNome(command.Nome);

            _repository.Update(serie);

            return new CommandResult(true, "Nível de Ensino atualizado com sucesso.", new { serie.Id, serie.Nome, Updated = serie.DataAtualizacao });
        }

    }
}