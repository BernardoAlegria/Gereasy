using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gereasy.Models {

    /// <summary>
    /// Descreve os Colaboradores
    /// </summary>
    public class Colaboradores {

        public Colaboradores() {

            // inicializar a lista de Clientes criados por cada Colaborador
            ListaDeClientes = new HashSet<Clientes>();

            // inicializar a lista de Projetos criados por cada Colaborador
            ListaDeProjetosCriados = new HashSet<Projetos>();

            // inicializar a lista de Tarefas criadas por cada Colaborador 
            ListaDeTarefasCriadas = new HashSet<Tarefas>();

            // inicializar a lista de Tarefas atribuidas a cada Colaborador 
            ListaDeTarefasAtribuidas = new HashSet<TarefasColaboradores>();
        }

        /// <summary>
        /// Identificador de cada Colaborador
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do colaborador
        /// </summary>
        [Required(ErrorMessage = "O Nome é de preenchimento obrigatório")]
        [StringLength(60, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        public string Nome { get; set; }

        /// <summary>
        /// Data de nascimento do Colaborador
        /// </summary>
        [Display(Name = "Data Nascimento")]
        public DateTime DataNasc { get; set; }

        /// <summary>
        /// Cargo do colaborador
        /// </summary>
        [Required(ErrorMessage = "O Cargo é de preenchimento obrigatório")]
        [StringLength(30, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        public string Cargo { get; set; }

        /// <summary>
        /// Departamento ao qual o colaborador pertence
        /// </summary>
        [Required(ErrorMessage = "O Departamento é de preenchimento obrigatório")]
        [StringLength(30, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        public string Departamento { get; set; }

        /// <summary>
        /// Email empresarial do Colaborador
        /// </summary>
        [Required(ErrorMessage = "O Email é de preenchimento obrigatório")]
        [EmailAddress(ErrorMessage = "o {0} introduzido não é válido")]
        public string Email { get; set; }

        /// <summary>
        /// Contacto telefónico do colaborador
        /// </summary>
        [Required(ErrorMessage = "O Contacto é de preenchimento obrigatório")]
        [StringLength(14, MinimumLength = 8, ErrorMessage = "O {0} deve ter entre {1} e {2} caracteres.")]
        [RegularExpression("(00)?[0-9]{9,14}", ErrorMessage = "O {0} só aceita algarismos.")]
        public string Contacto { get; set; }

        /// <summary>
        /// Nome do ficheiro com a fotografia do colaborador
        /// </summary>
        public string Foto { get; set; }

        //**********************************************************+

        /// <summary>
        /// Lista de Clientes criados por cada Colaborador
        /// </summary>
        public ICollection<Clientes> ListaDeClientes { get; set; }

        /// <summary>
        /// Lista de Projetos criados por cada Colaborador
        /// </summary>
        public ICollection<Projetos> ListaDeProjetosCriados { get; set; }

        /// <summary>
        /// Lista de Tarefas criadas por cada Colaborador
        /// </summary>
        public ICollection<Tarefas> ListaDeTarefasCriadas { get; set; }

        //***************************************************************
        
        /// <summary>
        /// Lista de Tarefas atribuidas a cada Colaborador
        /// </summary>
        public ICollection<TarefasColaboradores> ListaDeTarefasAtribuidas { get; set; }

    }
}
