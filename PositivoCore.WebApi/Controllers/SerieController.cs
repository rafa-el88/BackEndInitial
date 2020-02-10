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
    public class SerieController : ControllerBase
    {
        public readonly ISerieServices _serieService;
        public SerieController(ISerieServices serieService)
        {
            _serieService = serieService;
        }

        /// <summary>
        /// Método que retorna todas as series
        /// </summary>
        /// <returns>Lista de SerieViewModel</returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(List<SerieViewModel>), 200)]
        public async Task<IActionResult> GetAllSeries()
        {
            return new OkObjectResult(await _serieService.GetAllSeries());
        }

        /// <summary>
        /// Método que retorna a serie pelo id
        /// </summary>
        /// <param name="idSerie"></param>
        /// <returns></returns>
        [HttpGet("ID/{idSerie}")]
        [ProducesResponseType(typeof(SerieViewModel), 200)]
        public async Task<IActionResult> GetSerieByID(Guid idSerie)
        {
            if (!HelperGuid.IsGuid(idSerie.ToString()))
                return BadRequest("Guid Inválido");
            return new OkObjectResult(await Task.Run(() => _serieService.GetSerieByID(idSerie).Result));
        }

        /// <summary>
        /// Método que retorna a serie pelo nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("nome/{nome}")]
        [ProducesResponseType(typeof(SerieViewModel), 200)]
        public async Task<IActionResult> GetSerieByNome(string nome)
        {
            return new OkObjectResult(await _serieService.GetSerieByNome(nome));
        }

        /// <summary>
        /// Método que salva a serie
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("new")]
        [ProducesResponseType(typeof(SerieViewModel), 200)]
        public async Task<IActionResult> NewSerie([FromBody] CreateSerieCommand obj)
        {
            var result = await _serieService.NewSerie(obj);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que atualiza o nome da discipina 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType(typeof(UpdateSerieCommand), 200)]
        public async Task<IActionResult> UpdateSerie([FromBody]UpdateSerieCommand command)
        {
            var result = await _serieService.UpdateSerie(command);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que exclui a serie
        /// </summary>
        /// <param name="idSerie"></param>
        /// <returns></returns>
        [HttpDelete("{idSerie}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(SerieViewModel), 400)]
        public async Task<IActionResult> DeleteSerie(Guid idSerie)
        {
            var result = await _serieService.DeletarSerie(idSerie);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }
    }
}