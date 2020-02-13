using PositivoCore.Domain.Entities;
using PositivoCore.Data.Context;
using PositivoCore.Application.Interface.Repository;

namespace PositivoCore.Data.Repositories
{
    public class PeriodoLetivoTipoRepository : Repository<PeriodoLetivoTipo>, IPeriodoLetivoTipoRepository
    {
        public PeriodoLetivoTipoRepository(CoreContext context) : base(context)
        {
        }
    }
}