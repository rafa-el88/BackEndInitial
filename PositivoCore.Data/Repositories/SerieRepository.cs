using PositivoCore.Domain.Entities;
using PositivoCore.Data.Context;
using PositivoCore.Application.Interface.Repository;

namespace PositivoCore.Data.Repositories
{
    public class SerieRepository : Repository<Serie>, ISerieRepository
    {
        public SerieRepository(CoreContext context) : base(context)
        {
        }
    }
}