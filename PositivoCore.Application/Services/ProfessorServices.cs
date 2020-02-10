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
    public class ProfessorServices : IProfessorServices
    {
        private readonly IProfessorQuery _professorQuery;
        private readonly IMapper _mapper;
        private readonly IHandler<CreateProfessorCommand> _handlerCriarProfessor;
        private readonly IHandler<DeleteProfessorCommand> _handlerDeletarProfessor;
        private readonly IHandler<UpdateProfessorCommand> _handlerEditarProfessor;

        public ProfessorServices(IProfessorQuery professorQuery, IMapper mapper, IHandler<CreateProfessorCommand> handlerCriarProfessor, IHandler<DeleteProfessorCommand> handlerDeletarProfessor, IHandler<UpdateProfessorCommand> handlerEditarProfessor)
        {
            _professorQuery = professorQuery;
            _mapper = mapper;
            _handlerCriarProfessor = handlerCriarProfessor;
            _handlerDeletarProfessor = handlerDeletarProfessor;
            _handlerEditarProfessor = handlerEditarProfessor;
        }

        public async Task<IEnumerable<ProfessorViewModel>> GetAllProfessores()
        {
            return _mapper.Map<IEnumerable<ProfessorViewModel>>(await _professorQuery.GetAllProfessores());
        }

        public async Task<ProfessorViewModel> GetProfessorById(Guid idProfessor)
        {
            return _mapper.Map<ProfessorViewModel>(await _professorQuery.GetProfessorPorId(idProfessor));
        }

        public async Task<ProfessorViewModel> GetProfessorByCPF(string cpf)
        {
            return _mapper.Map<ProfessorViewModel>(await _professorQuery.GetProfessorPorCPF(cpf));
        }

        public async Task<IEnumerable<ProfessorViewModel>> GetProfessorByNome(string nome)
        {
            return _mapper.Map<List<ProfessorViewModel>>(await _professorQuery.GetProfessorPorNome(nome));
        }

        public async Task<ICommandResult> NewProfessor(CreateProfessorCommand command)
        {
            return await _handlerCriarProfessor.Handle(command);
        }

        public async Task<ICommandResult> UpdateProfessor(UpdateProfessorCommand command)
        {
            return await _handlerEditarProfessor.Handle(command);
        }

        public async Task<ICommandResult> DeletarProfessor(Guid idProfessor)
        {
            DeleteProfessorCommand command = new DeleteProfessorCommand(idProfessor);
            return await _handlerDeletarProfessor.Handle(command);
        }
    }
}
