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
    public class ProfessorQuery : IProfessorQuery
    {
        private readonly SqlConnection sqlConnection;

        #region Querys
        private string _queryObtemProfessores
        {
            get
            {
                return
                    @"
                        SELECT 
                            Id, 
                            Nome, 
                            CPF, 
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM Professor (NOLOCK);
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
                            CPF, 
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM Professor (NOLOCK)
                        WHERE 
                            Id = @Id;
                    ";
            }
        }

        private string _queryObtemPorCPF
        {
            get
            {
                return
                    @"
                        SELECT 
                            Id, 
                            Nome, 
                            CPF, 
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM Professor (NOLOCK) 
                        WHERE 
                            CPF = @CPF;
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
                            CPF, 
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM Professor (NOLOCK) 
                        WHERE 
                            Nome LIKE @Nome;
                    ";
            }
        }
        #endregion

        public ProfessorQuery(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(HelperConnectionString.Get());
        }

        public async Task<IEnumerable<Professor>> GetAllProfessores()
        {
            return await sqlConnection.QueryAsync<Professor>(_queryObtemProfessores);
        }

        public async Task<Professor> GetProfessorPorId(Guid id)
        {
            return await sqlConnection.QueryFirstOrDefaultAsync<Professor>(_queryObtemPorId, new { Id = id });
        }

        public async Task<Professor> GetProfessorPorCPF(string cpf)
        {
            return await sqlConnection.QueryFirstOrDefaultAsync<Professor>(_queryObtemPorCPF, new { CPF = cpf });
        }

        public async Task<IEnumerable<Professor>> GetProfessorPorNome(string nome)
        {
            return await sqlConnection.QueryAsync<Professor>(_queryObtemPorNome, new { Nome = "%" + nome + "%" });
        }
    }
}
