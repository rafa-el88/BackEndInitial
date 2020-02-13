using FluentAssertions;
using Newtonsoft.Json;
using PositivoCore.Application.Commands;
using PositivoCore.Application.Commands.ConvidadosEventos;
using PositivoCore.Application.ViewModels;
using PositivoCore.Domain.Enums;
using PositivoCore.Test.Context;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace PositivoCore.Test.Scenarios
{
    public class ConvidadosEventoTest
    {
        private readonly TestContext _testContext;

        public ConvidadosEventoTest() => _testContext = new TestContext();

        private async Task<HttpResponseMessage> CreateConvidadosEventos(CreateConvidadosEventoCommand cmd)
        {
            string jsoncmd = JsonConvert.SerializeObject(cmd);
            var content = new StringContent(jsoncmd, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PostAsync("/ConvidadosEvento/new", content);
            return response;
        }
        private ConvidadosEventoViewModel ConvertJsonToConvidadosEventos(string result)
        {
            CommandResult command = JsonConvert.DeserializeObject<CommandResult>(result);
            ConvidadosEventoViewModel evm = JsonConvert.DeserializeObject<ConvidadosEventoViewModel>(command.Dados.ToString());
            return evm;
        }
        private async Task<HttpResponseMessage> DeleteConvidadosEventos(Guid? Id) => await _testContext.Client.DeleteAsync("/ConvidadosEvento/" + Id.ToString());
        private async Task<HttpResponseMessage> UpdateConvidadosEventos(UpdateConvidadosEventoCommand cmd)
        {
            string jsoncmd = JsonConvert.SerializeObject(cmd);
            var content = new StringContent(jsoncmd, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PutAsync("/ConvidadosEvento/", content);
            return response;
        }
        private async Task<HttpResponseMessage> GetConvidadosEventosPorNome(string nome) =>
            await _testContext.Client.GetAsync("/ConvidadosEvento/Nome/" + nome);
        private async Task<HttpResponseMessage> GetConvidadosEventosPorID(string id) =>
            await _testContext.Client.GetAsync("/ConvidadosEvento/ID/" + id);
        private async Task<HttpResponseMessage> GetAllConvidadosEventoss() => await _testContext.Client.GetAsync("/ConvidadosEvento/getAll");

        [Theory]
        [InlineData("ConvidadosEventosTeste", TipoPerfil.Aluno, "8663E599-31E5-4F3A-A3C7-937FC7780DAD")]
        public async Task ConvidadosEventos_CreateDelete_ReturnsOkResponse(string nome, TipoPerfil tipoPerfil, Guid idConvidado)
        {
            //Testa criar ConvidadosEventos
            CreateConvidadosEventoCommand cmd = new CreateConvidadosEventoCommand(nome, tipoPerfil, idConvidado);
            var response = await CreateConvidadosEventos(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var ConvidadosEventos = ConvertJsonToConvidadosEventos(response.Content.ReadAsStringAsync().Result);
            Guid? id = ConvidadosEventos.Id;

            //deletar ConvidadosEventos
            response = await DeleteConvidadosEventos(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("ConvidadosEventosTeste", TipoPerfil.Aluno, "8663E599-31E5-4F3A-A3C7-937FC7780DAD")]
        public async Task ConvidadosEventos_CreateUpdateDelete_ReturnsOkResponse(string nome, TipoPerfil tipoPerfil, Guid idConvidado)
        {
            //Testa criar ConvidadosEventos
            CreateConvidadosEventoCommand cmd = new CreateConvidadosEventoCommand(nome, tipoPerfil, idConvidado);
            var response = await CreateConvidadosEventos(cmd);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var ConvidadosEventos = ConvertJsonToConvidadosEventos(response.Content.ReadAsStringAsync().Result);
            Guid? id = ConvidadosEventos.Id;

            //Atualiza ConvidadosEventos
            UpdateConvidadosEventoCommand cmdUpdate = new UpdateConvidadosEventoCommand(Guid.Parse(id.ToString()), "positivo12345");
            response = await UpdateConvidadosEventos(cmdUpdate);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deletar ConvidadosEventos
            response = await DeleteConvidadosEventos(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("ConvidadosEventosTeste", TipoPerfil.Aluno, "8663E599-31E5-4F3A-A3C7-937FC7780DAD")]
        public async Task ConvidadosEventos_CreateGetByNomeDelete_ReturnsOkResponse(string nome, TipoPerfil tipoPerfil, Guid idConvidado)
        {
            //Testa criar ConvidadosEventos 
            CreateConvidadosEventoCommand cmd = new CreateConvidadosEventoCommand(nome, tipoPerfil, idConvidado);
            var response = await CreateConvidadosEventos(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var ConvidadosEventos = ConvertJsonToConvidadosEventos(response.Content.ReadAsStringAsync().Result);
            Guid? id = ConvidadosEventos.Id;

            //Testa busca por Nome
            response = await GetConvidadosEventosPorNome(nome);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deletar ConvidadosEventos
            response = await DeleteConvidadosEventos(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("ConvidadosEventosTeste", TipoPerfil.Aluno, "8663E599-31E5-4F3A-A3C7-937FC7780DAD")]
        public async Task ConvidadosEventos_CreateGetByIdDelete_ReturnsOkResponse(string nome, TipoPerfil tipoPerfil, Guid idConvidado)
        {
            //Testa criar ConvidadosEventos
            CreateConvidadosEventoCommand cmd = new CreateConvidadosEventoCommand(nome, tipoPerfil, idConvidado);
            var response = await CreateConvidadosEventos(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var ConvidadosEventos = ConvertJsonToConvidadosEventos(response.Content.ReadAsStringAsync().Result);
            Guid? id = ConvidadosEventos.Id;

            //Testa busca por Id
            response = await GetConvidadosEventosPorID(id.ToString());
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deleta ConvidadosEventos
            response = await DeleteConvidadosEventos(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ConvidadosEventos_GetAll_ReturnsOkResponse()
        {
            //Testa busca
            var response = await GetAllConvidadosEventoss();
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("", TipoPerfil.Aluno, "8663E599-31E5-4F3A-A3C7-937FC7780DAD")]
        public async Task ConvidadosEventos_Create_ReturnsNOkResponse(string nome, TipoPerfil tipoPerfil, Guid idConvidado)
        {
            //Testa criar ConvidadosEventos
            CreateConvidadosEventoCommand cmd = new CreateConvidadosEventoCommand(nome, tipoPerfil, idConvidado);
            var response = await CreateConvidadosEventos(cmd);
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ConvidadosEventos_GetByNome_ReturnsNOkResponse()
        {
            //Testa busca por Nome
            var response = await _testContext.Client.GetAsync("/ConvidadosEventos/Nome/" + "");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ConvidadosEventos_GetById_ReturnsNOkResponse()
        {
            //Testa busca por Id
            var response = await _testContext.Client.GetAsync("/ConvidadosEventos/ID/" + "123");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }
        [Fact]
        public async Task ConvidadosEventos_Delete_ReturnsNOkResponse()
        {
            //Testa deletar ConvidadosEventos
            var response = await _testContext.Client.DeleteAsync("/ConvidadosEventos/" + "");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }
    }
}