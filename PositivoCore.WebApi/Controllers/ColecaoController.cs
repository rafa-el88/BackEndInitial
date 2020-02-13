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
    public class ColecaoController : ControllerBase
    {
        public readonly IColecaoServices _colecaoService;
        public ColecaoController(IColecaoServices colecaoService)
        {
            _colecaoService = colecaoService;
        }

        /// <summary>
        /// Método que retorna todas as coleçãoes cadastrados
        /// </summary>
        /// <returns>Lista de ColecaoViewModel</returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(List<ColecaoViewModel>), 200)]
        public async Task<IActionResult> GetAllColecoes()
        {
            return new OkObjectResult(await _colecaoService.GetAllColecoes());
        }

        /// <summary>
        /// Método que retorna a coleção pelo id
        /// </summary>
        /// <param name="idColecao"></param>
        /// <returns></returns>
        [HttpGet("ID/{idColecao}")]
        [ProducesResponseType(typeof(ColecaoViewModel), 200)]
        public async Task<IActionResult> GetColecaoByID(Guid idColecao)
        {
            if (!HelperGuid.IsGuid(idColecao.ToString()))
                return BadRequest("Guid Inválido");
            return new OkObjectResult(await Task.Run(() => _colecaoService.GetColecaoById(idColecao).Result));
        }

        /// <summary>
        /// Método que retorna a coleção pelo nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("nome/{nome}")]
        [ProducesResponseType(typeof(ColecaoViewModel), 200)]
        public async Task<IActionResult> GetColecaoByNome(string nome)
        {
            return new OkObjectResult(await _colecaoService.GetColecaoByNome(nome));
        }

        /// <summary>
        /// Método que salva a coleção 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("new")]
        [ProducesResponseType(typeof(ColecaoViewModel), 200)]
        public async Task<IActionResult> NewColecao([FromBody] CreateColecaoCommand obj)
        {
            var result = await _colecaoService.NewColecao(obj);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que atualiza os dados da coleção 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType(typeof(UpdateColecaoCommand), 200)]
        [ProducesResponseType(typeof(ColecaoViewModel), 400)]
        public async Task<IActionResult> UpdateColecao([FromBody]UpdateColecaoCommand command)
        {
            var result = await _colecaoService.UpdateColecao(command);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que exclui a coleção
        /// </summary>
        /// <param name="idColecao"></param>
        /// <returns></returns>
        [HttpDelete("{idColecao}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(ColecaoViewModel), 400)]
        public async Task<IActionResult> DeletarColecao(Guid idColecao)
        {
            var result = await _colecaoService.DeletarColecao(idColecao);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }
    }
}