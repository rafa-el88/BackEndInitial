using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PositivoCore.Application.Commands.ConvidadosEventos;
using PositivoCore.Application.Interface.Services;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Helper;

namespace PositivoCore.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConvidadosEventoController : ControllerBase
    {
        private readonly IConvidadosEventoServices _convidadosEventoServices;

        public ConvidadosEventoController(IConvidadosEventoServices convidadosEventoServices)
        {
            _convidadosEventoServices = convidadosEventoServices;
        }

        /// <summary>
        /// Método que retorna todos as convidadosEvento cadastradas
        /// </summary>
        /// <returns>Lista de ConvidadosEventoViewModel</returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(List<ConvidadosEventoViewModel>), 200)]
        public async Task<IActionResult> GetAllconvidadosEvento()
        {
            return new OkObjectResult(await _convidadosEventoServices.GetAllConvidadosEventos());
        }

        /// <summary>
        /// Método que retorna a ConvidadosEvento pelo id
        /// </summary>
        /// <param name="idConvidadosEvento"></param>
        /// <returns></returns>
        [HttpGet("ID/{idConvidadosEvento}")]
        [ProducesResponseType(typeof(ConvidadosEventoViewModel), 200)]
        public async Task<IActionResult> GetConvidadosEventoByID(Guid idConvidadosEvento)
        {
            if (!HelperGuid.IsGuid(idConvidadosEvento.ToString()))
                return BadRequest("Guid Inválido");
            return new OkObjectResult(await _convidadosEventoServices.GetConvidadosEventoByID(idConvidadosEvento));
        }

        /// <summary>
        /// Método que retorna a ConvidadosEvento pelo nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("nome/{nome}")]
        [ProducesResponseType(typeof(ConvidadosEventoViewModel), 200)]
        public async Task<IActionResult> GetConvidadosEventoByNome(string nome)
        {
            return new OkObjectResult(await _convidadosEventoServices.GetConvidadosEventoByNome(nome));
        }
        
        /// <summary>
        /// Método que salva a ConvidadosEvento
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("new")]
        [ProducesResponseType(typeof(ConvidadosEventoViewModel), 200)]
        public async Task<IActionResult> NewConvidadosEvento([FromBody] CreateConvidadosEventoCommand obj)
        {
            var result = await _convidadosEventoServices.NewConvidadosEvento(obj);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que atualiza o nome da discipina 
        /// </summary>-
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType(typeof(UpdateConvidadosEventoCommand), 200)]
        public async Task<IActionResult> UpdateConvidadosEvento([FromBody]UpdateConvidadosEventoCommand command)
        {
            var result = await _convidadosEventoServices.UpdateConvidadosEvento(command);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que exclui a ConvidadosEvento
        /// </summary>
        /// <param name="idConvidadosEvento"></param>
        /// <returns></returns>
        [HttpDelete("{idConvidadosEvento}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(ConvidadosEventoViewModel), 400)]
        public async Task<IActionResult> DeletarConvidadosEvento(Guid idConvidadosEvento)
        {
            var result = await _convidadosEventoServices.DeletarConvidadosEvento(idConvidadosEvento);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }
    }
}