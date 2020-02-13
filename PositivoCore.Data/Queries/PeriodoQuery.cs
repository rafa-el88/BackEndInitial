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
    public class PeriodoQuery : IPeriodoQuery
    {
        private readonly SqlConnection sqlConnection;

        #region Querys
        private string _queryObtemPeriodos
        {
            get
            {
                return
                    @"
                        SELECT 
                            Id, 
                            Nome, 
                            IdPeriodoLetivoTipo,
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM Periodo (NOLOCK);
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
                            IdPeriodoLetivoTipo,
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM Periodo (NOLOCK)
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
                            IdPeriodoLetivoTipo,
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM Periodo (NOLOCK) 
                        WHERE 
                            Nome LIKE @Nome;
                    ";
            }
        }

        private string _queryObtemPorTipo
        {
            get
            {
                return
                    @"
                        SELECT 
                            Id, 
                            Nome, 
                            IdPeriodoLetivoTipo,
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM Periodo (NOLOCK)
                        WHERE 
                            IdPeriodoLetivoTipo = @IdPeriodoLetivoTipo;
                    ";
            }
        }
        #endregion

        public PeriodoQuery(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(HelperConnectionString.Get());
        }

        public async Task<IEnumerable<Periodo>> GetAllPeriodos()
        {
            return await sqlConnection.QueryAsync<Periodo>(_queryObtemPeriodos);
        }

        public async Task<Periodo> GetPeriodoPorId(Guid id)
        {
            return await sqlConnection.QueryFirstOrDefaultAsync<Periodo>(_queryObtemPorId, new { Id = id });
        }

        public async Task<IEnumerable<Periodo>> GetPeriodoPorNome(string nome)
        {
            return await sqlConnection.QueryAsync<Periodo>(_queryObtemPorNome, new { Nome = "%" + nome + "%" });
        }

        public async Task<IEnumerable<Periodo>> GetPeriodoByTipo(Guid idPeriodoLetivoTipo)
        {
            return await sqlConnection.QueryAsync<Periodo>(_queryObtemPorTipo, new { IdPeriodoLetivoTipo = idPeriodoLetivoTipo });
        }

        
    }
}
