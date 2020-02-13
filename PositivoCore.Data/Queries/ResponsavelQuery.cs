using Dapper;
using Microsoft.Data.SqlClient;
using PositivoCore.Application.Queries;
using PositivoCore.Domain.Entities;
using PositivoCore.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Data.Queries
{
	public class ResponsavelQuery : IResponsavelQuery
	{
        private readonly SqlConnection sqlConnection;
        public ResponsavelQuery(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(HelperConnectionString.Get());
        }


        #region Querys
        private string _queryObtemResponsavel
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
                        FROM Responsavel (NOLOCK);
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
                        FROM Responsavel (NOLOCK)
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
                        FROM Responsavel (NOLOCK) 
                        WHERE 
                            Nome LIKE @Nome;
                    ";
            }
        }
        #endregion

        public async Task<IEnumerable<Responsavel>> GetAllResponsavel()
        {
            return await sqlConnection.QueryAsync<Responsavel>(_queryObtemResponsavel);
        }

        public async Task<Responsavel> GetResponsavelPorId(Guid id)
        {
            return await sqlConnection.QueryFirstOrDefaultAsync<Responsavel>(_queryObtemPorId, new { Id = id });
        }

        public async Task<IEnumerable<Responsavel>> GetResponsavelPorNome(string nome)
        {
            return await sqlConnection.QueryAsync<Responsavel>(_queryObtemPorNome, new { Nome = "%" + nome + "%" });
        }

    }
}
