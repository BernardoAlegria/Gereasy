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
        [Required(ErrorMessage = "O Título é de preenchimento obrigatório")]
        [StringLength(50, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        public string Titulo { get; set; }

        /// <summary>
        /// Descrição da tarefa
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Data de criação da Tarefa
        /// </summary>
        [Required(ErrorMessage = "A Data de Criação é de preenchimento obrigatório")]
        public DateTime DataCriacao { get; set; }

        /// <summary>
        /// Data limite de conclusão da tarefa
        /// </summary>
        [Required(ErrorMessage = "A Data Limite é de preenchimento obrigatório")]
        public DateTime DataLimite { get; set; }

        /// <summary>
        /// Estado de conclusão do projeto. Pendente, em curso, por testar, concluido, aguarda ação externa, cancelado.
        /// Ao ser criada uma tarefa, é automáticamente considerada "Pendente"
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Nível de prioridade atribuído à tarefa. Baixa, média ou alta
        /// </summary>
        [Required(ErrorMessage = "A Prioridade é de preenchimento obrigatório")]
        public string Prioridade { get; set; }

        /// <summary>
        /// Quantidade de tempo despendido pelos colaboradores nesta tarefa. Apenas para a base de dados, para operações utilizar o atributo "TempoDedicadoTimeSpan"
        /// Não pode ser do tipo TimeSpan. No SQL Server é criado um atributo do tipo "date(7)" que apenas suporta até 24h, o TimeSpan pode ter dias.
        /// No nosso caso precisamos dos dias, por isso vamos guardar o tempo em "ticks" com a ajuda do atributo "TempoDedicadoTimeSpan". 
        /// </summary>
        public long TempoDedicadoTotal { get; set; }

        /// <summary>
        /// Atributo auxiliar para resolver o problema do atributo TempoDedicadoTotal.
        /// </summary>
        [NotMapped]
        public TimeSpan TempoDedicadoTimeSpan {
            // Caso seja preciso o atributo, devolve um objeto TimeSpan criado a partir do numero de ticks
            get { return TimeSpan.FromTicks(TempoDedicadoTotal); }
            // Caso seja necessário alterar, o TimeSpan é alterado para ticks e altera-se o atributo TempoDedicadoTotal
            set { TempoDedicadoTotal = value.Ticks; }
        }



        //**********************************************

        /// <summary>
        /// FK para o Projecto ao qual a Tarefa pertence
        /// </summary>
        [ForeignKey(nameof(Projeto))]
        public int? ProjetoFK { get; set; }
        public Projetos Projeto { get; set; }

        /// <summary>
        /// FK para o Colaborador que criou a tarefa
        /// </summary>
        [ForeignKey(nameof(Colaborador))]
        public int ColaboradorFK { get; set; }
        public Colaboradores Colaborador { get; set; }

        /// <summary>
        /// Lista de Colaboradores Associados a esta tarefa
        /// </summary>
        public ICollection<TarefasColaboradores> ListaDeColaboradoresAtribuidos { get; set; }
    }
}
