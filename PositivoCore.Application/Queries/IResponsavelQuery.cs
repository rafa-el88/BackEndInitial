using PositivoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Queries
{
	public interface IResponsavelQuery
	{
		Task<IEnumerable<Responsavel>> GetAllResponsavel();
		Task<Responsavel> GetResponsavelPorId(Guid id);
		Task<IEnumerable<Responsavel>> GetResponsavelPorNome(string nome);
	}
}
