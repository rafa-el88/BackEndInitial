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
    public class PeriodoController : ControllerBase
    {
        public readonly IPeriodoServices _periodoService;
        public PeriodoController(IPeriodoServices periodoService)
        {
            _periodoService = periodoService;
        }

        /// <summary>
        /// Método que retorna todos os periodos cadastrados
        /// </summary>
        /// <returns>Lista de PeriodoViewModel</returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(List<PeriodoViewModel>), 200)]
        public async Task<IActionResult> GetAllPeriodos()
        {
            return new OkObjectResult(await _periodoService.GetAllPeriodos());
        }

        /// <summary>
        /// Método que retorna o periodo letivo pelo id
        /// </summary>
        /// <param name="idPeriodo"></param>
        /// <returns></returns>
        [HttpGet("ID/{idPeriodo}")]
        [ProducesResponseType(typeof(PeriodoViewModel), 200)]
        public async Task<IActionResult> GetPeriodoByID(Guid idPeriodo)
        {
            if (!HelperGuid.IsGuid(idPeriodo.ToString()))
                return BadRequest("Guid Inválido");
            return new OkObjectResult(await Task.Run(() => _periodoService.GetPeriodoById(idPeriodo).Result));
        }

        /// <summary>
        /// Método que retorna o periodo letivo pelo nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("nome/{nome}")]
        [ProducesResponseType(typeof(PeriodoViewModel), 200)]
        public async Task<IActionResult> GetPeriodoByNome(string nome)
        {
            return new OkObjectResult(await _periodoService.GetPeriodoByNome(nome));
        }

        /// <summary>
        /// Método que salva o periodo letivo 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("new")]
        [ProducesResponseType(typeof(PeriodoViewModel), 200)]
        public async Task<IActionResult> NewPeriodo([FromBody] CreatePeriodoCommand obj)
        {
            var result = await _periodoService.NewPeriodo(obj);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que atualiza os dados do periodo letivo 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType(typeof(UpdatePeriodoCommand), 200)]
        [ProducesResponseType(typeof(PeriodoViewModel), 400)]
        public async Task<IActionResult> UpdatePeriodo([FromBody]UpdatePeriodoCommand command)
        {
            var result = await _periodoService.UpdatePeriodo(command);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que exclui periodo letivo
        /// </summary>
        /// <param name="idPeriodo"></param>
        /// <returns></returns>
        [HttpDelete("{idPeriodo}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(PeriodoViewModel), 400)]
        public async Task<IActionResult> DeletarPeriodo(Guid idPeriodo)
        {
            var result = await _periodoService.DeletarPeriodo(idPeriodo);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que retorna os periodos pelo tipo
        /// </summary>
        /// <param name="idPeriodoLetivoTipo"></param>
        /// <returns></returns>
        [HttpGet("tipo/{idPeriodoLetivoTipo}")]
        [ProducesResponseType(typeof(PeriodoViewModel), 200)]
        public async Task<IActionResult> GetPeriodoByTipo(Guid idPeriodoLetivoTipo)
        {
            return new OkObjectResult(await _periodoService.GetPeriodoByTipo(idPeriodoLetivoTipo));
        }
    }
}