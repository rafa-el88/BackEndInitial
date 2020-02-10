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
    public class AlunoTest
    {
        private readonly TestContext _testContext;
        public AlunoTest()
        {
            _testContext = new TestContext();
        }

        private async Task<HttpResponseMessage> CreateAluno(CreateAlunoCommand cmd)
        {
            string jsoncmd = JsonConvert.SerializeObject(cmd);
            var content = new StringContent(jsoncmd, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PostAsync("/Aluno/new", content);
            return response;
        }
        private AlunoViewModel ConvertJsonToAluno(string result)
        {
            CommandResult command = JsonConvert.DeserializeObject<CommandResult>(result);
            AlunoViewModel evm = JsonConvert.DeserializeObject<AlunoViewModel>(command.Dados.ToString());
            return evm;
        }
        private async Task<HttpResponseMessage> DeleteAluno(Guid? Id)
        {
            return await _testContext.Client.DeleteAsync("/Aluno/" + Id.ToString());
        }
        private async Task<HttpResponseMessage> UpdateAluno(UpdateAlunoCommand cmd)
        {
            string jsoncmd = JsonConvert.SerializeObject(cmd);
            var content = new StringContent(jsoncmd, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PutAsync("/Aluno/", content);
            return response;
        }
        private async Task<HttpResponseMessage> GetAlunoPorNome(string nome)
        {
            var response = await _testContext.Client.GetAsync("/Aluno/Nome/" + nome);
            return response;
        }
        private async Task<HttpResponseMessage> GetAlunoPorID(string id)
        {
            var response = await _testContext.Client.GetAsync("/Aluno/ID/" + id);
            return response;
        }
        private async Task<HttpResponseMessage> GetAllAlunos()
        {
            var response = await _testContext.Client.GetAsync("/Aluno/getAll");
            return response;
        }

        [Theory]
        [InlineData("Aluno")]
        public async Task Aluno_CreateDelete_ReturnsOkResponse(string nome)
        {
            //Testa criar Aluno
            CreateAlunoCommand cmd = new CreateAlunoCommand(nome);
            var response = await CreateAluno(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Aluno = ConvertJsonToAluno(response.Content.ReadAsStringAsync().Result);
            Guid? id = Aluno.Id;

            //deletar Aluno
            response = await DeleteAluno(id);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("Aluno")]
        public async Task Aluno_CreateUpdateDelete_ReturnsOkResponse(string nome)
        {
            //Testa criar Aluno
            CreateAlunoCommand cmd = new CreateAlunoCommand(nome);
            var response = await CreateAluno(cmd);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Aluno = ConvertJsonToAluno(response.Content.ReadAsStringAsync().Result);
            Guid? id = Aluno.Id;

            //Atualiza Aluno
            UpdateAlunoCommand cmdUpdate = new UpdateAlunoCommand(Guid.Parse(id.ToString()), "positivo12345");
            response = await UpdateAluno(cmdUpdate);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deletar Aluno
            response = await DeleteAluno(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("Aluno")]
        public async Task Aluno_CreateGetByNomeDelete_ReturnsOkResponse(string nome)
        {
            //Testa criar Aluno 
            CreateAlunoCommand cmd = new CreateAlunoCommand(nome);
            var response = await CreateAluno(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Aluno = ConvertJsonToAluno(response.Content.ReadAsStringAsync().Result);
            Guid? id = Aluno.Id;

            //Testa busca por Nome
            response = await GetAlunoPorNome(nome);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deletar Aluno
            response = await DeleteAluno(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("Aluno")]
        public async Task Aluno_CreateGetByIdDelete_ReturnsOkResponse(string nome)
        {
            //Testa criar Aluno
            CreateAlunoCommand cmd = new CreateAlunoCommand(nome);
            var response = await CreateAluno(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Aluno = ConvertJsonToAluno(response.Content.ReadAsStringAsync().Result);
            Guid? id = Aluno.Id;

            //Testa busca por Id
            response = await GetAlunoPorID(id.ToString());
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deleta Aluno
            response = await DeleteAluno(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Fact]
        public async Task Aluno_GetAll_ReturnsOkResponse()
        {
            //Testa busca
            var response = await GetAllAlunos();
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("")]
        public async Task Aluno_Create_ReturnsNOkResponse(string nome)
        {
            //Testa criar Aluno
            CreateAlunoCommand cmd = new CreateAlunoCommand(nome);
            var response = await CreateAluno(cmd);
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Aluno_GetByNome_ReturnsNOkResponse()
        {
            //Testa busca por Nome
            var response = await _testContext.Client.GetAsync("/Aluno/Nome/" + "");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }


        [Fact]
        public async Task Aluno_GetById_ReturnsNOkResponse()
        {
            //Testa busca por Id
            var response = await _testContext.Client.GetAsync("/Aluno/ID/" + "123");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Aluno_Delete_ReturnsNOkResponse()
        {
            //Testa deletar Aluno
            var response = await _testContext.Client.DeleteAsync("/Aluno/" + "");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }
    }
}
