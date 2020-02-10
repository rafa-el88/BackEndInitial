using AutoMapper;
using PositivoCore.Application.Commands;
using PositivoCore.Application.Interface.Services;
using PositivoCore.Application.Queries;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Commands;
using PositivoCore.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Services
{
    public class DisciplinaServices : IDisciplinaServices
    {
        private readonly IDisciplinaQuery _disciplinaQuery;
        private readonly IMapper _mapper;
        private readonly IHandler<CreateDisciplinaCommand> _handlerCriarDisciplina;
        private readonly IHandler<DeleteDisciplinaCommand> _handlerDeletarDisciplina;
        private readonly IHandler<UpdateDisiplinaCommand> _handlerEditarDisciplina;

        public DisciplinaServices(IDisciplinaQuery disciplinaQuery,
        IMapper mapper,
        IHandler<CreateDisciplinaCommand> handlerCriarDisciplina,
        IHandler<DeleteDisciplinaCommand> handlerDeletarDisciplina,
        IHandler<UpdateDisiplinaCommand> handlerEditarDisciplina)
        {
            _disciplinaQuery = disciplinaQuery;
            _mapper = mapper;
            _handlerCriarDisciplina = handlerCriarDisciplina;
            _handlerDeletarDisciplina = handlerDeletarDisciplina;
            _handlerEditarDisciplina = handlerEditarDisciplina;
        }

        public async Task<IEnumerable<DisciplinaViewModel>> GetAllDisciplinas()
        {
            return _mapper.Map<List<DisciplinaViewModel>>(await _disciplinaQuery.GetAllDisciplinas());
        }

        public async Task<DisciplinaViewModel> GetDisciplinaByID(Guid idDisciplina)
        {
            return _mapper.Map<DisciplinaViewModel>(await _disciplinaQuery.GetDisciplinaById(idDisciplina));
        }

        public async Task<IEnumerable<DisciplinaViewModel>> GetDisciplinaByNome(string nome)
        {
            return _mapper.Map<List<DisciplinaViewModel>>(await _disciplinaQuery.GetDisciplinaByNome(nome));
        }

        public async Task<ICommandResult> NewDisciplina(CreateDisciplinaCommand command)
        {
            return await _handlerCriarDisciplina.Handle(command);
        }

        public async Task<ICommandResult> UpdateDisciplina(UpdateDisiplinaCommand command)
        {
            return await _handlerEditarDisciplina.Handle(command);
        }

        public async Task<ICommandResult> DeletarDisciplina(Guid idDisciplina)
        {
            DeleteDisciplinaCommand command = new DeleteDisciplinaCommand(idDisciplina);
            return await _handlerDeletarDisciplina.Handle(command);
        }
    }
}
