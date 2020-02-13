using PositivoCore.Domain.Entities;
using PositivoCore.Data.Context;
using PositivoCore.Application.Interface.Repository;

namespace PositivoCore.Data.Repositories
{
    public class PeriodoLetivoConfiguracaoRepository : Repository<PeriodoLetivoConfiguracao>, IPeriodoLetivoConfiguracaoRepository
    {
        public PeriodoLetivoConfiguracaoRepository(CoreContext context) : base(context)
        {
        }
    }
}