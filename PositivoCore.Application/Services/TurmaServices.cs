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
    public class TurmaServices : ITurmaServices
    {
        private readonly ITurmaQuery _turmaQuery;
        private readonly IMapper _mapper;
        private readonly IHandler<CreateTurmaCommand> _handlerCriarTurma;
        private readonly IHandler<DeleteTurmaCommand> _handlerDeletarTurma;
        private readonly IHandler<AttachTurmaDisciplinaProfessorCommand> _handlerVincularTurma;
        private readonly IHandler<UpdateTurmaCommand> _handlerEditarTurma;

        public TurmaServices(ITurmaQuery turmaQuery, IMapper mapper, IHandler<CreateTurmaCommand> handlerCriarTurma, IHandler<DeleteTurmaCommand> handlerDeletarTurma, IHandler<AttachTurmaDisciplinaProfessorCommand> handlerVincularTurma, IHandler<UpdateTurmaCommand> handlerEditarTurma)
        {
            _turmaQuery = turmaQuery;
            _mapper = mapper;
            _handlerCriarTurma = handlerCriarTurma;
            _handlerDeletarTurma = handlerDeletarTurma;
            _handlerVincularTurma = handlerVincularTurma;
            _handlerEditarTurma = handlerEditarTurma;
        }

        public async Task<IEnumerable<TurmaViewModel>> GetAllTurmas()
        {
            return _mapper.Map<List<TurmaViewModel>>(await _turmaQuery.GetAllTurmas());
        }

        public async Task<TurmaViewModel> GetTurmaByID(Guid idTurma)
        {
            return _mapper.Map<TurmaViewModel>(await _turmaQuery.GetTurmaByID(idTurma));
        }

        public async Task<IEnumerable<TurmaViewModel>> GetTurmaByNome(string nome)
        {
            return _mapper.Map<List<TurmaViewModel>>(await _turmaQuery.GetTurmaByNome(nome));
        }

        public async Task<ICommandResult> NewTurma(CreateTurmaCommand command)
        {
            return await _handlerCriarTurma.Handle(command);
        }

        public async Task<ICommandResult> DeletarTurma(Guid idTurma)
        {
            DeleteTurmaCommand command = new DeleteTurmaCommand(idTurma);
            return await _handlerDeletarTurma.Handle(command);
        }

        public async Task<ICommandResult> UpdateTurma(UpdateTurmaCommand command)
        {
            return await _handlerEditarTurma.Handle(command);
        }

        public async Task<ICommandResult> AttachTurmaDisciplinaProfessor(List<TurmaDisciplinaProfessorViewModel> obj)
        {
            AttachTurmaDisciplinaProfessorCommand cmd = new AttachTurmaDisciplinaProfessorCommand(obj);
            return await _handlerVincularTurma.Handle(cmd);
        }

    }
}
