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
    public class AdministradorQuery : IAdministradorQuery
    {
        private readonly SqlConnection sqlConnection;

        #region Querys
        private string _queryObtemAdministradores
        {
            get
            {
                return
                    @"
                        SELECT 
                            Id, 
                            Nome, 
                            Email,
                            Cpf,
                            DataNascimento,
                            Genero,
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM Administrador (NOLOCK);
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
                            Email,
                            Cpf,
                            DataNascimento,
                            Genero,
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM Administrador (NOLOCK)
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
                            Email,
                            Cpf,
                            DataNascimento,
                            Genero,
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM Administrador (NOLOCK) 
                        WHERE 
                            Nome LIKE @Nome;
                    ";
            }
        }
        #endregion

        public AdministradorQuery(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(HelperConnectionString.Get());
        }

        public async Task<IEnumerable<Administrador>> GetAllAdministradores()
        {
            return await sqlConnection.QueryAsync<Administrador>(_queryObtemAdministradores);
        }

        public async Task<Administrador> GetAdministradorPorId(Guid id)
        {
            return await sqlConnection.QueryFirstOrDefaultAsync<Administrador>(_queryObtemPorId, new { Id = id });
        }

        public async Task<IEnumerable<Administrador>> GetAdministradorPorNome(string nome)
        {
            return await sqlConnection.QueryAsync<Administrador>(_queryObtemPorNome, new { Nome = "%" + nome + "%" });
        }
    }
}
