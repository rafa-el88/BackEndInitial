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
    public class NivelEnsinoQuery : INivelEnsinoQuery
    {
        private readonly SqlConnection sqlConnection;

        #region Querys
        private string _queryObtemNiveisEnsino
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
                        FROM NivelEnsino (NOLOCK)
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
                        FROM NivelEnsino (NOLOCK)
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
                        FROM NivelEnsino (NOLOCK)
                        WHERE 
                            Nome LIKE @Nome;
                    ";
            }
        }
        #endregion

        public NivelEnsinoQuery(IConfiguration configuration)
        {
            var connectionString = HelperConnectionString.Get();
            sqlConnection = new SqlConnection(connectionString);
        }

        public async Task<IEnumerable<NivelEnsino>> GetAllNiveisEnsino()
        {
            return await sqlConnection.QueryAsync<NivelEnsino>(_queryObtemNiveisEnsino);
        }

        public async Task<NivelEnsino> GetNivelEnsinoByID(Guid id)
        {
            return await sqlConnection.QueryFirstOrDefaultAsync<NivelEnsino>(_queryObtemPorId, new { Id = id });
        }

        public async Task<IEnumerable<NivelEnsino>> GetNivelEnsinoByNome(string nome)
        {
            return await sqlConnection.QueryAsync<NivelEnsino>(_queryObtemPorNome, new { Nome = "%" + nome + "%" });
        }
    }
}
