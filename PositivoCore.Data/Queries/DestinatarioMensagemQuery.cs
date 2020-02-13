using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PositivoCore.Application.Queries;
using PositivoCore.Domain.Entities;
using PositivoCore.Domain.Enums;
using PositivoCore.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PositivoCore.Data.Queries
{
    public class DestinatarioMensagemQuery : IDestinatarioMensagemQuery
    {
        private readonly SqlConnection sqlConnection;

        #region Querys
        private string _queryObtemDestinatarioMensagens
        {
            get
            {
                return
                    @"
                        SELECT 
                            Id, 
                            TipoPerfil, 
                            IdDestinatario,
                            IdMensagem,
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao  
                        FROM DestinatarioMensagem (NOLOCK);
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
                            TipoPerfil, 
                            IdDestinatario,
                            IdMensagem,
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM DestinatarioMensagem (NOLOCK)
                        WHERE 
                            Id = @Id;
                    ";
            }
        }

        private string _queryObtemPorTipoPerfil
        {
            get
            {
                return
                    @"
                        SELECT 
                            Id, 
                            TipoPerfil, 
                            IdDestinatario,
                            IdMensagem,
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM DestinatarioMensagem (NOLOCK) 
                        WHERE 
                            TipoPerfil = @TipoPerfil;
                    ";
            }
        }

        private string _queryObtemPorMensagem
        {
            get
            {
                return
                    @"
                        SELECT 
                            Id, 
                            TipoPerfil, 
                            IdDestinatario,
                            IdMensagem,
                            Ativo, 
                            DataCadastro, 
                            DataAtualizacao 
                        FROM DestinatarioMensagem (NOLOCK) 
                        WHERE 
                            IdMensagem = @IdMensagem;
                    ";
            }
        }
        #endregion

        public DestinatarioMensagemQuery(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(HelperConnectionString.Get());
        }

        public async Task<IEnumerable<DestinatarioMensagem>> GetAllDestinatarioMensagens()
        {
            return await sqlConnection.QueryAsync<DestinatarioMensagem>(_queryObtemDestinatarioMensagens);
        }

        public async Task<DestinatarioMensagem> GetDestinatarioMensagemById(Guid id)
        {
            return await sqlConnection.QueryFirstOrDefaultAsync<DestinatarioMensagem>(_queryObtemPorId, new { Id = id });
        }

        public async Task<IEnumerable<DestinatarioMensagem>> GetDestinatarioMensagemByTipoPerfil(ETipoPerfil tipoPerfil)
        {
            return await sqlConnection.QueryAsync<DestinatarioMensagem>(_queryObtemPorTipoPerfil, new { TipoPerfil = tipoPerfil });
        }

        public async Task<IEnumerable<DestinatarioMensagem>> GetDestinatarioMensagemByMensagem(Guid idMensagem)
        {
            return await sqlConnection.QueryAsync<DestinatarioMensagem>(_queryObtemPorMensagem, new { IdMensagem = idMensagem });
        }
    }
}
