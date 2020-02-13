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
    public class PeriodoLetivoTipoController : ControllerBase
    {
        public readonly IPeriodoLetivoTipoServices _periodoLetivoTipoService;
        public PeriodoLetivoTipoController(IPeriodoLetivoTipoServices periodoLetivoTipoService)
        {
            _periodoLetivoTipoService = periodoLetivoTipoService;
        }

        /// <summary>
        /// Método que retorna todos os tipos de periodo letivo cadastrados
        /// </summary>
        /// <returns>Lista de PeriodoLetivoTipoViewModel</returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(List<PeriodoLetivoTipoViewModel>), 200)]
        public async Task<IActionResult> GetAllPeriodoLetivoTipos()
        {
            return new OkObjectResult(await _periodoLetivoTipoService.GetAllPeriodoLetivoTipos());
        }

        /// <summary>
        /// Método que retorna o tipo de periodo letivo pelo id
        /// </summary>
        /// <param name="idPeriodoLetivoTipo"></param>
        /// <returns></returns>
        [HttpGet("ID/{idPeriodoLetivoTipo}")]
        [ProducesResponseType(typeof(PeriodoLetivoTipoViewModel), 200)]
        public async Task<IActionResult> GetPeriodoLetivoTipoByID(Guid idPeriodoLetivoTipo)
        {
            if (!HelperGuid.IsGuid(idPeriodoLetivoTipo.ToString()))
                return BadRequest("Guid Inválido");
            return new OkObjectResult(await Task.Run(() => _periodoLetivoTipoService.GetPeriodoLetivoTipoById(idPeriodoLetivoTipo).Result));
        }

        /// <summary>
        /// Método que retorna o tipo de periodo letivo pelo nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("nome/{nome}")]
        [ProducesResponseType(typeof(PeriodoLetivoTipoViewModel), 200)]
        public async Task<IActionResult> GetPeriodoLetivoTipoByNome(string nome)
        {
            return new OkObjectResult(await _periodoLetivoTipoService.GetPeriodoLetivoTipoByNome(nome));
        }

        /// <summary>
        /// Método que salva o tipo de periodo letivo 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("new")]
        [ProducesResponseType(typeof(PeriodoLetivoTipoViewModel), 200)]
        public async Task<IActionResult> NewPeriodoLetivoTipo([FromBody] CreatePeriodoLetivoTipoCommand obj)
        {
            var result = await _periodoLetivoTipoService.NewPeriodoLetivoTipo(obj);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que atualiza os dados do tipo de periodo letivo 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType(typeof(UpdatePeriodoLetivoTipoCommand), 200)]
        [ProducesResponseType(typeof(PeriodoLetivoTipoViewModel), 400)]
        public async Task<IActionResult> UpdatePeriodoLetivoTipo([FromBody]UpdatePeriodoLetivoTipoCommand command)
        {
            var result = await _periodoLetivoTipoService.UpdatePeriodoLetivoTipo(command);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que exclui tipo de periodo letivo
        /// </summary>
        /// <param name="idPeriodoLetivoTipo"></param>
        /// <returns></returns>
        [HttpDelete("{idPeriodoLetivoTipo}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(PeriodoLetivoTipoViewModel), 400)]
        public async Task<IActionResult> DeletarPeriodoLetivoTipo(Guid idPeriodoLetivoTipo)
        {
            var result = await _periodoLetivoTipoService.DeletarPeriodoLetivoTipo(idPeriodoLetivoTipo);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }
    }
}