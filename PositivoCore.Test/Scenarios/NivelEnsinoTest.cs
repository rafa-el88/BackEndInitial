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
    public class NivelEnsinoTest
    {
        private readonly TestContext _testContext;
        public NivelEnsinoTest()
        {
            _testContext = new TestContext();
        }

        private async Task<HttpResponseMessage> CreateNivelEnsino(CreateNivelEnsinoCommand cmd)
        {
            string jsoncmd = JsonConvert.SerializeObject(cmd);
            var content = new StringContent(jsoncmd, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PostAsync("/NivelEnsino/new", content);
            return response;
        }
        private NivelEnsinoViewModel ConvertJsonToNivelEnsino(string result)
        {
            CommandResult command = JsonConvert.DeserializeObject<CommandResult>(result);
            NivelEnsinoViewModel evm = JsonConvert.DeserializeObject<NivelEnsinoViewModel>(command.Dados.ToString());
            return evm;
        }
        private async Task<HttpResponseMessage> DeleteNivelEnsino(Guid? Id)
        {
            return await _testContext.Client.DeleteAsync("/NivelEnsino/" + Id.ToString());
        }
        private async Task<HttpResponseMessage> UpdateNivelEnsino(UpdateDisiplinaCommand cmd)
        {
            string jsoncmd = JsonConvert.SerializeObject(cmd);
            var content = new StringContent(jsoncmd, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PutAsync("/NivelEnsino/", content);
            return response;
        }
        private async Task<HttpResponseMessage> GetNivelEnsinoPorNome(string nome)
        {
            var response = await _testContext.Client.GetAsync("/NivelEnsino/Nome/" + nome);
            return response;
        }
        private async Task<HttpResponseMessage> GetNivelEnsinoPorID(string id)
        {
            var response = await _testContext.Client.GetAsync("/NivelEnsino/ID/" + id);
            return response;
        }
        private async Task<HttpResponseMessage> GetAllNivelEnsinos()
        {
            var response = await _testContext.Client.GetAsync("/NivelEnsino/getAll");
            return response;
        }

        [Theory]
        [InlineData("NivelEnsino")]
        public async Task NivelEnsino_CreateDelete_ReturnsOkResponse(string nome)
        {
            //Testa criar NivelEnsino
            CreateNivelEnsinoCommand cmd = new CreateNivelEnsinoCommand(nome);
            var response = await CreateNivelEnsino(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var NivelEnsino = ConvertJsonToNivelEnsino(response.Content.ReadAsStringAsync().Result);
            Guid? id = NivelEnsino.Id;

            //deletar NivelEnsino
            response = await DeleteNivelEnsino(id);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("NivelEnsino")]
        public async Task NivelEnsino_CreateUpdateDelete_ReturnsOkResponse(string nome)
        {
            //Testa criar NivelEnsino
            CreateNivelEnsinoCommand cmd = new CreateNivelEnsinoCommand(nome);
            var response = await CreateNivelEnsino(cmd);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var NivelEnsino = ConvertJsonToNivelEnsino(response.Content.ReadAsStringAsync().Result);
            Guid? id = NivelEnsino.Id;

            //Atualiza NivelEnsino
            UpdateDisiplinaCommand cmdUpdate = new UpdateDisiplinaCommand(Guid.Parse(id.ToString()), "positivo12345");
            response = await UpdateNivelEnsino(cmdUpdate);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deletar NivelEnsino
            response = await DeleteNivelEnsino(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("NivelEnsino")]
        public async Task NivelEnsino_CreateGetByNomeDelete_ReturnsOkResponse(string nome)
        {
            //Testa criar NivelEnsino 
            CreateNivelEnsinoCommand cmd = new CreateNivelEnsinoCommand(nome);
            var response = await CreateNivelEnsino(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var NivelEnsino = ConvertJsonToNivelEnsino(response.Content.ReadAsStringAsync().Result);
            Guid? id = NivelEnsino.Id;

            //Testa busca por Nome
            response = await GetNivelEnsinoPorNome(nome);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deletar NivelEnsino
            response = await DeleteNivelEnsino(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("NivelEnsino")]
        public async Task NivelEnsino_CreateGetByIdDelete_ReturnsOkResponse(string nome)
        {
            //Testa criar NivelEnsino
            CreateNivelEnsinoCommand cmd = new CreateNivelEnsinoCommand(nome);
            var response = await CreateNivelEnsino(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var NivelEnsino = ConvertJsonToNivelEnsino(response.Content.ReadAsStringAsync().Result);
            Guid? id = NivelEnsino.Id;

            //Testa busca por Id
            response = await GetNivelEnsinoPorID(id.ToString());
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deleta NivelEnsino
            response = await DeleteNivelEnsino(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Fact]
        public async Task NivelEnsino_GetAll_ReturnsOkResponse()
        {
            //Testa busca
            var response = await GetAllNivelEnsinos();
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("")]
        public async Task NivelEnsino_Create_ReturnsNOkResponse(string nome)
        {
            //Testa criar NivelEnsino
            CreateNivelEnsinoCommand cmd = new CreateNivelEnsinoCommand(nome);
            var response = await CreateNivelEnsino(cmd);
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task NivelEnsino_GetByNome_ReturnsNOkResponse()
        {
            //Testa busca por Nome
            var response = await _testContext.Client.GetAsync("/NivelEnsino/Nome/" + "");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task NivelEnsino_GetById_ReturnsNOkResponse()
        {
            //Testa busca por Id
            var response = await _testContext.Client.GetAsync("/NivelEnsino/ID/" + "123");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task NivelEnsino_Delete_ReturnsNOkResponse()
        {
            //Testa deletar NivelEnsino
            var response = await _testContext.Client.DeleteAsync("/NivelEnsino/" + "");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }
    }
}
