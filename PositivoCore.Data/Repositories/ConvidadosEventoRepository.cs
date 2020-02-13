using PositivoCore.Application.Interface.Repository;
using PositivoCore.Data.Context;
using PositivoCore.Domain.Entities;

namespace PositivoCore.Data.Repositories
{
    public class ConvidadosEventoRepository : Repository<ConvidadosEvento>, IConvidadosEventoRepository
    {
        public ConvidadosEventoRepository(CoreContext context) : base(context) { }
    }
}