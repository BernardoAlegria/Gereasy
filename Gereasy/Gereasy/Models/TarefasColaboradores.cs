using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gereasy.Models {

    /// <summary>
    /// Tabela derivada da relação de muitos para muitos entre as tabelas das Tarefas e dos Colaboradores 
    /// </summary>
    public class TarefasColaboradores {

        public TarefasColaboradores() {

        }

        /// <summary>
        /// PK para a tabela de relacionamento entre as tarefas e os colaboradores
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Função atribuida ao Colaborador. Esta função pode ser de Revisor ou de Implementador
        /// </summary>
        [Required(ErrorMessage = "A função é de preenchimento obrigatório")]
        public string Funcao { get; set; }

        //adicionar tempo dedicado
        //*****************************************************************************************

        /// <summary>
        /// FK para o Colaborador
        /// </summary>
        [ForeignKey(nameof(Colaborador))]
        public int ColaboradorFK { get; set; }
        public Colaboradores Colaborador { get; set; }

        /// <summary>
        /// FK para o Tarefa        /// </summary>
        [ForeignKey(nameof(Tarefa))]
        //int? é um workaround para o erro do ciclo https://entityframeworkcore.com/knowledge-base/52268985/may-cause-cycles-or-multiple-cascade-paths--specify-on-delete-no-action-or-on-update-no-action--or-modify-other-foreign-key-constraints
        public int? TarefaFK { get; set; }
        public Tarefas Tarefa { get; set; }
    }
}
