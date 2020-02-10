using Microsoft.Extensions.Configuration;
using System.IO;

namespace PositivoCore.Shared.Helper
{
    public static class HelperConnectionString
    {
        public static string Get()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            var enviroment = root.GetSection("Enviroment").Value;

            return enviroment switch
            {
                "LOCAL" => root.GetSection("ConnectionStrings:LocalConnection").Value,
                _ => root.GetSection("ConnectionStrings:DevAzureConnection").Value,
            };
        }
    }
}
