using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PositivoCore.Application.Queries;
using PositivoCore.Domain.Entities;
using PositivoCore.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Data.Queries
{
    public class PeriodoLetivoConfiguracaoQuery : IPeriodoLetivoConfiguracaoQuery
    {
        private readonly SqlConnection sqlConnection;

        #region Querys
        private string _queryObtemPeriodoLetivoConfiguracoes
        {
            get
            {
                return
                    @"
                        SELECT 
                            Id, 
                            Nome, 
                            DtInicio,
                            IdEscola,
                            IdNivelEnsino,
                            IdPeriodoLetivoTipo,
                            IdPeriodo,
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM PeriodoLetivoConfiguracao (NOLOCK);
                    ";
            }
        }

        private string _queryObtemPorId
        {
            get
            {
                return
                    @"
                        SELECT 
                            Id, 
                            Nome, 
                            DtInicio,
                            IdEscola,
                            IdNivelEnsino,
                            IdPeriodoLetivoTipo,
                            IdPeriodo,
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM PeriodoLetivoConfiguracao (NOLOCK)
                        WHERE 
                            Id = @Id;
                    ";
            }
        }
        #endregion

        public PeriodoLetivoConfiguracaoQuery(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(HelperConnectionString.Get());
        }

        public async Task<IEnumerable<PeriodoLetivoConfiguracao>> GetAllPeriodoLetivoConfiguracoes()
        {
            return await sqlConnection.QueryAsync<PeriodoLetivoConfiguracao>(_queryObtemPeriodoLetivoConfiguracoes);
        }

        public async Task<PeriodoLetivoConfiguracao> GetPeriodoLetivoConfiguracaoPorId(Guid id)
        {
            return await sqlConnection.QueryFirstOrDefaultAsync<PeriodoLetivoConfiguracao>(_queryObtemPorId, new { Id = id });
        }

    }
}
