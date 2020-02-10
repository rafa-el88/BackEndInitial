using AutoMapper;
using PositivoCore.Application.Commands;
using PositivoCore.Application.Commands.Aluno;
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
    public class AlunoServices : IAlunoServices
    {
        private readonly IAlunoQuery _alunoQuery;
        private readonly IMapper _mapper;
        private readonly IHandler<CreateAlunoCommand> _handlerCriarAluno;
        private readonly IHandler<DeleteAlunoCommand> _handlerDeletarAluno;
        private readonly IHandler<UpdateAlunoCommand> _handlerEditarAluno;
        private readonly IHandler<CreateListStudentsCommand> _handlerCreateStudentsFromList;
        private readonly IHandler<UpdateListStudentsCommand> _handlerUpdateStudentsFromList;
        private readonly IHandler<DeleteListStudentsCommand> _handlerDeleteStudentsFromList;

        public AlunoServices(
            IAlunoQuery alunoQuery, 
            IMapper mapper, 
            IHandler<CreateAlunoCommand> handlerCriarAluno, 
            IHandler<DeleteAlunoCommand> handlerDeletarAluno, 
            IHandler<UpdateAlunoCommand> handlerEditarAluno,
            IHandler<CreateListStudentsCommand> handlerCreateStudentsFromList,
            IHandler<UpdateListStudentsCommand> handlerUpdateStudentsFromList,
            IHandler<DeleteListStudentsCommand> handlerDeleteStudentsFromList)
        {
            _alunoQuery = alunoQuery;
            _mapper = mapper;
            _handlerCriarAluno = handlerCriarAluno;
            _handlerDeletarAluno = handlerDeletarAluno;
            _handlerEditarAluno = handlerEditarAluno;
            _handlerCreateStudentsFromList = handlerCreateStudentsFromList;
            _handlerUpdateStudentsFromList = handlerUpdateStudentsFromList;
            _handlerDeleteStudentsFromList = handlerDeleteStudentsFromList;
        }

        public async Task<IEnumerable<AlunoViewModel>> GetAllAlunos()
        {
            var entity = await _alunoQuery.GetAllAlunos();
            return _mapper.Map<IEnumerable<AlunoViewModel>>(entity);
        }

        public async Task<AlunoViewModel> GetAlunoById(Guid idAluno)
        {
            var entity = await _alunoQuery.GetAlunoPorId(idAluno);
            return _mapper.Map<AlunoViewModel>(entity);
        }

        public async Task<IEnumerable<AlunoViewModel>> GetAlunoByNome(string nome)
        {
            return _mapper.Map<List<AlunoViewModel>>(await _alunoQuery.GetAlunoPorNome(nome));
        }

        public async Task<ICommandResult> NewAluno(CreateAlunoCommand command)
        {
            var result = await _handlerCriarAluno.Handle(command);
            return result;
        }

        public async Task<ICommandResult> UpdateAluno(UpdateAlunoCommand command)
        {
            return await _handlerEditarAluno.Handle(command);
        }

        public async Task<ICommandResult> DeletarAluno(Guid idAluno)
        {
            DeleteAlunoCommand command = new DeleteAlunoCommand(idAluno);
            return await _handlerDeletarAluno.Handle(command);
        }

        public async Task<ICommandResult> NewListStudents(List<AlunoViewModel> lst)
        {
            CreateListStudentsCommand command = new CreateListStudentsCommand(lst);
            return await _handlerCreateStudentsFromList.Handle(command);
        }

        public async Task<ICommandResult> UpdateListStudents(List<AlunoViewModel> lst)
        {
            UpdateListStudentsCommand command = new UpdateListStudentsCommand(lst);
            return await _handlerUpdateStudentsFromList.Handle(command);
        }

        public async Task<ICommandResult> DeleteListStudents(List<Guid> lst)
        {
            DeleteListStudentsCommand command = new DeleteListStudentsCommand(lst);
            return await _handlerDeleteStudentsFromList.Handle(command);
        }
    }
}
