using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PositivoCore.Application.Commands;
using PositivoCore.Application.Commands.Aluno;
using PositivoCore.Application.Interface.Services;
using PositivoCore.Application.ViewModels;
using PositivoCore.Shared.Helper;

namespace PositivoCore.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        public readonly IAlunoServices _alunoService;
        public AlunoController(IAlunoServices alunoService)
        {
            _alunoService = alunoService;
        }

        /// <summary>
        /// Método que retorna todas os alunos cadastrados
        /// </summary>
        /// <returns>Lista de AlunoViewModel</returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(List<AlunoViewModel>), 200)]
        public async Task<IActionResult> GetAllAlunos()
        {
            return new OkObjectResult(await _alunoService.GetAllAlunos());
        }

        /// <summary>
        /// Método que retorna o aluno pelo id
        /// </summary>
        /// <param name="idAluno"></param>
        /// <returns></returns>
        [HttpGet("ID/{idAluno}")]
        [ProducesResponseType(typeof(AlunoViewModel), 200)]
        public async Task<IActionResult> GetAlunoByID(Guid idAluno)
        {
            if (!HelperGuid.IsGuid(idAluno.ToString()))
                return BadRequest("Guid Inválido");
            return new OkObjectResult(await Task.Run(() => _alunoService.GetAlunoById(idAluno).Result));
        }

        /// <summary>
        /// Método que retorna o aluno pelo nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("nome/{nome}")]
        [ProducesResponseType(typeof(AlunoViewModel), 200)]
        public async Task<IActionResult> GetAlunoByNome(string nome)
        {
            return new OkObjectResult(await _alunoService.GetAlunoByNome(nome));
        }

        /// <summary>
        /// Método que salva o aluno 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("new")]
        [ProducesResponseType(typeof(AlunoViewModel), 200)]
        public async Task<IActionResult> NewAluno([FromBody] CreateAlunoCommand obj)
        {
            var result = await _alunoService.NewAluno(obj);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que salva uma lista de aluno 
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        [HttpPost("newAlunos")]
        [ProducesResponseType(typeof(CreateListStudentsCommand), 200)]
        [ProducesResponseType(typeof(AlunoViewModel), 400)]
        public async Task<IActionResult> NewAlunosFromList([FromBody] List<AlunoViewModel> lst)
        {
            var result = await _alunoService.NewListStudents(lst);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que edita uma lista de aluno 
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        [HttpPost("UpdateAlunos")]
        [ProducesResponseType(typeof(UpdateListStudentsCommand), 200)]
        [ProducesResponseType(typeof(AlunoViewModel), 400)]
        public async Task<IActionResult> UpdateListStudents([FromBody] List<AlunoViewModel> lst)
        {
            var result = await _alunoService.UpdateListStudents(lst);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que deleta uma lista de aluno 
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        [HttpDelete("DeleteAlunos")]
        [ProducesResponseType(typeof(DeleteListStudentsCommand), 200)]
        [ProducesResponseType(typeof(AlunoViewModel), 400)]
        public async Task<IActionResult> DeleteListStudents([FromBody] List<Guid> lst)
        {
            var result = await _alunoService.DeleteListStudents(lst);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que atualiza os dados do aluno 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType(typeof(UpdateAlunoCommand), 200)]
        [ProducesResponseType(typeof(AlunoViewModel), 400)]
        public async Task<IActionResult> UpdateAluno([FromBody]UpdateAlunoCommand command)
        {
            var result = await _alunoService.UpdateAluno(command);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }

        /// <summary>
        /// Método que exclui o aluno
        /// </summary>
        /// <param name="idAluno"></param>
        /// <returns></returns>
        [HttpDelete("{idAluno}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(AlunoViewModel), 400)]
        public async Task<IActionResult> DeletarAluno(Guid idAluno)
        {
            var result = await _alunoService.DeletarAluno(idAluno);
            return result.Sucesso ? new ObjectResult(result) : BadRequest(result);
        }
    }
}