using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PositivoCore.Application.Queries;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Data.Queries
{
    public class EscolaQuery : IEscolaQuery
    {
        private readonly SqlConnection sqlConnection;

        #region Querys
        private string _queryObtemEscolas
        {
            get
            {
                return
                    @"
                        SELECT 
                            Id, 
                            Nome, 
                            CNPJ, 
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM ESCOLA (NOLOCK);
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
                            CNPJ, 
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM ESCOLA (NOLOCK)
                        WHERE 
                            Id = @Id;
                    ";
            }
        }

        private string _queryObtemPorCNPJ
        {
            get
            {
                return
                    @"
                        SELECT 
                            Id, 
                            Nome, 
                            CNPJ, 
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM ESCOLA (NOLOCK) 
                        WHERE 
                            CNPJ = @CNPJ;
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
                            CNPJ, 
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM ESCOLA (NOLOCK) 
                        WHERE 
                            Nome LIKE @NomeEscola;
                    ";
            }
        }
        #endregion

        public EscolaQuery(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(HelperConnectionString.Get());
        }

        public async Task<IEnumerable<EscolaViewModel>> GetAllEscola()
        {
            return await sqlConnection.QueryAsync<EscolaViewModel>(_queryObtemEscolas);
        }

        public async Task<EscolaViewModel> GetEscolaPorId(Guid id)
        {
            return await sqlConnection.QueryFirstOrDefaultAsync<EscolaViewModel>(_queryObtemPorId, new { Id = id });
        }

        public async Task<EscolaViewModel> GetEscolaPorCNPJ(string cnpj)
        {
            return await sqlConnection.QueryFirstOrDefaultAsync<EscolaViewModel>(_queryObtemPorCNPJ, new { CNPJ = cnpj });
        }

        public async Task<IEnumerable<EscolaViewModel>> GetEscolaPorNome(string nome)
        {
            return await sqlConnection.QueryAsync<EscolaViewModel>(_queryObtemPorNome, new { NomeEscola = "%" + nome + "%" });
        }

    }
}
