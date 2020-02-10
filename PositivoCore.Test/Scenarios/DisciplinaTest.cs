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
    public class DisciplinaTest
    {
        private readonly TestContext _testContext;
        public DisciplinaTest()
        {
            _testContext = new TestContext();
        }

        private async Task<HttpResponseMessage> CreateDisciplina(CreateDisciplinaCommand cmd)
        {
            string jsoncmd = JsonConvert.SerializeObject(cmd);
            var content = new StringContent(jsoncmd, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PostAsync("/Disciplina/new", content);
            return response;
        }
        private DisciplinaViewModel ConvertJsonToDisciplina(string result)
        {
            CommandResult command = JsonConvert.DeserializeObject<CommandResult>(result);
            DisciplinaViewModel evm = JsonConvert.DeserializeObject<DisciplinaViewModel>(command.Dados.ToString());
            return evm;
        }
        private async Task<HttpResponseMessage> DeleteDisciplina(Guid? Id)
        {
            return await _testContext.Client.DeleteAsync("/Disciplina/" + Id.ToString());
        }
        private async Task<HttpResponseMessage> UpdateDisciplina(UpdateDisiplinaCommand cmd)
        {
            string jsoncmd = JsonConvert.SerializeObject(cmd);
            var content = new StringContent(jsoncmd, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PutAsync("/Disciplina/", content);
            return response;
        }
        private async Task<HttpResponseMessage> GetDisciplinaPorNome(string nome)
        {
            var response = await _testContext.Client.GetAsync("/Disciplina/Nome/" + nome);
            return response;
        }
        private async Task<HttpResponseMessage> GetDisciplinaPorID(string id)
        {
            var response = await _testContext.Client.GetAsync("/Disciplina/ID/" + id);
            return response;
        }
        private async Task<HttpResponseMessage> GetAllDisciplinas()
        {
            var response = await _testContext.Client.GetAsync("/Disciplina/getAll");
            return response;
        }

        [Theory]
        [InlineData("Disciplina")]
        public async Task Disciplina_CreateDelete_ReturnsOkResponse(string nome)
        {
            //Testa criar Disciplina
            CreateDisciplinaCommand cmd = new CreateDisciplinaCommand(nome);
            var response = await CreateDisciplina(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Disciplina = ConvertJsonToDisciplina(response.Content.ReadAsStringAsync().Result);
            Guid? id = Disciplina.Id;

            //deletar Disciplina
            response = await DeleteDisciplina(id);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("Disciplina")]
        public async Task Disciplina_CreateUpdateDelete_ReturnsOkResponse(string nome)
        {
            //Testa criar Disciplina
            CreateDisciplinaCommand cmd = new CreateDisciplinaCommand(nome);
            var response = await CreateDisciplina(cmd);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Disciplina = ConvertJsonToDisciplina(response.Content.ReadAsStringAsync().Result);
            Guid? id = Disciplina.Id;

            //Atualiza Disciplina
            UpdateDisiplinaCommand cmdUpdate = new UpdateDisiplinaCommand(Guid.Parse(id.ToString()), "positivo12345");
            response = await UpdateDisciplina(cmdUpdate);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deletar Disciplina
            response = await DeleteDisciplina(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("Disciplina")]
        public async Task Disciplina_CreateGetByNomeDelete_ReturnsOkResponse(string nome)
        {
            //Testa criar Disciplina 
            CreateDisciplinaCommand cmd = new CreateDisciplinaCommand(nome);
            var response = await CreateDisciplina(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Disciplina = ConvertJsonToDisciplina(response.Content.ReadAsStringAsync().Result);
            Guid? id = Disciplina.Id;

            //Testa busca por Nome
            response = await GetDisciplinaPorNome(nome);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deletar Disciplina
            response = await DeleteDisciplina(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("Disciplina")]
        public async Task Disciplina_CreateGetByIdDelete_ReturnsOkResponse(string nome)
        {
            //Testa criar Disciplina
            CreateDisciplinaCommand cmd = new CreateDisciplinaCommand(nome);
            var response = await CreateDisciplina(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Disciplina = ConvertJsonToDisciplina(response.Content.ReadAsStringAsync().Result);
            Guid? id = Disciplina.Id;

            //Testa busca por Id
            response = await GetDisciplinaPorID(id.ToString());
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deleta Disciplina
            response = await DeleteDisciplina(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Fact]
        public async Task Disciplina_GetAll_ReturnsOkResponse()
        {
            //Testa busca
            var response = await GetAllDisciplinas();
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("")]
        public async Task Disciplina_Create_ReturnsNOkResponse(string nome)
        {
            //Testa criar Disciplina
            CreateDisciplinaCommand cmd = new CreateDisciplinaCommand(nome);
            var response = await CreateDisciplina(cmd);
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Disciplina_GetByNome_ReturnsNOkResponse()
        {
            //Testa busca por Nome
            var response = await _testContext.Client.GetAsync("/Disciplina/Nome/" + "");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Disciplina_GetById_ReturnsNOkResponse()
        {
            //Testa busca por Id
            var response = await _testContext.Client.GetAsync("/Disciplina/ID/" + "123");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Disciplina_Delete_ReturnsNOkResponse()
        {
            //Testa deletar Disciplina
            var response = await _testContext.Client.DeleteAsync("/Disciplina/" + "");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }
    }
}
