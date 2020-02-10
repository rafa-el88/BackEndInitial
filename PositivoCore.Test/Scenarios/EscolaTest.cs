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
    public class EscolaTest
    {
        private readonly TestContext _testContext;
        public EscolaTest()
        {
            _testContext = new TestContext();
        }
        
        private async Task<HttpResponseMessage> CreateEscola(CreateEscolaCommand cmd)
        {
            string jsoncmd = JsonConvert.SerializeObject(cmd);
            var content = new StringContent(jsoncmd, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PostAsync("/Escola/new", content);
            return response;
        }
        private EscolaViewModel ConvertJsonToEscola(string result)
        {
            CommandResult command = JsonConvert.DeserializeObject<CommandResult>(result);
            EscolaViewModel evm = JsonConvert.DeserializeObject<EscolaViewModel>(command.Dados.ToString());
            return evm;
        }
        private async Task<HttpResponseMessage> DeleteEscola(Guid? Id)
        {
            return await _testContext.Client.DeleteAsync("/Escola/" + Id.ToString() );
        }
        private async Task<HttpResponseMessage> UpdateEscola(UpdateEscolaCommand cmd)
        {
            
            string jsoncmd = JsonConvert.SerializeObject(cmd);
            var content = new StringContent(jsoncmd, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PutAsync("/Escola/", content);
            return response;
        }
        private async Task<HttpResponseMessage> GetEscolaPorNome(string nome)
        {            
            var response =  await _testContext.Client.GetAsync("/Escola/Nome/" + nome);
            return response;
        }
        private async Task<HttpResponseMessage> GetEscolaPorCNPJ(string cnpj)
        {
            var response = await _testContext.Client.GetAsync("/Escola/CNPJ/" + cnpj);
            return response;
        }
        private async Task<HttpResponseMessage> GetEscolaPorID(string id)
        {
            var response = await _testContext.Client.GetAsync("/Escola/ID/" + id);
            return response;
        }
        private async Task<HttpResponseMessage> GetAllEscolas()
        {
            var response = await _testContext.Client.GetAsync("/Escola/getAll");
            return response;
        }
        
        [Theory]
        [InlineData("Escola", "73279182000155")]
        public async Task Escola_CreateDelete_ReturnsOkResponse(string nome,string cnpj)
        {
            //Testa criar escola
            CreateEscolaCommand cmd = new CreateEscolaCommand(nome, cnpj);
            var response = await CreateEscola(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var escola = ConvertJsonToEscola(response.Content.ReadAsStringAsync().Result);
            Guid? id = escola.Id;

            //deletar escola
            response = await DeleteEscola(id);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);            
        }

        [Theory]
        [InlineData("Escola", "10873476000190")]
        public async Task Escola_CreateUpdateDelete_ReturnsOkResponse(string nome, string cnpj)
        {
            //Testa criar escola
            CreateEscolaCommand cmd = new CreateEscolaCommand(nome, cnpj);
            var response = await CreateEscola(cmd);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var escola = ConvertJsonToEscola(response.Content.ReadAsStringAsync().Result);
            Guid? id = escola.Id;
            
            //Atualiza escola
            UpdateEscolaCommand cmdUpdate = new UpdateEscolaCommand(Guid.Parse(id.ToString()), "positivo12345");
            response = await UpdateEscola(cmdUpdate);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deletar escola
            response = await DeleteEscola(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("Escola", "10873476000190")]
        public async Task Escola_CreateGetByNomeDelete_ReturnsOkResponse(string nome, string cnpj)
        {
            //Testa criar escola 
            CreateEscolaCommand cmd = new CreateEscolaCommand(nome, cnpj);
            var response = await CreateEscola(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var escola = ConvertJsonToEscola(response.Content.ReadAsStringAsync().Result);
            Guid? id = escola.Id;
            

            //Testa busca por Nome
            response = await GetEscolaPorNome(nome);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deletar escola
            response = await DeleteEscola(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("Escola", "10873476000190")]
        public async Task Escola_CreateGetByCNPJDelete_ReturnsOkResponse(string nome, string cnpj)
        {
            //Testa criar escola
            CreateEscolaCommand cmd = new CreateEscolaCommand(nome, cnpj);
            var response = await CreateEscola(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var escola = ConvertJsonToEscola(response.Content.ReadAsStringAsync().Result);
            Guid? id = escola.Id;

            //Testa busca por CNPJ
            response = await GetEscolaPorCNPJ(cnpj);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deleta escola
            response = await DeleteEscola(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("Escola", "10873476000190")]
        public async Task Escola_CreateGetByIdDelete_ReturnsOkResponse(string nome, string cnpj)
        {
            //Testa criar escola
            CreateEscolaCommand cmd = new CreateEscolaCommand(nome, cnpj);
            var response = await CreateEscola(cmd);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);


            var escola = ConvertJsonToEscola(response.Content.ReadAsStringAsync().Result);
            Guid? id = escola.Id;

            //Testa busca por Id
            response = await GetEscolaPorID(id.ToString());
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //deleta escola
            response = await DeleteEscola(id);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Fact]
        public async Task Escola_GetAll_ReturnsOkResponse()
        {
            //Testa busca
            var response = await GetAllEscolas();
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }



        [Theory]
        [InlineData("Escola", "123")]
        [InlineData("Escola", "12345678911234")]
        [InlineData("Escola", "1234567891123456")]
        public async Task Escola_Create_ReturnsNOkResponse(string nome,string cnpj)
        {
            //Testa criar escola
            CreateEscolaCommand cmd = new CreateEscolaCommand(nome, cnpj);
            var response = await CreateEscola(cmd);
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }

        

        [Fact]
        public async Task Escola_GetByNome_ReturnsNOkResponse()
        {
            //Testa busca por Nome
            var response = await _testContext.Client.GetAsync("/Escola/Nome/" + "");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Escola_GetByCNPJ_ReturnsNOkResponse()
        {
            //Testa busca por CNPJ
            var response = await _testContext.Client.GetAsync("/Escola/CNPJ/" + "123");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Escola_GetById_ReturnsNOkResponse()
        {
            //Testa busca por Id
            var response = await _testContext.Client.GetAsync("/Escola/ID/" + "123");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Escola_Delete_ReturnsNOkResponse()
        {
            //Testa deletar escola
            var response = await _testContext.Client.DeleteAsync("/Escola/" + "");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }
    }
}
