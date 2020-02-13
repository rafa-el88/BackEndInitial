using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using PositivoCore.Application.Commands;
using PositivoCore.Application.Commands.Responsavel;
using PositivoCore.Application.ViewModels;
using PositivoCore.Test.Context;
using Xunit;

namespace PositivoCore.Test.Scenarios
{
    public class ResponsavelTest
    {
        private readonly TestContext _testContext;
        public ResponsavelTest()
        {
            _testContext = new TestContext();
        }

        private async Task<HttpResponseMessage> CreateResponsavel(CreateResponsavelCommand cmd)
        {
            string jsoncmd = JsonConvert.SerializeObject(cmd);
            var content = new StringContent(jsoncmd, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PostAsync("/Responsavel/new", content);
            return response;
        }
        private ResponsavelViewModel ConvertJsonToResponsavel(string result)
        {
            CommandResult command = JsonConvert.DeserializeObject<CommandResult>(result);
            ResponsavelViewModel evm = JsonConvert.DeserializeObject<ResponsavelViewModel>(command.Dados.ToString());
            return evm;
        }
        private async Task<HttpResponseMessage> UpdateResponsavel(UpdateResponsavelCommand cmd)
        {
            string jsoncmd = JsonConvert.SerializeObject(cmd);
            var content = new StringContent(jsoncmd, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PutAsync("/Responsavel/", content);
            return response;
        }
        private async Task<HttpResponseMessage> DeleteResponsavel(Guid? Id) => await _testContext.Client.DeleteAsync("/Responsavel/" + Id.ToString());
        private async Task<HttpResponseMessage> GetResponsavelPorNome(string nome) => await _testContext.Client.GetAsync("/Responsavel/Nome/" + nome);
        private async Task<HttpResponseMessage> GetResponsavelPorID(string id) => await _testContext.Client.GetAsync("/Responsavel/ID/" + id);
        private async Task<HttpResponseMessage> GetAllResponsavels() => await _testContext.Client.GetAsync("/Responsavel/getAll");

        [Theory]
        [InlineData("ResponsavelTeste", "responsavel@a.com", "2000-02-11T12:59:39.223Z", "123456789123")]
        public async Task Responsavel_CreateDelete_ReturnsOkResponse(string nome, string email, DateTime dataNascimento, string cpf)
        {
            //Testa criar Responsavel
            CreateResponsavelCommand cmd = new CreateResponsavelCommand(nome, email, dataNascimento, cpf);
            var response = await CreateResponsavel(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Responsavel = ConvertJsonToResponsavel(response.Content.ReadAsStringAsync().Result);
            Guid? id = Responsavel.Id;

            //deletar Responsavel
            response = await DeleteResponsavel(id);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("teste01", "responsavel@a.com", "2000-02-11T12:59:39.223Z", "123456789123")]
        public async Task Responsavel_CreateUpdateDelete_ReturnsOkResponse(string nome, string email, DateTime dataNascimento, string cpf)
        {
            //Testa criar Responsavel
            CreateResponsavelCommand cmd = new CreateResponsavelCommand(nome, email, dataNascimento, cpf);
            var response = await CreateResponsavel(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Responsavel = ConvertJsonToResponsavel(response.Content.ReadAsStringAsync().Result);
            Guid? id = Responsavel.Id;

            //Atualiza Responsavel
            UpdateResponsavelCommand cmdUpdate = new UpdateResponsavelCommand(Guid.Parse(id.ToString()), "positivo12345");
            response = await UpdateResponsavel(cmdUpdate);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deletar Responsavel
            response = await DeleteResponsavel(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("ResponsavelTeste", "responsavel@a.com", "2000-02-11T12:59:39.223Z", "123456789123")]
        public async Task Responsavel_CreateGetByNomeDelete_ReturnsOkResponse(string nome, string email, DateTime dataNascimento, string cpf)
        {
            //Testa criar Responsavel 
            CreateResponsavelCommand cmd = new CreateResponsavelCommand(nome, email, dataNascimento, cpf);
            var response = await CreateResponsavel(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Responsavel = ConvertJsonToResponsavel(response.Content.ReadAsStringAsync().Result);
            Guid? id = Responsavel.Id;

            //Testa busca por Nome
            response = await GetResponsavelPorNome(nome);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deletar Responsavel
            response = await DeleteResponsavel(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("ResponsavelTeste", "responsavel@a.com", "2000-02-11T12:59:39.223Z", "123456789123")]
        public async Task Responsavel_CreateGetByIdDelete_ReturnsOkResponse(string nome, string email, DateTime dataNascimento, string cpf)
        {
            //Testa criar Responsavel
            CreateResponsavelCommand cmd = new CreateResponsavelCommand(nome, email, dataNascimento, cpf);
            var response = await CreateResponsavel(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Responsavel = ConvertJsonToResponsavel(response.Content.ReadAsStringAsync().Result);
            Guid? id = Responsavel.Id;

            //Testa busca por Id
            response = await GetResponsavelPorID(id.ToString());
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deleta Responsavel
            response = await DeleteResponsavel(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Fact]
        public async Task Responsavel_GetAll_ReturnsOkResponse()
        {
            //Testa busca
            var response = await GetAllResponsavels();
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("", "responsavel@a.com", "2000-02-11T12:59:39.223Z", "123456789123")]
        public async Task Responsavel_Create_ReturnsNOkResponse(string nome, string email, DateTime dataNascimento, string cpf)
        {
            //Testa criar Responsavel
            CreateResponsavelCommand cmd = new CreateResponsavelCommand(nome, email, dataNascimento, cpf);
            var response = await CreateResponsavel(cmd);
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Responsavel_GetByNome_ReturnsNOkResponse()
        {
            //Testa busca por Nome
            var response = await _testContext.Client.GetAsync("/Responsavel/Nome/" + "");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Responsavel_GetById_ReturnsNOkResponse()
        {
            //Testa busca por Id
            var response = await _testContext.Client.GetAsync("/Responsavel/ID/" + "123");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Responsavel_Delete_ReturnsNOkResponse()
        {
            //Testa deletar Responsavel
            var response = await _testContext.Client.DeleteAsync("/Responsavel/" + "");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }
    }
}