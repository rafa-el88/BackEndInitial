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
    public class TurmaQuery : ITurmaQuery
    {
        private readonly SqlConnection sqlConnection;

        #region Querys
        private string _queryObtemTurmas
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
                            IdEscola,
                            IdSerie
                        FROM Turma (NOLOCK)
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
                            IdEscola,
                            IdSerie
                        FROM Turma (NOLOCK)
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
                            IdEscola,
                            IdSerie
                        FROM Turma (NOLOCK)
                        WHERE 
                            Nome LIKE @Nome;
                    ";
            }
        }
        #endregion

        public TurmaQuery(IConfiguration configuration)
        {
            var connectionString = HelperConnectionString.Get();
            sqlConnection = new SqlConnection(connectionString);
        }

        public async Task<IEnumerable<Turma>> GetAllTurmas()
        {
            return await sqlConnection.QueryAsync<Turma>(_queryObtemTurmas);
        }

        public async Task<Turma> GetTurmaByID(Guid id)
        {
            return await sqlConnection.QueryFirstOrDefaultAsync<Turma>(_queryObtemPorId, new { Id = id });
        }

        public async Task<IEnumerable<Turma>> GetTurmaByNome(string nome)
        {
            return await sqlConnection.QueryAsync<Turma>(_queryObtemPorNome, new { Nome = "%" + nome + "%" });
        }
    }
}
