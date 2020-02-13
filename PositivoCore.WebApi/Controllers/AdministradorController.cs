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
    public class AdministradorController : ControllerBase
    {
        public readonly IAdministradorServices _administradorService;
        public AdministradorController(IAdministradorServices administradorService)
        {
            _administradorService = administradorService;
        }

        /// <summary>
        /// Método que retorna todos os administradores cadastrados
        /// </summary>
        /// <returns>Lista de AdministradorViewModel</returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(List<AdministradorViewModel>), 200)]
        public async Task<IActionResult> GetAllAdministradores()
        {
            return new OkObjectResult(await _administradorService.GetAllAdministradores());
        }

        /// <summary>
        /// Método que retorna o administrador pelo id
        /// </summary>
        /// <param name="idAdministrador"></param>
        /// <returns></returns>
        [HttpGet("ID/{idAdministrador}")]
        [ProducesResponseType(typeof(AdministradorViewModel), 200)]
        public async Task<IActionResult> GetAdministradorByID(Guid idAdministrador)
        {
            if (!HelperGuid.IsGuid(idAdministrador.ToString()))
                return BadRequest("Guid Inválido");
            return new OkObjectResult(await Task.Run(() => _administradorService.GetAdministradorById(idAdministrador).Result));
        }

        /// <summary>
        /// Método que retorna o administrador pelo nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("nome/{nome}")]
        [ProducesResponseType(typeof(AdministradorViewModel), 200)]
        public async Task<IActionResult> GetAdministradorByNome(string nome)
        {
            return new OkObjectResult(await _administradorService.GetAdministradorByNome(nome));
        }

        /// <summary>
        /// Método que salva o administrador 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("new")]
        [ProducesResponseType(typeof(AdministradorViewModel), 200)]
        public async Task<IActionResult> NewAdministrador([FromBody] CreateAdministradorCommand obj)
        {
            var result = await _administradorService.NewAdministrador(obj);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que salva uma lista de Administrador 
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        [HttpPost("newAdministradors")]
        [ProducesResponseType(typeof(CreateListAdministradoresCommand), 200)]
        [ProducesResponseType(typeof(AdministradorViewModel), 400)]
        public async Task<IActionResult> NewAdministradorsFromList([FromBody] List<AdministradorViewModel> lst)
        {
            var result = await _administradorService.NewListAdministradores(lst);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que edita uma lista de Administrador 
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        [HttpPost("UpdateAdministradors")]
        [ProducesResponseType(typeof(UpdateListAdministradoresCommand), 200)]
        [ProducesResponseType(typeof(AdministradorViewModel), 400)]
        public async Task<IActionResult> UpdateListAdministradores([FromBody] List<AdministradorViewModel> lst)
        {
            var result = await _administradorService.UpdateListAdministradores(lst);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que deleta uma lista de Administrador 
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        [HttpDelete("DeleteAdministradors")]
        [ProducesResponseType(typeof(DeleteListAdministradoresCommand), 200)]
        [ProducesResponseType(typeof(AdministradorViewModel), 400)]
        public async Task<IActionResult> DeleteListAdministradores([FromBody] List<Guid> lst)
        {
            var result = await _administradorService.DeleteListAdministradores(lst);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que atualiza os dados do administrador 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType(typeof(UpdateAdministradorCommand), 200)]
        [ProducesResponseType(typeof(AdministradorViewModel), 400)]
        public async Task<IActionResult> UpdateAdministrador([FromBody]UpdateAdministradorCommand command)
        {
            var result = await _administradorService.UpdateAdministrador(command);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que exclui o administrador
        /// </summary>
        /// <param name="idAdministrador"></param>
        /// <returns></returns>
        [HttpDelete("{idAdministrador}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(AdministradorViewModel), 400)]
        public async Task<IActionResult> DeletarAdministrador(Guid idAdministrador)
        {
            var result = await _administradorService.DeletarAdministrador(idAdministrador);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }
    }
}