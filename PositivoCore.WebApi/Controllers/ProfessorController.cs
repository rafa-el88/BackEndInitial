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
    public class ProfessorController : ControllerBase
    {
        public readonly IProfessorServices _professorService;
        public ProfessorController(IProfessorServices professorService)
        {
            _professorService = professorService;
        }

        /// <summary>
        /// Método que retorna todas os professores cadastrados
        /// </summary>
        /// <returns>Lista de ProfessorViewModel</returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(List<ProfessorViewModel>), 200)]
        public async Task<IActionResult> GetAllProfessores()
        {
            return new OkObjectResult(await _professorService.GetAllProfessores());
        }

        /// <summary>
        /// Método que retorna o professor pelo id
        /// </summary>
        /// <param name="idProfessor"></param>
        /// <returns></returns>
        [HttpGet("ID/{idProfessor}")]
        [ProducesResponseType(typeof(ProfessorViewModel), 200)]
        public async Task<IActionResult> GetProfessorByID(Guid idProfessor)
        {
            if (!HelperGuid.IsGuid(idProfessor.ToString()))
                return BadRequest("Guid Inválido");
            return new OkObjectResult(await Task.Run(() => _professorService.GetProfessorById(idProfessor).Result));
        }

        /// <summary>
        /// Método que retorna o professor pelo cpf
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [HttpGet("CPF/{cpf}")]
        [ProducesResponseType(typeof(ProfessorViewModel), 200)]
        public async Task<IActionResult> GetProfessorByCPF(string cpf)
        {
            return new OkObjectResult(await _professorService.GetProfessorByCPF(cpf));
        }

        /// <summary>
        /// Método que retorna o professor pelo nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("nome/{nome}")]
        [ProducesResponseType(typeof(ProfessorViewModel), 200)]
        public async Task<IActionResult> GetProfessorByNome(string nome)
        {
            return new OkObjectResult(await _professorService.GetProfessorByNome(nome));
        }

        /// <summary>
        /// Método que salva o professor 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("new")]
        [ProducesResponseType(typeof(ProfessorViewModel), 200)]
        public async Task<IActionResult> NewProfessor([FromBody] CreateProfessorCommand obj)
        {
            var result = await _professorService.NewProfessor(obj);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que atualiza o nome do professor 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType(typeof(UpdateProfessorCommand), 200)]
        public async Task<IActionResult> UpdateProfessor([FromBody]UpdateProfessorCommand command)
        {
            var result = await _professorService.UpdateProfessor(command);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que exclui o professor
        /// </summary>
        /// <param name="idProfessor"></param>
        /// <returns></returns>
        [HttpDelete("{idProfessor}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(ProfessorViewModel), 400)]
        public async Task<IActionResult> DeleteProfessor(Guid idProfessor)
        {
            var result = await _professorService.DeletarProfessor(idProfessor);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }
    }
}