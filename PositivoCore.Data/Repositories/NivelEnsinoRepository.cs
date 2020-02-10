using PositivoCore.Domain.Entities;
using PositivoCore.Data.Context;
using PositivoCore.Application.Interface.Repository;

namespace PositivoCore.Data.Repositories
{
    public class NivelEnsinoRepository : Repository<NivelEnsino>, INivelEnsinoRepository
    {
        public NivelEnsinoRepository(CoreContext context) : base(context)
        {
        }
    }
}