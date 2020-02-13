using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PositivoCore.Application.Queries;
using PositivoCore.Domain.Entities;
using PositivoCore.Shared.Helper;

namespace PositivoCore.Data.Queries
{
    public class ConvidadosEventoQuery : IConvidadosEventoQuery
    {
        private readonly SqlConnection sqlConnection;
        public ConvidadosEventoQuery(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(HelperConnectionString.Get());
        }

        #region Querys
        private string _queryObtemConvidadosEvento
        {
            get
            {
                return
                    @"
                        SELECT 
                            Id, 
                            Nome, 
                            Ativo,
                            IdConvidado,
                            TipoPerfil, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM ConvidadosEvento (NOLOCK);
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
                            IdConvidado,
                            TipoPerfil,  
                            DataCadastro, 
                            DataAtualizacao 
                        FROM ConvidadosEvento (NOLOCK)
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
                            IdConvidado,
                            TipoPerfil, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM ConvidadosEvento (NOLOCK) 
                        WHERE 
                            Nome LIKE @Nome;
                    ";
            }
        }
        #endregion
        public async Task<IEnumerable<ConvidadosEvento>> GetAllConvidadosEvento() =>
            await sqlConnection.QueryAsync<ConvidadosEvento>(_queryObtemConvidadosEvento);
        public async Task<ConvidadosEvento> GetConvidadosEventoById(Guid id) =>
            await sqlConnection.QueryFirstOrDefaultAsync<ConvidadosEvento>(_queryObtemPorId, new { Id = id });
        public async Task<IEnumerable<ConvidadosEvento>> GetConvidadosEventoByNome(string nome) =>
            await sqlConnection.QueryAsync<ConvidadosEvento>(_queryObtemPorNome, new { Nome = "%" + nome + "%" });
    }
}