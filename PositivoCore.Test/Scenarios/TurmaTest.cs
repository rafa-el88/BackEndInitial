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
    public class TurmaTest
    {
        private readonly TestContext _testContext;
        public TurmaTest()
        {
            _testContext = new TestContext();
        }

        private async Task<HttpResponseMessage> CreateTurma(CreateTurmaCommand cmd)
        {
            string jsoncmd = JsonConvert.SerializeObject(cmd);
            var content = new StringContent(jsoncmd, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PostAsync("/Turma/new", content);
            return response;
        }
        private TurmaViewModel ConvertJsonToTurma(string result)
        {
            CommandResult command = JsonConvert.DeserializeObject<CommandResult>(result);
            TurmaViewModel evm = JsonConvert.DeserializeObject<TurmaViewModel>(command.Dados.ToString());
            return evm;
        }
        private async Task<HttpResponseMessage> DeleteTurma(Guid? Id)
        {
            return await _testContext.Client.DeleteAsync("/Turma/" + Id.ToString());
        }
        private async Task<HttpResponseMessage> UpdateTurma(UpdateTurmaCommand cmd)
        {
            string jsoncmd = JsonConvert.SerializeObject(cmd);
            var content = new StringContent(jsoncmd, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PutAsync("/Turma/", content);
            return response;
        }
        private async Task<HttpResponseMessage> GetTurmaPorNome(string nome)
        {
            var response = await _testContext.Client.GetAsync("/Turma/Nome/" + nome);
            return response;
        }
        private async Task<HttpResponseMessage> GetTurmaPorID(string id)
        {
            var response = await _testContext.Client.GetAsync("/Turma/ID/" + id);
            return response;
        }
        private async Task<HttpResponseMessage> GetAllTurmas()
        {
            var response = await _testContext.Client.GetAsync("/Turma/getAll");
            return response;
        }

        [Theory]
        [InlineData("Turma", "25614A74-18AC-491F-8539-0E320C2BADF3", "89934574-BCEA-4423-8A62-3BC93F00993A")]
        public async Task Turma_CreateDelete_ReturnsOkResponse(string nome, Guid idEscola, Guid idSerie)
        {
            //Testa criar Turma
            CreateTurmaCommand cmd = new CreateTurmaCommand(nome, idEscola, idSerie);
            var response = await CreateTurma(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Turma = ConvertJsonToTurma(response.Content.ReadAsStringAsync().Result);
            Guid? id = Turma.Id;

            //deletar Turma
            response = await DeleteTurma(id);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("Turma", "25614A74-18AC-491F-8539-0E320C2BADF3", "89934574-BCEA-4423-8A62-3BC93F00993A")]
        public async Task Turma_CreateUpdateDelete_ReturnsOkResponse(string nome, Guid idEscola, Guid idSerie)
        {
            //Testa criar Turma
            CreateTurmaCommand cmd = new CreateTurmaCommand(nome, idEscola, idSerie);
            var response = await CreateTurma(cmd);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Turma = ConvertJsonToTurma(response.Content.ReadAsStringAsync().Result);
            Guid? id = Turma.Id;

            //Atualiza Turma
            UpdateTurmaCommand cmdUpdate = new UpdateTurmaCommand(Guid.Parse(id.ToString()), "positivo12345");
            response = await UpdateTurma(cmdUpdate);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deletar Turma
            response = await DeleteTurma(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("Turma", "25614A74-18AC-491F-8539-0E320C2BADF3", "89934574-BCEA-4423-8A62-3BC93F00993A")]
        public async Task Turma_CreateGetByNomeDelete_ReturnsOkResponse(string nome, Guid idEscola, Guid idSerie)
        {
            //Testa criar Turma 
            CreateTurmaCommand cmd = new CreateTurmaCommand(nome, idEscola, idSerie);
            var response = await CreateTurma(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Turma = ConvertJsonToTurma(response.Content.ReadAsStringAsync().Result);
            Guid? id = Turma.Id;

            //Testa busca por Nome
            response = await GetTurmaPorNome(nome);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deletar Turma
            response = await DeleteTurma(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("Turma", "25614A74-18AC-491F-8539-0E320C2BADF3", "89934574-BCEA-4423-8A62-3BC93F00993A")]
        public async Task Turma_CreateGetByIdDelete_ReturnsOkResponse(string nome, Guid idEscola, Guid idSerie)
        {
            {
                //Testa criar Turma
                CreateTurmaCommand cmd = new CreateTurmaCommand(nome, idEscola, idSerie);
                var response = await CreateTurma(cmd);
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                var Turma = ConvertJsonToTurma(response.Content.ReadAsStringAsync().Result);
                Guid? id = Turma.Id;

                //Testa busca por Id
                response = await GetTurmaPorID(id.ToString());
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                //deleta Turma
                response = await DeleteTurma(id);
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }

        }

        [Fact]
        public async Task Turma_GetAll_ReturnsOkResponse()
        {
            //Testa busca
            var response = await GetAllTurmas();
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("", "25614A74-18AC-491F-8539-0E320C2BADF3", "89934574-BCEA-4423-8A62-3BC93F00993A")]
        public async Task Turma_Create_ReturnsNOkResponse(string nome, Guid idEscola, Guid idSerie)
        {
            //Testa criar Turma
            CreateTurmaCommand cmd = new CreateTurmaCommand(nome, idEscola, idSerie);
            var response = await CreateTurma(cmd);
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Turma_GetByNome_ReturnsNOkResponse()
        {
            //Testa busca por Nome
            var response = await _testContext.Client.GetAsync("/Turma/Nome/" + "");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }


        [Fact]
        public async Task Turma_GetById_ReturnsNOkResponse()
        {
            //Testa busca por Id
            var response = await _testContext.Client.GetAsync("/Turma/ID/" + "123");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Turma_Delete_ReturnsNOkResponse()
        {
            //Testa deletar Turma
            var response = await _testContext.Client.DeleteAsync("/Turma/" + "");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }
    }
}
