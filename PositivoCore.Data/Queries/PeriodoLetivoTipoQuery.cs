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
    public class PeriodoLetivoTipoQuery : IPeriodoLetivoTipoQuery
    {
        private readonly SqlConnection sqlConnection;

        #region Querys
        private string _queryObtemPeriodoLetivoTipos
        {
            get
            {
                return
                    @"
                        SELECT 
                            Id, 
                            Nome, 
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM PeriodoLetivoTipo (NOLOCK);
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
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM PeriodoLetivoTipo (NOLOCK)
                        WHERE 
                            Id = @Id;
                    ";
            }
        }

        private string _queryObtemPorNome
        {
            get
            {
                return
                    @"
                        SELECT 
                            Id, 
                            Nome, 
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM PeriodoLetivoTipo (NOLOCK) 
                        WHERE 
                            Nome LIKE @Nome;
                    ";
            }
        }
        #endregion

        public PeriodoLetivoTipoQuery(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(HelperConnectionString.Get());
        }

        public async Task<IEnumerable<PeriodoLetivoTipo>> GetAllPeriodoLetivoTipos()
        {
            return await sqlConnection.QueryAsync<PeriodoLetivoTipo>(_queryObtemPeriodoLetivoTipos);
        }

        public async Task<PeriodoLetivoTipo> GetPeriodoLetivoTipoPorId(Guid id)
        {
            return await sqlConnection.QueryFirstOrDefaultAsync<PeriodoLetivoTipo>(_queryObtemPorId, new { Id = id });
        }

        public async Task<IEnumerable<PeriodoLetivoTipo>> GetPeriodoLetivoTipoPorNome(string nome)
        {
            return await sqlConnection.QueryAsync<PeriodoLetivoTipo>(_queryObtemPorNome, new { Nome = "%" + nome + "%" });
        }
    }
}
