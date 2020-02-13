using PositivoCore.Application.Commands;
using PositivoCore.Application.ViewModels;
using PositivoCore.Domain.Enums;
using PositivoCore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Interface.Services
{
    public interface IDestinatarioMensagemServices
    {
        Task<IEnumerable<DestinatarioMensagemViewModel>> GetAllDestinatarioMensagens();
        Task<DestinatarioMensagemViewModel> GetDestinatarioMensagemById(Guid id);
        Task<IEnumerable<DestinatarioMensagemViewModel>> GetDestinatarioMensagemByTipoPerfil(ETipoPerfil tipoPerfil);
        Task<IEnumerable<DestinatarioMensagemViewModel>> GetDestinatarioMensagemByMensagem(Guid idMensagem);
        Task<ICommandResult> CreateDestinatarioMensagem(CreateDestinatarioMensagemCommand command);
        Task<ICommandResult> UpdateDestinatarioMensagem(UpdateDestinatarioMensagemCommand command);
        Task<ICommandResult> DeleteDestinatarioMensagem(Guid idDestinatarioMensagem);
    }
}
