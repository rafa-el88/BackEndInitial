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
    public class NivelEnsinoController : ControllerBase
    {
        public readonly INivelEnsinoServices _nivelEnsinoService;
        public NivelEnsinoController(INivelEnsinoServices nivelEnsinoService)
        {
            _nivelEnsinoService = nivelEnsinoService;
        }

        /// <summary>
        /// Método que retorna todos os níveis de ensino cadastrados
        /// </summary>
        /// <returns>Lista de NivelEnsinoViewModel</returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(List<NivelEnsinoViewModel>), 200)]
        public async Task<IActionResult> GetAllNiveisEnsino()
        {
            return new OkObjectResult(await _nivelEnsinoService.GetAllNiveisEnsino());
        }

        /// <summary>
        /// Método que retorna o nível de ensino pelo id
        /// </summary>
        /// <param name="idNivelEnsino"></param>
        /// <returns></returns>
        [HttpGet("ID/{idNivelEnsino}")]
        [ProducesResponseType(typeof(NivelEnsinoViewModel), 200)]
        public async Task<IActionResult> GetNivelEnsinoByID(Guid idNivelEnsino)
        {
            if (!HelperGuid.IsGuid(idNivelEnsino.ToString()))
                return BadRequest("Guid Inválido");
            return new OkObjectResult(await Task.Run(() => _nivelEnsinoService.GetNivelEnsinoByID(idNivelEnsino).Result));
        }

        /// <summary>
        /// Método que retorna o nível ensino pelo nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("nome/{nome}")]
        [ProducesResponseType(typeof(NivelEnsinoViewModel), 200)]
        public async Task<IActionResult> GetNivelEnsinoByNome(string nome)
        {
            return new OkObjectResult(await _nivelEnsinoService.GetNivelEnsinoByNome(nome));
        }

        /// <summary>
        /// Método que salva o nível ensino 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("new")]
        [ProducesResponseType(typeof(NivelEnsinoViewModel), 200)]
        public async Task<IActionResult> NewNivelEnsino([FromBody] CreateNivelEnsinoCommand obj)
        {
            var result = await _nivelEnsinoService.NewNivelEnsino(obj);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que atualiza o nome da discipina 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType(typeof(UpdateNivelEnsinoCommand), 200)]
        public async Task<IActionResult> UpdateNivelEnsino([FromBody]UpdateNivelEnsinoCommand command)
        {
            var result = await _nivelEnsinoService.UpdateNivelEnsino(command);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que exclui o nivel ensino
        /// </summary>
        /// <param name="idNivelEnsino"></param>
        /// <returns></returns>
        [HttpDelete("{idNivelEnsino}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(NivelEnsinoViewModel), 400)]
        public async Task<IActionResult> DeleteNivelEnsino(Guid idNivelEnsino)
        {
            var result = await _nivelEnsinoService.DeletarNivelEnsino(idNivelEnsino);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }
    }
}