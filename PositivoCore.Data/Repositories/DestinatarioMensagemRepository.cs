using PositivoCore.Domain.Entities;
using PositivoCore.Data.Context;
using PositivoCore.Application.Interface.Repository;

namespace PositivoCore.Data.Repositories
{
    public class DestinatarioMensagemRepository : Repository<DestinatarioMensagem>, IDestinatarioMensagemRepository
    {
        public DestinatarioMensagemRepository(CoreContext context) : base(context)
        {
        }
    }
}