using PositivoCore.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Application.Queries
{
    public interface IEscolaQuery
    {
        Task<IEnumerable<EscolaViewModel>> GetAllEscola();

        Task<EscolaViewModel> GetEscolaPorId(Guid id);

        Task<EscolaViewModel> GetEscolaPorCNPJ(string cnpj);

        Task<IEnumerable<EscolaViewModel>> GetEscolaPorNome(string nome);
    }
}
