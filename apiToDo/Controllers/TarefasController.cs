using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        //[Authorize]
        [HttpGet("lstTarefas")]
        public ActionResult lstTarefas()
        {
            try
            {
                Tarefas Tarefas = new Tarefas(); // Cria uma instância da classe Tarefas.
                List<TarefaDTO> lstTarefas = Tarefas.lstTarefas(); // Cria uma lista do tipo TarefaDTO e chamo o método lstTarefas() que traz a lista.
                return StatusCode(200, lstTarefas); // Retorna StatusCode 200 e retorna a lista de tarefas.
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}"});
            }
        }

        [HttpPost("InserirTarefas")]
        public ActionResult InserirTarefas([FromBody] TarefaDTO Request)
        {
            try
            {
                Tarefas Tarefas = new Tarefas(); // Cria uma instância da classe Tarefas.
                Tarefas.InserirTarefa(Request); // Chama o método InserirTarefa() da classe Tarefa e insere o que foi recebido como parametro na lista.

                List<TarefaDTO> lstTarefas = Tarefas.lstTarefas(); // Cria uma lista do tipo TarefaDTO e chamo o método lstTarefas() que traz a lista com  a nova modificação.
                return StatusCode(200, lstTarefas); // Retorna StatusCode 200 e retorna a lista de tarefas atualizada.
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpDelete("DeletarTarefa")]
        public ActionResult DeleteTask([FromQuery] int ID_TAREFA)
        {
            try
            {
                Tarefas Tarefas = new Tarefas(); // Cria uma instância da classe Tarefas.
                Tarefas.DeletarTarefa(ID_TAREFA); // Chama o metodo DeletarTarefa() da classe tarefa que recebe o ID recebido no parâmetro // e se existe um objeto com o id, exclui da lista;

                List<TarefaDTO> lstTarefas = Tarefas.lstTarefas(); // Cria uma lista do tipo TarefaDTO e chamo o método lstTarefas() que traz a lista atualizada com a nova modificação.
                return StatusCode(200, lstTarefas); // Retorna StatusCode 200 e retorna a lista de tarefas atualizada.
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
    }
}
