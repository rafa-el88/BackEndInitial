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
    public class AlunoQuery : IAlunoQuery
    {
        private readonly SqlConnection sqlConnection;

        #region Querys
        private string _queryObtemAlunos
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
                        FROM Aluno (NOLOCK);
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
                        FROM Aluno (NOLOCK)
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
                        FROM Aluno (NOLOCK) 
                        WHERE 
                            Nome LIKE @Nome;
                    ";
            }
        }
        #endregion

        public AlunoQuery(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(HelperConnectionString.Get());
        }

        public async Task<IEnumerable<Aluno>> GetAllAlunos()
        {
            return await sqlConnection.QueryAsync<Aluno>(_queryObtemAlunos);
        }

        public async Task<Aluno> GetAlunoPorId(Guid id)
        {
            return await sqlConnection.QueryFirstOrDefaultAsync<Aluno>(_queryObtemPorId, new { Id = id });
        }

        public async Task<IEnumerable<Aluno>> GetAlunoPorNome(string nome)
        {
            return await sqlConnection.QueryAsync<Aluno>(_queryObtemPorNome, new { Nome = "%" + nome + "%" });
        }
    }
}
