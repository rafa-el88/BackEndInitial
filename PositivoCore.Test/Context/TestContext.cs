using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using PositivoCore.WebApi;
using System.Net.Http;


namespace PositivoCore.Test.Context
{
    public class TestContext
    {
        public HttpClient Client { get; set; }
        public string URL { get; set; }
        public TestContext()
        {
            URL = "http://localhost:5001";
            SetupClient();
        }
        private void SetupClient()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>()
                .UseUrls(URL)
                );
            Client = server.CreateClient();
        }
    }
}
