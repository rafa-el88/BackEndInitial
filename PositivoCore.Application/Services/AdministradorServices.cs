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
    public class AdministradorServices : IAdministradorServices
    {
        private readonly IAdministradorQuery _administradorQuery;
        private readonly IMapper _mapper;
        private readonly IHandler<CreateAdministradorCommand> _handlerCriarAdministrador;
        private readonly IHandler<DeleteAdministradorCommand> _handlerDeletarAdministrador;
        private readonly IHandler<UpdateAdministradorCommand> _handlerEditarAdministrador;
        private readonly IHandler<CreateListAdministradoresCommand> _handlerCreateAdministradoresFromList;
        private readonly IHandler<UpdateListAdministradoresCommand> _handlerUpdateAdministradoresFromList;
        private readonly IHandler<DeleteListAdministradoresCommand> _handlerDeleteAdministradoresFromList;

        public AdministradorServices(IAdministradorQuery administradorQuery, IMapper mapper, IHandler<CreateAdministradorCommand> handlerCriarAdministrador, IHandler<DeleteAdministradorCommand> handlerDeletarAdministrador, IHandler<UpdateAdministradorCommand> handlerEditarAdministrador, IHandler<CreateListAdministradoresCommand> handlerCreateAdministradoresFromList, IHandler<UpdateListAdministradoresCommand> handlerUpdateAdministradoresFromList, IHandler<DeleteListAdministradoresCommand> handlerDeleteAdministradoresFromList)
        {
            _administradorQuery = administradorQuery;
            _mapper = mapper;
            _handlerCriarAdministrador = handlerCriarAdministrador;
            _handlerDeletarAdministrador = handlerDeletarAdministrador;
            _handlerEditarAdministrador = handlerEditarAdministrador;
            _handlerCreateAdministradoresFromList = handlerCreateAdministradoresFromList;
            _handlerUpdateAdministradoresFromList = handlerUpdateAdministradoresFromList;
            _handlerDeleteAdministradoresFromList = handlerDeleteAdministradoresFromList;
        }

        public async Task<IEnumerable<AdministradorViewModel>> GetAllAdministradores()
        {
            var entity = await _administradorQuery.GetAllAdministradores();
            return _mapper.Map<IEnumerable<AdministradorViewModel>>(entity);
        }

        public async Task<AdministradorViewModel> GetAdministradorById(Guid idAdministrador)
        {
            var entity = await _administradorQuery.GetAdministradorPorId(idAdministrador);
            return _mapper.Map<AdministradorViewModel>(entity);
        }

        public async Task<IEnumerable<AdministradorViewModel>> GetAdministradorByNome(string nome)
        {
            return _mapper.Map<List<AdministradorViewModel>>(await _administradorQuery.GetAdministradorPorNome(nome));
        }

        public async Task<ICommandResult> NewAdministrador(CreateAdministradorCommand command)
        {
            var result = await _handlerCriarAdministrador.Handle(command);
            return result;
        }

        public async Task<ICommandResult> UpdateAdministrador(UpdateAdministradorCommand command)
        {
            return await _handlerEditarAdministrador.Handle(command);
        }

        public async Task<ICommandResult> DeletarAdministrador(Guid idAdministrador)
        {
            DeleteAdministradorCommand command = new DeleteAdministradorCommand(idAdministrador);
            return await _handlerDeletarAdministrador.Handle(command);
        }

        public async Task<ICommandResult> NewListAdministradores(List<AdministradorViewModel> lst)
        {
            CreateListAdministradoresCommand command = new CreateListAdministradoresCommand(lst);
            return await _handlerCreateAdministradoresFromList.Handle(command);
        }

        public async Task<ICommandResult> UpdateListAdministradores(List<AdministradorViewModel> lst)
        {
            UpdateListAdministradoresCommand command = new UpdateListAdministradoresCommand(lst);
            return await _handlerUpdateAdministradoresFromList.Handle(command);
        }

        public async Task<ICommandResult> DeleteListAdministradores(List<Guid> lst)
        {
            DeleteListAdministradoresCommand command = new DeleteListAdministradoresCommand(lst);
            return await _handlerDeleteAdministradoresFromList.Handle(command);
        }
    }
}
