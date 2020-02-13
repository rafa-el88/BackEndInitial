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
    public class MensagemQuery : IMensagemQuery
    {
        private readonly SqlConnection sqlConnection;

        #region Querys
        private string _queryObtemMensagens
        {
            get
            {
                return
                    @"
                        SELECT 
                            Id, 
                            Assunto, 
                            Texto,
                            PermiteResposta,
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM Mensagem (NOLOCK);
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
                            Assunto, 
                            Texto,
                            PermiteResposta,
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM Mensagem (NOLOCK)
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
                            Assunto, 
                            Texto,
                            PermiteResposta,
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM Mensagem (NOLOCK) 
                        WHERE 
                            Assunto LIKE @Assunto;
                    ";
            }
        }
        #endregion

        public MensagemQuery(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(HelperConnectionString.Get());
        }

        public async Task<IEnumerable<Mensagem>> GetAllMensagens()
        {
            return await sqlConnection.QueryAsync<Mensagem>(_queryObtemMensagens);
        }

        public async Task<Mensagem> GetMensagemById(Guid id)
        {
            return await sqlConnection.QueryFirstOrDefaultAsync<Mensagem>(_queryObtemPorId, new { Id = id });
        }

        public async Task<IEnumerable<Mensagem>> GetMensagemByAssunto(string assunto)
        {
            return await sqlConnection.QueryAsync<Mensagem>(_queryObtemPorNome, new { Assunto = "%" + assunto + "%" });
        }
    }
}
