using PositivoCore.Domain.Entities;
using PositivoCore.Data.Context;
using PositivoCore.Application.Interface.Repository;

namespace PositivoCore.Data.Repositories
{
    public class MensagemRepository : Repository<Mensagem>, IMensagemRepository
    {
        public MensagemRepository(CoreContext context) : base(context)
        {
        }
    }
}