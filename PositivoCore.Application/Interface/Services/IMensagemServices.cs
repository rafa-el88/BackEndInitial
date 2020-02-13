using PositivoCore.Application.Commands;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Interface.Services
{
    public interface IMensagemServices
    {
        Task<IEnumerable<MensagemViewModel>> GetAllMensagens();
        Task<MensagemViewModel> GetMensagemById(Guid idMensagem);
        Task<IEnumerable<MensagemViewModel>> GetMensagemByAssunto(string assunto);
        Task<ICommandResult> CreateMensagem(CreateMensagemCommand command);
        Task<ICommandResult> UpdateMensagem(UpdateMensagemCommand command);
        Task<ICommandResult> DeleteMensagem(Guid idMensagem);
    }
}
