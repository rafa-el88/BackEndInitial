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
    public class PeriodoLetivoConfiguracaoController : ControllerBase
    {
        public readonly IPeriodoLetivoConfiguracaoServices _periodoLetivoConfiguracaoService;
        public PeriodoLetivoConfiguracaoController(IPeriodoLetivoConfiguracaoServices periodoLetivoConfiguracaoService)
        {
            _periodoLetivoConfiguracaoService = periodoLetivoConfiguracaoService;
        }

        /// <summary>
        /// Método que retorna todas as configurações de periodo letivo cadastrados
        /// </summary>
        /// <returns>Lista de PeriodoLetivoConfiguracaoViewModel</returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(List<PeriodoLetivoConfiguracaoViewModel>), 200)]
        public async Task<IActionResult> GetAllPeriodoLetivoConfiguracoes()
        {
            return new OkObjectResult(await _periodoLetivoConfiguracaoService.GetAllPeriodoLetivoConfiguracoes());
        }

        /// <summary>
        /// Método que retorna a configuração de periodo letivo pelo id
        /// </summary>
        /// <param name="idPeriodoLetivoConfiguracao"></param>
        /// <returns></returns>
        [HttpGet("ID/{idPeriodoLetivoConfiguracao}")]
        [ProducesResponseType(typeof(PeriodoLetivoConfiguracaoViewModel), 200)]
        public async Task<IActionResult> GetPeriodoLetivoConfiguracaoByID(Guid idPeriodoLetivoConfiguracao)
        {
            if (!HelperGuid.IsGuid(idPeriodoLetivoConfiguracao.ToString()))
                return BadRequest("Guid Inválido");
            return new OkObjectResult(await Task.Run(() => _periodoLetivoConfiguracaoService.GetPeriodoLetivoConfiguracaoById(idPeriodoLetivoConfiguracao).Result));
        }


        /// <summary>
        /// Método que salva a configuração de periodo letivo 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("new")]
        [ProducesResponseType(typeof(PeriodoLetivoConfiguracaoViewModel), 200)]
        public async Task<IActionResult> NewPeriodoLetivoConfiguracao([FromBody] CreatePeriodoLetivoConfiguracaoCommand obj)
        {
            var result = await _periodoLetivoConfiguracaoService.NewPeriodoLetivoConfiguracao(obj);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que atualiza os dados da configuração de periodo letivo 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType(typeof(UpdatePeriodoLetivoConfiguracaoCommand), 200)]
        [ProducesResponseType(typeof(PeriodoLetivoConfiguracaoViewModel), 400)]
        public async Task<IActionResult> UpdatePeriodoLetivoConfiguracao([FromBody]UpdatePeriodoLetivoConfiguracaoCommand command)
        {
            var result = await _periodoLetivoConfiguracaoService.UpdatePeriodoLetivoConfiguracao(command);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que exclui configuração de periodo letivo
        /// </summary>
        /// <param name="idPeriodoLetivoConfiguracao"></param>
        /// <returns></returns>
        [HttpDelete("{idPeriodoLetivoConfiguracao}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(PeriodoLetivoConfiguracaoViewModel), 400)]
        public async Task<IActionResult> DeletarPeriodoLetivoConfiguracao(Guid idPeriodoLetivoConfiguracao)
        {
            var result = await _periodoLetivoConfiguracaoService.DeletarPeriodoLetivoConfiguracao(idPeriodoLetivoConfiguracao);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }
    }
}