using PositivoCore.Domain.Entities;
using PositivoCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Queries
{
    public interface IDestinatarioMensagemQuery
    {
        Task<IEnumerable<DestinatarioMensagem>> GetAllDestinatarioMensagens();
        Task<DestinatarioMensagem> GetDestinatarioMensagemById(Guid id);
        Task<IEnumerable<DestinatarioMensagem>> GetDestinatarioMensagemByTipoPerfil(ETipoPerfil tipoPerfil);
        Task<IEnumerable<DestinatarioMensagem>> GetDestinatarioMensagemByMensagem(Guid idMensagem);
    }
}
    