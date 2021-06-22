using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gereasy.Models {

    /// <summary>
    /// Descreve os projetos
    /// </summary>
    public class Projetos {

        public Projetos() {

            // inicializar a lista de Tarefas de cada Projeto
            ListaDeTarefas = new HashSet<Tarefas>();

        }

        /// <summary>
        /// Identificador do projeto
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do projeto
        /// </summary>
        [Required(ErrorMessage = "O Nome é de preenchimento obrigatório")]
        [StringLength(30, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        public string Nome { get; set; }

        /// <summary>
        /// Descrição do projeto
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Data de criação do Projeto
        /// </summary>
        [Required(ErrorMessage = "A Data de Criação é de preenchimento obrigatório")] 
        public DateTime DataCriacao { get; set; }

        /// <summary>
        /// Data prevista para a conclusão do projeto
        /// </summary>
        [Required(ErrorMessage = "A Data Prevista é de preenchimento obrigatório")] 
        public TimeSpan DataPrevista { get; set; }

        /// <summary>
        /// Data de inicio do projeto
        /// </summary>
        public DateTime DataInicio { get; set; }

        /// <summary>
        /// Data de conclusão do projeto
        /// </summary>
        public DateTime DataFim { get; set; }

        //**************************************

        /// <summary>
        /// FK para o Cliente ao qual este projeto corresponde
        /// </summary>
        [ForeignKey(nameof(Cliente))]
        public int ClienteFK { get; set; }
        public Clientes Cliente { get; set; }

        /// <summary>
        /// FK para o Colaborador que criou este projeto
        /// </summary>
        [ForeignKey(nameof(Criador))]
        public int CriadorFK { get; set; }
        public Colaboradores Criador { get; set; }

        /// <summary>
        /// Lista de tarefas associadas a este projeto
        /// </summary>
        public ICollection<Tarefas> ListaDeTarefas { get; set; }
    }
}
