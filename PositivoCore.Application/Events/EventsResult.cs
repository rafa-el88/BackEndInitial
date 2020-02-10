namespace PositivoCore.Application.Events
{
    public class EventsResult
    {
        public EventsResult(bool sucesso, string menssagem, object dados)
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
