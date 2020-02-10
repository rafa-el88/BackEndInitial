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
    public class TurmaController : ControllerBase
    {
        public readonly ITurmaServices _turmaService;
        public TurmaController(ITurmaServices turmaService)
        {
            _turmaService = turmaService;
        }

        /// <summary>
        /// Método que retorna todas as turmas
        /// </summary>
        /// <returns>Lista de TurmaViewModel</returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(List<TurmaViewModel>), 200)]
        public async Task<IActionResult> GetAllTurmas()
        {
            return new OkObjectResult(await _turmaService.GetAllTurmas());
        }

        /// <summary>
        /// Método que retorna a turma pelo id
        /// </summary>
        /// <param name="idTurma"></param>
        /// <returns></returns>
        [HttpGet("ID/{idTurma}")]
        [ProducesResponseType(typeof(TurmaViewModel), 200)]
        public async Task<IActionResult> GetTurmaByID(Guid idTurma)
        {
            if (!HelperGuid.IsGuid(idTurma.ToString()))
                return BadRequest("Guid Inválido");
            return new OkObjectResult(await Task.Run(() => _turmaService.GetTurmaByID(idTurma).Result));
        }

        /// <summary>
        /// Método que retorna a turma pelo nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("nome/{nome}")]
        [ProducesResponseType(typeof(TurmaViewModel), 200)]
        public async Task<IActionResult> GetTurmaByNome(string nome)
        {
            return new OkObjectResult(await _turmaService.GetTurmaByNome(nome));
        }
        
        /// <summary>
        /// Método que salva a turma
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("new")]
        [ProducesResponseType(typeof(TurmaViewModel), 200)]
        public async Task<IActionResult> NewTurma([FromBody] CreateTurmaCommand obj)
        {
            var result = await _turmaService.NewTurma(obj);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que vincula a turma a disciplina e professor
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("attachTurmaDisciplinaProfessor")]
        [ProducesResponseType(typeof(TurmaDisciplinaProfessorViewModel), 200)]
        public async Task<IActionResult> AttachTurmaDisciplinaProfessor([FromBody] List<TurmaDisciplinaProfessorViewModel> obj)
        {
            var result = await _turmaService.AttachTurmaDisciplinaProfessor(obj);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que atualiza o nome da turma
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType(typeof(UpdateTurmaCommand), 200)]
        public async Task<IActionResult> UpdateTurma([FromBody]UpdateTurmaCommand command)
        {
            var result = await _turmaService.UpdateTurma(command);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que exclui a turma
        /// </summary>
        /// <param name="idTurma"></param>
        /// <returns></returns>
        [HttpDelete("{idTurma}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(TurmaViewModel), 400)]
        public async Task<IActionResult> DeleteTurma(Guid idTurma)
        {
            var result = await _turmaService.DeletarTurma(idTurma);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }
    }
}