using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PositivoCore.Application.Commands;
using PositivoCore.Application.Interface.Services;
using PositivoCore.Application.ViewModels;
using PositivoCore.Domain.Enums;
using PositivoCore.Shared.Helper;

namespace PositivoCore.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DestinatarioMensagemController : ControllerBase
    {
        public readonly IDestinatarioMensagemServices _mensagemService;
        public DestinatarioMensagemController(IDestinatarioMensagemServices mensagemService)
        {
            _mensagemService = mensagemService;
        }

        /// <summary>
        /// Método que retorna todos os destinatarios mensagens cadastrados
        /// </summary>
        /// <returns>Lista de DestinatarioMensagemViewModel</returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(List<DestinatarioMensagemViewModel>), 200)]
        public async Task<IActionResult> GetAllDestinatarioMensagens()
        {
            return new OkObjectResult(await _mensagemService.GetAllDestinatarioMensagens());
        }

        /// <summary>
        /// Método que retorna destinatario mensagem pelo id
        /// </summary>
        /// <param name="idDestinatarioMensagem"></param>
        /// <returns></returns>
        [HttpGet("ID/{idDestinatarioMensagem}")]
        [ProducesResponseType(typeof(DestinatarioMensagemViewModel), 200)]
        public async Task<IActionResult> GetDestinatarioMensagemByID(Guid idDestinatarioMensagem)
        {
            if (!HelperGuid.IsGuid(idDestinatarioMensagem.ToString()))
                return BadRequest("Guid Inválido");
            return new OkObjectResult(await Task.Run(() => _mensagemService.GetDestinatarioMensagemById(idDestinatarioMensagem).Result));
        }

        /// <summary>
        /// Método que retorna destinatario mensagem pelo tipo perfil
        /// </summary>
        /// <param name="tipoPerfil"></param>
        /// <returns></returns>
        [HttpGet("tipoPerfil/{tipoPerfil}")]
        [ProducesResponseType(typeof(DestinatarioMensagemViewModel), 200)]
        public async Task<IActionResult> GetDestinatarioMensagemByTipoPerfil(ETipoPerfil tipoPerfil)
        {
            return new OkObjectResult(await _mensagemService.GetDestinatarioMensagemByTipoPerfil(tipoPerfil));
        }

        /// <summary>
        /// Método que retorna destinatario mensagem pelo tipo perfil
        /// </summary>
        /// <param name="idMensagem"></param>
        /// <returns></returns>
        [HttpGet("mensagem/{idMensagem}")]
        [ProducesResponseType(typeof(DestinatarioMensagemViewModel), 200)]
        public async Task<IActionResult> GetDestinatarioMensagemByMensagem(Guid idMensagem)
        {
            return new OkObjectResult(await _mensagemService.GetDestinatarioMensagemByMensagem(idMensagem));
        }

        /// <summary>
        /// Método que salva o destinatario mensagem 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("new")]
        [ProducesResponseType(typeof(DestinatarioMensagemViewModel), 200)]
        public async Task<IActionResult> CreateDestinatarioMensagem([FromBody] CreateDestinatarioMensagemCommand obj)
        {
            var result = await _mensagemService.CreateDestinatarioMensagem(obj);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que atualiza os dados do destinatario mensagem 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType(typeof(UpdateDestinatarioMensagemCommand), 200)]
        [ProducesResponseType(typeof(DestinatarioMensagemViewModel), 400)]
        public async Task<IActionResult> UpdateDestinatarioMensagem([FromBody]UpdateDestinatarioMensagemCommand command)
        {
            var result = await _mensagemService.UpdateDestinatarioMensagem(command);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que exclui o destinatario mensagem
        /// </summary>
        /// <param name="idDestinatarioMensagem"></param>
        /// <returns></returns>
        [HttpDelete("{idDestinatarioMensagem}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(DestinatarioMensagemViewModel), 400)]
        public async Task<IActionResult> DeleteDestinatarioMensagem(Guid idDestinatarioMensagem)
        {
            var result = await _mensagemService.DeleteDestinatarioMensagem(idDestinatarioMensagem);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }
    }
}