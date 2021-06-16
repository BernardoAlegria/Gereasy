using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gereasy.Models {
    public class Tarefas {

        public Tarefas() {

            // Inicializar a lista de colaboradores associados a esta Tarefa
            ListaDeColaboradoresAtribuidos = new HashSet<TarefasColaboradores>();
        }

        /// <summary>
        /// Identificador de cada Tarefa
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Título da tarefa
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Descrição da tarefa
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Data de criação da Tarefa
        /// </summary>
        public DateTime DataCriacao { get; set; }

        /// <summary>
        /// Data limite de conclusão da tarefa
        /// </summary>
        public DateTime DataLimite { get; set; }

        /// <summary>
        /// Estado de conclusão do projeto. Pendente, em curso, por testar, concluido, aguarda ação externa, cancelado.
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Nível de prioridade atribuído à tarefa. Baixa, média ou alta
        /// </summary>
        public string Prioridade { get; set; }

        /// <summary>
        /// Quantidade de tempo despendido pelos colaboradores nesta tarefa 
        /// </summary>
        public TimeSpan TempoDedicado { get; set; }

        //**********************************************

        /// <summary>
        /// FK para o Projecto ao qual a Tarefa pertence
        /// </summary>
        [ForeignKey(nameof(Projeto))]
        public int ProjetoFK { get; set; }
        public Projetos Projeto { get; set; }

        /// <summary>
        /// Lista de Colaboradores Associados a esta tarefa
        /// </summary>
        public ICollection<TarefasColaboradores> ListaDeColaboradoresAtribuidos { get; set; }
    }
}
