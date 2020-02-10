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
    public class DisciplinaQuery : IDisciplinaQuery
    {        
        private readonly SqlConnection sqlConnection;

        #region Querys
        private string _queryObtemDisciplinas
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
                        FROM Disciplina (NOLOCK);
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
                        FROM Disciplina (NOLOCK)
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
                        FROM Disciplina (NOLOCK) 
                        WHERE 
                            Nome LIKE @Nome;
                    ";
            }
        }
        #endregion

        public DisciplinaQuery(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(HelperConnectionString.Get());
        }

        public async Task<IEnumerable<Disciplina>> GetAllDisciplinas()
        {
            return await sqlConnection.QueryAsync<Disciplina>(_queryObtemDisciplinas);
        }

        public async Task<Disciplina> GetDisciplinaById(Guid id)
        {
            return await sqlConnection.QueryFirstOrDefaultAsync<Disciplina>(_queryObtemPorId, new { Id = id });
        }

        public async Task<IEnumerable<Disciplina>> GetDisciplinaByNome(string nome)
        {
            return await sqlConnection.QueryAsync<Disciplina>(_queryObtemPorNome, new { Nome = "%" + nome + "%" });
        }
    }
}
