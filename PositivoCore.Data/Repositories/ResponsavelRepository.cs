using PositivoCore.Application.Interface.Repository;
using PositivoCore.Data.Context;
using PositivoCore.Domain.Entities;

namespace PositivoCore.Data.Repositories
{
	public class ResponsavelRepository : Repository<Responsavel>, IResponsavelRepository
	{
		public ResponsavelRepository(CoreContext context) : base(context)
		{
		}
	}
}
