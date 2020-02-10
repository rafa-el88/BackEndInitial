using PositivoCore.Shared.Commands;

namespace PositivoCore.Application.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool sucesso, string menssagem, object dados)
        {
            Sucesso = sucesso;
            Menssagem = menssagem;
            Dados = dados;
        }
        public bool Sucesso { get; set; }
        public string Menssagem { get; set; }
        public object Dados { get; set; }
    }
}