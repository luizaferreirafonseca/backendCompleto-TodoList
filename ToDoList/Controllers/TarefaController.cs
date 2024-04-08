using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTO;
using ToDoList.Domain.Services;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {

        private readonly TarefaService _tarefaService;

        public TarefaController(TarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpPost("CadastrarTarefa")]

        public ActionResult CadastrarTarefa([FromBody] TarefaDTO tarefaDto)
        {
            try
            {
                var tarefasAtualizadas = _tarefaService.Cadastrar(tarefaDto);
                return Ok(new
                {
                    Message = "Tarefa cadastrada com sucesso!",
                    Tarefas = tarefasAtualizadas
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpDelete("DeletarTarefa")]
        public ActionResult DeletarTarefa(int id)
        {
            try
            {
                bool deletado = _tarefaService.Deletar(id);
                if (!deletado)
                {
                    return NotFound(new { Message = $"A tarefa com ID {id} não foi encontrada." });
                }
                return Ok(new { Message = "Tarefa deletada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public ActionResult PegarTarefaPeloId(int id)
        {
            try
            {
                var tarefa = _tarefaService.PegarPeloId(id);
                return Ok(tarefa);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPut("Editar/{id}")]
        public ActionResult EditarTarefa(int id, [FromBody] TarefaDTO tarefaPraEditar)
        {
            try
            {
                var tarefaEditada = _tarefaService.Editar(id, tarefaPraEditar);
                return Ok(tarefaEditada);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }



    }
}
