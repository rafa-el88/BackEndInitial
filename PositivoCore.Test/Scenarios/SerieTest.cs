using FluentAssertions;
using Newtonsoft.Json;
using PositivoCore.Application.Commands;
using PositivoCore.Application.ViewModels;
using PositivoCore.Test.Context;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PositivoCore.Test.Scenarios
{
    public class SerieTest
    {
        private readonly TestContext _testContext;
        public SerieTest()
        {
            _testContext = new TestContext();
        }

        private async Task<HttpResponseMessage> CreateSerie(CreateSerieCommand cmd)
        {
            string jsoncmd = JsonConvert.SerializeObject(cmd);
            var content = new StringContent(jsoncmd, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PostAsync("/Serie/new", content);
            return response;
        }
        private SerieViewModel ConvertJsonToSerie(string result)
        {
            CommandResult command = JsonConvert.DeserializeObject<CommandResult>(result);
            SerieViewModel evm = JsonConvert.DeserializeObject<SerieViewModel>(command.Dados.ToString());
            return evm;
        }
        private async Task<HttpResponseMessage> DeleteSerie(Guid? Id)
        {
            return await _testContext.Client.DeleteAsync("/Serie/" + Id.ToString());
        }
        private async Task<HttpResponseMessage> UpdateSerie(UpdateSerieCommand cmd)
        {
            string jsoncmd = JsonConvert.SerializeObject(cmd);
            var content = new StringContent(jsoncmd, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PutAsync("/Serie/", content);
            return response;
        }
        private async Task<HttpResponseMessage> GetSeriePorNome(string nome)
        {
            var response = await _testContext.Client.GetAsync("/Serie/Nome/" + nome);
            return response;
        }
        private async Task<HttpResponseMessage> GetSeriePorID(string id)
        {
            var response = await _testContext.Client.GetAsync("/Serie/ID/" + id);
            return response;
        }
        private async Task<HttpResponseMessage> GetAllSeries()
        {
            var response = await _testContext.Client.GetAsync("/Serie/getAll");
            return response;
        }

        [Theory]
        [InlineData("Serie", "751D97BC-6B14-4187-9A3D-005450CDAA53")]
        public async Task Serie_CreateDelete_ReturnsOkResponse(string nome, Guid idNivelEnsino)
        {
            //Testa criar Serie
            CreateSerieCommand cmd = new CreateSerieCommand(nome, idNivelEnsino);
            var response = await CreateSerie(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Serie = ConvertJsonToSerie(response.Content.ReadAsStringAsync().Result);
            Guid? id = Serie.Id;

            //deletar Serie
            response = await DeleteSerie(id);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("Serie", "751D97BC-6B14-4187-9A3D-005450CDAA53")]
        public async Task Serie_CreateUpdateDelete_ReturnsOkResponse(string nome, Guid idNivelEnsino)
        {
            //Testa criar Serie
            CreateSerieCommand cmd = new CreateSerieCommand(nome, idNivelEnsino);
            var response = await CreateSerie(cmd);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Serie = ConvertJsonToSerie(response.Content.ReadAsStringAsync().Result);
            Guid? id = Serie.Id;

            //Atualiza Serie
            UpdateSerieCommand cmdUpdate = new UpdateSerieCommand(Guid.Parse(id.ToString()), "positivo12345");
            response = await UpdateSerie(cmdUpdate);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deletar Serie
            response = await DeleteSerie(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("Serie", "751D97BC-6B14-4187-9A3D-005450CDAA53")]
        public async Task Serie_CreateGetByNomeDelete_ReturnsOkResponse(string nome, Guid idNivelEnsino)
        {
            //Testa criar Serie 
            CreateSerieCommand cmd = new CreateSerieCommand(nome, idNivelEnsino);
            var response = await CreateSerie(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Serie = ConvertJsonToSerie(response.Content.ReadAsStringAsync().Result);
            Guid? id = Serie.Id;

            //Testa busca por Nome
            response = await GetSeriePorNome(nome);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deletar Serie
            response = await DeleteSerie(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("Serie", "751D97BC-6B14-4187-9A3D-005450CDAA53")]
        public async Task Serie_CreateGetByIdDelete_ReturnsOkResponse(string nome, Guid idNivelEnsino)
        {
            //Testa criar Serie
            CreateSerieCommand cmd = new CreateSerieCommand(nome, idNivelEnsino);
            var response = await CreateSerie(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Serie = ConvertJsonToSerie(response.Content.ReadAsStringAsync().Result);
            Guid? id = Serie.Id;

            //Testa busca por Id
            response = await GetSeriePorID(id.ToString());
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deleta Serie
            response = await DeleteSerie(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Fact]
        public async Task Serie_GetAll_ReturnsOkResponse()
        {
            //Testa busca
            var response = await GetAllSeries();
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("", "751D97BC-6B14-4187-9A3D-005450CDAA53")]
        public async Task Serie_Create_ReturnsNOkResponse(string nome, Guid idNivelEnsino)
        {
            //Testa criar Serie
            CreateSerieCommand cmd = new CreateSerieCommand(nome, idNivelEnsino);
            var response = await CreateSerie(cmd);
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Serie_GetByNome_ReturnsNOkResponse()
        {
            //Testa busca por Nome
            var response = await _testContext.Client.GetAsync("/Serie/Nome/" + "");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Serie_GetById_ReturnsNOkResponse()
        {
            //Testa busca por Id
            var response = await _testContext.Client.GetAsync("/Serie/ID/" + "123");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Serie_Delete_ReturnsNOkResponse()
        {
            //Testa deletar Serie
            var response = await _testContext.Client.DeleteAsync("/Serie/" + "");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }
    }
}
