using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PositivoCore.Application.Commands.Responsavel;
using PositivoCore.Application.Interface.Services;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Helper;

namespace PositivoCore.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResponsavelController : ControllerBase
    {
        public readonly IResponsavelServices _ResponsavelServices;
        public ResponsavelController(IResponsavelServices responsavelServices)
        {
            _ResponsavelServices = responsavelServices;
        }

        /// <summary>
        /// Método que retorna todas os Responsavels cadastrados
        /// </summary>
        /// <returns>Lista de ResponsavelViewModel</returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(List<ResponsavelViewModel>), 200)]
        public async Task<IActionResult> GetAllResponsavels()
        {
            return new OkObjectResult(await _ResponsavelServices.GetAllResponsavels());
        }

        /// <summary>
        /// Método que retorna o Responsavel pelo id
        /// </summary>
        /// <param name="idResponsavel"></param>
        /// <returns></returns>
        [HttpGet("ID/{idResponsavel}")]
        [ProducesResponseType(typeof(ResponsavelViewModel), 200)]
        public async Task<IActionResult> GetResponsavelByID(Guid idResponsavel)
        {
            if (!HelperGuid.IsGuid(idResponsavel.ToString()))
                return BadRequest("Guid Inválido");
            return new OkObjectResult(await Task.Run(() => _ResponsavelServices.GetResponsavelById(idResponsavel).Result));
        }

        /// <summary>
        /// Método que retorna o Responsavel pelo nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("nome/{nome}")]
        [ProducesResponseType(typeof(ResponsavelViewModel), 200)]
        public async Task<IActionResult> GetResponsavelByNome(string nome)
        {
            return new OkObjectResult(await _ResponsavelServices.GetResponsavelByNome(nome));
        }

        /// <summary>
        /// Método que salva o Responsavel 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("new")]
        [ProducesResponseType(typeof(ResponsavelViewModel), 200)]
        public async Task<IActionResult> NewResponsavel([FromBody] CreateResponsavelCommand obj)
        {
            var result = await _ResponsavelServices.NewResponsavel(obj);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que atualiza o nome do Responsavel 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType(typeof(UpdateResponsavelCommand), 200)]
        public async Task<IActionResult> UpdateResponsavel([FromBody]UpdateResponsavelCommand command)
        {
            var result = await _ResponsavelServices.UpdateResponsavel(command);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que exclui o Responsavel
        /// </summary>
        /// <param name="idResponsavel"></param>
        /// <returns></returns>
        [HttpDelete("{idResponsavel}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(ResponsavelViewModel), 400)]
        public async Task<IActionResult> DeletarResponsavel(Guid idResponsavel)
        {
            var result = await _ResponsavelServices.DeleteResponsavel(idResponsavel);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }
    }
}