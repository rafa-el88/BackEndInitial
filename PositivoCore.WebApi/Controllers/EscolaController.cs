using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PositivoCore.Application.Commands;
using PositivoCore.Application.Interface.Services;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Helper;

namespace PositivoCore.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EscolaController : ControllerBase
    {
        public readonly IEscolaServices _escolaService;
        public EscolaController(IEscolaServices escolaService)
        {
            _escolaService = escolaService;
        }

        /// <summary>
        /// Método que retorna todas as escolas cadastradas
        /// </summary>
        /// <returns>Lista de EscolaViewModel</returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(List<EscolaViewModel>), 200)]
        public async Task<IActionResult> GetAllEscolas()
        {
            return new OkObjectResult(await _escolaService.GetAllEscolas());
        }

        /// <summary>
        /// Método que retorna a escola pelo id
        /// </summary>
        /// <param name="idEscola"></param>
        /// <returns></returns>
        [HttpGet("id/{idEscola}")]
        [ProducesResponseType(typeof(EscolaViewModel), 200)]
        public async Task<IActionResult> GetEscolaByID(Guid idEscola)
        {
            if (!HelperGuid.IsGuid(idEscola.ToString()))
                return BadRequest("Guid Inválido");
            return new OkObjectResult(await Task.Run(() => _escolaService.GetEscolaById(idEscola).Result));
        }

        /// <summary>
        /// Método que retorna a escola pelo cnpj
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        [HttpGet("cnpj/{cnpj}")]
        [ProducesResponseType(typeof(EscolaViewModel), 200)]
        public async Task<IActionResult> GetEscolaByCNPJ(string cnpj)
        {
            var result = await _escolaService.GetEscolaByCNPJ(cnpj);

            if (result == null)
                return BadRequest("CNPJ Inválido");

            return new OkObjectResult(result);
        }

        /// <summary>
        /// Método que retorna a escola pelo nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("nome/{nome}")]
        [ProducesResponseType(typeof(EscolaViewModel), 200)]
        public async Task<IActionResult> GetEscolaByNome(string nome)
        {
            return new OkObjectResult(await _escolaService.GetEscolaByNome(nome));
        }

        /// <summary>
        /// Método que salva escola 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("new")]
        [ProducesResponseType(typeof(EscolaViewModel), 200)]
        [ProducesResponseType(typeof(EscolaViewModel), 400)]
        public async Task<IActionResult> CreateEscola([FromBody] CreateEscolaCommand command)
        {
            var result = await _escolaService.CreateEscola(command);
            return result.Sucesso  ?  new ObjectResult(result): BadRequest(result) ;
        }

        /// <summary>
        /// Método que salva escola vinda de uma lista de objetos
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost("newEscolas")]
        [ProducesResponseType(typeof(CreateEscolasCommand), 200)]
        [ProducesResponseType(typeof(EscolaViewModel), 400)]
        public async Task<IActionResult> CreateEscolasFromList([FromBody]List<EscolaViewModel> list)
        {
            var result = await _escolaService.CreateEscolasFromList(list);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que atualiza o nome da escola 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType(typeof(UpdateEscolaCommand), 200)]
        [ProducesResponseType(typeof(EscolaViewModel), 400)]
        public async Task<IActionResult> UpdateEscola([FromBody]UpdateEscolaCommand command)
        {
            var result = await _escolaService.UpdateEscola(command);
            return result.Sucesso  ?  new ObjectResult(result) : BadRequest(result) ;
        }

        /// <summary>
        /// Método que exclui a escola
        /// </summary>
        /// <param name="idEscola"></param>
        /// <returns></returns>
        [HttpDelete("{idEscola}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(EscolaViewModel), 400)]
        public async Task<IActionResult> DeleteEscola(Guid idEscola)
        {
            var result = await _escolaService.DeleteEscola(idEscola);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }
    }
}