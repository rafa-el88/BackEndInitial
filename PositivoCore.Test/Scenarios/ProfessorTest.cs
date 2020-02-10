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
    public class ProfessorTest
    {
        private readonly TestContext _testContext;
        public ProfessorTest()
        {
            _testContext = new TestContext();
        }

        private async Task<HttpResponseMessage> CreateProfessor(CreateProfessorCommand cmd)
        {
            string jsoncmd = JsonConvert.SerializeObject(cmd);
            var content = new StringContent(jsoncmd, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PostAsync("/Professor/new", content);
            return response;
        }
        private ProfessorViewModel ConvertJsonToProfessor(string result)
        {
            CommandResult command = JsonConvert.DeserializeObject<CommandResult>(result);
            ProfessorViewModel evm = JsonConvert.DeserializeObject<ProfessorViewModel>(command.Dados.ToString());
            return evm;
        }
        private async Task<HttpResponseMessage> DeleteProfessor(Guid? Id)
        {
            return await _testContext.Client.DeleteAsync("/Professor/" + Id.ToString());
        }
        private async Task<HttpResponseMessage> UpdateProfessor(UpdateProfessorCommand cmd)
        {
            string jsoncmd = JsonConvert.SerializeObject(cmd);
            var content = new StringContent(jsoncmd, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PutAsync("/Professor/", content);
            return response;
        }
        private async Task<HttpResponseMessage> GetProfessorPorNome(string nome)
        {
            var response = await _testContext.Client.GetAsync("/Professor/Nome/" + nome);
            return response;
        }
        private async Task<HttpResponseMessage> GetProfessorPorID(string id)
        {
            var response = await _testContext.Client.GetAsync("/Professor/ID/" + id);
            return response;
        }
        private async Task<HttpResponseMessage> GetAllProfessors()
        {
            var response = await _testContext.Client.GetAsync("/Professor/getAll");
            return response;
        }

        [Theory]
        [InlineData("Professor", "58631149080")]
        public async Task Professor_CreateDelete_ReturnsOkResponse(string nome, string cpf)
        {
            //Testa criar Professor
            CreateProfessorCommand cmd = new CreateProfessorCommand(nome, cpf);
            var response = await CreateProfessor(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Professor = ConvertJsonToProfessor(response.Content.ReadAsStringAsync().Result);
            Guid? id = Professor.Id;

            //deletar Professor
            response = await DeleteProfessor(id);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("Professor", "58631149080")]
        public async Task Professor_CreateUpdateDelete_ReturnsOkResponse(string nome, string cpf)
        {
            //Testa criar Professor
            CreateProfessorCommand cmd = new CreateProfessorCommand(nome, cpf);
            var response = await CreateProfessor(cmd);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Professor = ConvertJsonToProfessor(response.Content.ReadAsStringAsync().Result);
            Guid? id = Professor.Id;

            //Atualiza Professor
            UpdateProfessorCommand cmdUpdate = new UpdateProfessorCommand(Guid.Parse(id.ToString()), "positivo12345");
            response = await UpdateProfessor(cmdUpdate);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deletar Professor
            response = await DeleteProfessor(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("Professor", "58631149080")]
        public async Task Professor_CreateGetByNomeDelete_ReturnsOkResponse(string nome, string cpf)
        {
            //Testa criar Professor 
            CreateProfessorCommand cmd = new CreateProfessorCommand(nome, cpf);
            var response = await CreateProfessor(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Professor = ConvertJsonToProfessor(response.Content.ReadAsStringAsync().Result);
            Guid? id = Professor.Id;

            //Testa busca por Nome
            response = await GetProfessorPorNome(nome);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deletar Professor
            response = await DeleteProfessor(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("Professor", "58631149080")]
        public async Task Professor_CreateGetByIdDelete_ReturnsOkResponse(string nome, string cpf)
        {
            //Testa criar Professor
            CreateProfessorCommand cmd = new CreateProfessorCommand(nome, cpf);
            var response = await CreateProfessor(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Professor = ConvertJsonToProfessor(response.Content.ReadAsStringAsync().Result);
            Guid? id = Professor.Id;

            //Testa busca por Id
            response = await GetProfessorPorID(id.ToString());
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deleta Professor
            response = await DeleteProfessor(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Fact]
        public async Task Professor_GetAll_ReturnsOkResponse()
        {
            //Testa busca
            var response = await GetAllProfessors();
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("", "58631149080")]
        [InlineData("Professor", "")]
        public async Task Professor_Create_ReturnsNOkResponse(string nome, string cpf)
        {
            //Testa criar Professor
            CreateProfessorCommand cmd = new CreateProfessorCommand(nome, cpf);
            var response = await CreateProfessor(cmd);
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Professor_GetByNome_ReturnsNOkResponse()
        {
            //Testa busca por Nome
            var response = await _testContext.Client.GetAsync("/Professor/Nome/" + "");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }


        [Fact]
        public async Task Professor_GetById_ReturnsNOkResponse()
        {
            //Testa busca por Id
            var response = await _testContext.Client.GetAsync("/Professor/ID/" + "123");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Professor_Delete_ReturnsNOkResponse()
        {
            //Testa deletar Professor
            var response = await _testContext.Client.DeleteAsync("/Professor/" + "");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }
    }
}
