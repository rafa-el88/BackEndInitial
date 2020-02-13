using PositivoCore.Domain.Entities;
using PositivoCore.Data.Context;
using PositivoCore.Application.Interface.Repository;

namespace PositivoCore.Data.Repositories
{
    public class ColecaoRepository : Repository<Colecao>, IColecaoRepository
    {
        public ColecaoRepository(CoreContext context) : base(context)
        {
        }
    }
}