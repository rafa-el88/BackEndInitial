namespace PositivoCore.Shared.Commands
{
    public interface ICommandResult
    {
        public bool Sucesso { get; set; }
        public string Menssagem { get; set; }
        public object Dados { get; set; }
    }
}