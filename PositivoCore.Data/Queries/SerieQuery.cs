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
    public class SerieQuery : ISerieQuery
    {
        private readonly SqlConnection sqlConnection;

        #region Querys
        private string _queryObtemSeries
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
                            DataAtualizacao,
                            IdNivelEnsino
                        FROM Serie (NOLOCK)
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
                            DataAtualizacao,
                            IdNivelEnsino
                        FROM Serie (NOLOCK)
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
                            DataAtualizacao,
                            IdNivelEnsino
                        FROM Serie (NOLOCK)
                        WHERE 
                            Nome LIKE @Nome;
                    ";
            }
        }
        #endregion

        public SerieQuery(IConfiguration configuration)
        {
            var connectionString = HelperConnectionString.Get();
            sqlConnection = new SqlConnection(connectionString);
        }

        public async Task<IEnumerable<Serie>> GetAllSeries()
        {
            return await sqlConnection.QueryAsync<Serie>(_queryObtemSeries);
        }

        public async Task<Serie> GetSerieByID(Guid id)
        {
            return await sqlConnection.QueryFirstOrDefaultAsync<Serie>(_queryObtemPorId, new { Id = id });
        }

        public async Task<IEnumerable<Serie>> GetSerieByNome(string nome)
        {
            return await sqlConnection.QueryAsync<Serie>(_queryObtemPorNome, new { Nome = "%" + nome + "%" });
        }
    }
}
