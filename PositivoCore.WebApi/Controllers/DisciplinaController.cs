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
    public class DisciplinaController : ControllerBase
    {
        public readonly IDisciplinaServices _disciplinaService;
        public DisciplinaController(IDisciplinaServices disciplinaService)
        {
            _disciplinaService = disciplinaService;
        }
        /// <summary>
        /// Método que retorna todos as disciplinas cadastradas
        /// </summary>
        /// <returns>Lista de DisciplinaViewModel</returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(List<DisciplinaViewModel>), 200)]
        public async Task<IActionResult> GetAllDisciplinas()
        {
            return new OkObjectResult(await _disciplinaService.GetAllDisciplinas());
        }
        /// <summary>
        /// Método que retorna a disciplina pelo id
        /// </summary>
        /// <param name="idDisciplina"></param>
        /// <returns></returns>
        [HttpGet("ID/{idDisciplina}")]
        [ProducesResponseType(typeof(DisciplinaViewModel), 200)]
        public async Task<IActionResult> GetDisciplinaByID(Guid idDisciplina)
        {
            if (!HelperGuid.IsGuid(idDisciplina.ToString()))
                return BadRequest("Guid Inválido");
            return new OkObjectResult(await Task.Run(() => _disciplinaService.GetDisciplinaByID(idDisciplina).Result));
        }
        /// <summary>
        /// Método que retorna a disciplina pelo nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("nome/{nome}")]
        [ProducesResponseType(typeof(DisciplinaViewModel), 200)]
        public async Task<IActionResult> GetDisciplinaByNome(string nome)
        {
            return new OkObjectResult(await _disciplinaService.GetDisciplinaByNome(nome));
        }
        /// <summary>
        /// Método que salva a disciplina
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("new")]
        [ProducesResponseType(typeof(DisciplinaViewModel), 200)]
        public async Task<IActionResult> NewDisciplina([FromBody] CreateDisciplinaCommand obj)
        {
            var result = await _disciplinaService.NewDisciplina(obj);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que atualiza o nome da discipina 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType(typeof(UpdateDisiplinaCommand), 200)]
        public async Task<IActionResult> UpdateDisciplina([FromBody]UpdateDisiplinaCommand command)
        {
            var result = await _disciplinaService.UpdateDisciplina(command);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que exclui a disciplina
        /// </summary>
        /// <param name="idDisciplina"></param>
        /// <returns></returns>
        [HttpDelete("{idDisciplina}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(DisciplinaViewModel), 400)]
        public async Task<IActionResult> DeletarDisciplina(Guid idDisciplina)
        {
            var result = await _disciplinaService.DeletarDisciplina(idDisciplina);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }
    }
}