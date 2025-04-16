using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tarefas
    {
        private List<TarefaDTO> _lstTarefas = new List<TarefaDTO>(); // cria  uma propriedade privada para armazenar a lista de tarefas

        public Tarefas() // método construtor que popula a lista
        {
            _lstTarefas.Add(new TarefaDTO
            {
                ID_TAREFA = 1,
                DS_TAREFA = "Fazer Compras"
            });

            _lstTarefas.Add(new TarefaDTO
            {
                ID_TAREFA = 2,
                DS_TAREFA = "Fazer Atividad Faculdade"
            });

            _lstTarefas.Add(new TarefaDTO
            {
                ID_TAREFA = 3,
                DS_TAREFA = "Subir Projeto de Teste no GitHub"
            });
        }

        public List<TarefaDTO> lstTarefas()
        {
            try
            {
                return _lstTarefas; // retorna a lstTarefas
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public bool InserirTarefa(TarefaDTO Request)
        {
            try
            {
                _lstTarefas.Add(Request); // adiciona a nova tarefa na lista
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar adicionar  a tarefa", ex);
            }
        }
        public bool DeletarTarefa(int ID_TAREFA)
        {
            try
            {
                var tarefa = _lstTarefas.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);
                if (tarefa != null) // Se a Tarefa com o ID recebido no parametro exista (for diferente de nula)
                {
                    _lstTarefas.Remove(tarefa); // remove a tarefa da lista
                    return true; // retorna true caso exclua
                }
                else // Caso a Tarefa não exista na lista
                {
                    throw new Exception($"Tarefa {ID_TAREFA} não encontrada"); // retorna uma exception com tarefa não encontrada
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar excluir a tarefa", ex);
            }
        }

        public bool AtualizarTarefa(TarefaDTO tarefaAtualizada)
        {
            try
            {
                var tarefaNaLista = _lstTarefas.FirstOrDefault(x => x.ID_TAREFA == tarefaAtualizada.ID_TAREFA);

                if (tarefaNaLista != null) // Se existir uma Tarefa com o ID igual ao ID da tarefa recebida no parametro (for diferente de nula)
                {
                    var indexDaTarefa = _lstTarefas.IndexOf(tarefaNaLista); // pega o indice na _lstTarefas da tarefa que foi recebida no parametro
                    _lstTarefas[indexDaTarefa] = tarefaAtualizada; // pega o objeto que tenha o indice do que foi recebido e substitui com o novo
                    return true; // retorna true caso atualiza

                }
                else // Caso a Tarefa não exista na lista
                {
                    throw new Exception($"Tarefa {tarefaAtualizada.ID_TAREFA} não encontrada"); // retorna uma exception com tarefa não encontrada
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar atualizar a tarefa", ex);
            }
        }
    }
}
