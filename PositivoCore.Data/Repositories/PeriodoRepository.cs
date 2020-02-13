using PositivoCore.Domain.Entities;
using PositivoCore.Data.Context;
using PositivoCore.Application.Interface.Repository;

namespace PositivoCore.Data.Repositories
{
    public class PeriodoRepository : Repository<Periodo>, IPeriodoRepository
    {
        public PeriodoRepository(CoreContext context) : base(context)
        {
        }
    }
}