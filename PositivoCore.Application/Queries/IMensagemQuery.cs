using PositivoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Queries
{
    public interface IMensagemQuery
    {
        Task<IEnumerable<Mensagem>> GetAllMensagens();
        Task<Mensagem> GetMensagemById(Guid id);
        Task<IEnumerable<Mensagem>> GetMensagemByAssunto(string assunto);
    }
}
