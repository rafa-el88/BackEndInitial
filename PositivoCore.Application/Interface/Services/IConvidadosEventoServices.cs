using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PositivoCore.Application.Commands.ConvidadosEventos;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Interface.Services
{
    public interface IConvidadosEventoServices
    {
        Task<IEnumerable<ConvidadosEventoViewModel>> GetAllConvidadosEventos();
        Task<ConvidadosEventoViewModel> GetConvidadosEventoByID(Guid idConvidadosEvento);
        Task<IEnumerable<ConvidadosEventoViewModel>> GetConvidadosEventoByNome(string nome);
        Task<ICommandResult> NewConvidadosEvento(CreateConvidadosEventoCommand command);
        Task<ICommandResult> UpdateConvidadosEvento(UpdateConvidadosEventoCommand command);
        Task<ICommandResult> DeletarConvidadosEvento(Guid idConvidadosEvento);
    }
}