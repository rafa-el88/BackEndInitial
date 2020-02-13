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
    public class MensagemController : ControllerBase
    {
        public readonly IMensagemServices _mensagemService;
        public MensagemController(IMensagemServices mensagemService)
        {
            _mensagemService = mensagemService;
        }

        /// <summary>
        /// Método que retorna todas as mensagens cadastrados
        /// </summary>
        /// <returns>Lista de MensagemViewModel</returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(List<MensagemViewModel>), 200)]
        public async Task<IActionResult> GetAllMensagens()
        {
            return new OkObjectResult(await _mensagemService.GetAllMensagens());
        }

        /// <summary>
        /// Método que retorna a mensagem pelo id
        /// </summary>
        /// <param name="idMensagem"></param>
        /// <returns></returns>
        [HttpGet("ID/{idMensagem}")]
        [ProducesResponseType(typeof(MensagemViewModel), 200)]
        public async Task<IActionResult> GetMensagemByID(Guid idMensagem)
        {
            if (!HelperGuid.IsGuid(idMensagem.ToString()))
                return BadRequest("Guid Inválido");
            return new OkObjectResult(await Task.Run(() => _mensagemService.GetMensagemById(idMensagem).Result));
        }

        /// <summary>
        /// Método que retorna a mensagem pelo assunto
        /// </summary>
        /// <param name="assunto"></param>
        /// <returns></returns>
        [HttpGet("assunto/{assunto}")]
        [ProducesResponseType(typeof(MensagemViewModel), 200)]
        public async Task<IActionResult> GetMensagemByNome(string assunto)
        {
            return new OkObjectResult(await _mensagemService.GetMensagemByAssunto(assunto));
        }

        /// <summary>
        /// Método que salva a mensagem 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("new")]
        [ProducesResponseType(typeof(MensagemViewModel), 200)]
        public async Task<IActionResult> CreateMensagem([FromBody] CreateMensagemCommand obj)
        {
            var result = await _mensagemService.CreateMensagem(obj);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que atualiza os dados da mensagem 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType(typeof(UpdateMensagemCommand), 200)]
        [ProducesResponseType(typeof(MensagemViewModel), 400)]
        public async Task<IActionResult> UpdateMensagem([FromBody]UpdateMensagemCommand command)
        {
            var result = await _mensagemService.UpdateMensagem(command);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que exclui a mensagem
        /// </summary>
        /// <param name="idMensagem"></param>
        /// <returns></returns>
        [HttpDelete("{idMensagem}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(MensagemViewModel), 400)]
        public async Task<IActionResult> DeleteMensagem(Guid idMensagem)
        {
            var result = await _mensagemService.DeleteMensagem(idMensagem);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }
    }
}