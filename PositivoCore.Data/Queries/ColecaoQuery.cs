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
    public class ColecaoQuery : IColecaoQuery
    {
        private readonly SqlConnection sqlConnection;

        #region Querys
        private string _queryObtemColecoes
        {
            get
            {
                return
                    @"
                        SELECT 
                            Id, 
                            Nome, 
                            Padrao,
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM Colecao (NOLOCK);
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
                            Padrao,
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM Colecao (NOLOCK)
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
                            Padrao,
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM Colecao (NOLOCK) 
                        WHERE 
                            Nome LIKE @Nome;
                    ";
            }
        }
        #endregion

        public ColecaoQuery(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(HelperConnectionString.Get());
        }

        public async Task<IEnumerable<Colecao>> GetAllColecoes()
        {
            return await sqlConnection.QueryAsync<Colecao>(_queryObtemColecoes);
        }

        public async Task<Colecao> GetColecaoPorId(Guid id)
        {
            return await sqlConnection.QueryFirstOrDefaultAsync<Colecao>(_queryObtemPorId, new { Id = id });
        }

        public async Task<IEnumerable<Colecao>> GetColecaoPorNome(string nome)
        {
            return await sqlConnection.QueryAsync<Colecao>(_queryObtemPorNome, new { Nome = "%" + nome + "%" });
        }
    }
}
