using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gereasy.Models {

    /// <summary>
    /// Descreve os clientes
    /// </summary>
    public class Clientes {

        public Clientes() {

            // inicializar a lista de Projetos de cada cliente
            ListaDeProjetos = new HashSet<Projetos>();
        }

        /// <summary>
        /// Indentificador de cada cliente
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do cliente
        /// </summary>
        [Required(ErrorMessage = "O Nome é de preenchimento obrigatório")]
        [StringLength(30, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        public string Nome { get; set; }

        /// <summary>
        /// Descricao e informação variada acerca do cliente
        /// </summary>
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        /// <summary>
        /// Endereço de email para entrar em contacto com o cliente
        /// </summary>
        [Required(ErrorMessage = "O Email é de preenchimento obrigatório")]
        [EmailAddress(ErrorMessage = "o {0} introduzido não é válido")]
        public string Email { get; set; }

        /// <summary>
        /// Contacto telefónico para entrar em contacto com o cliente
        /// </summary>
        [StringLength(16, MinimumLength = 9, ErrorMessage = "O {0} deve estar compreendido entre {1} e {2} caracteres...")]
        [RegularExpression("(00)?[0-9]{9,14}", ErrorMessage = "O {0} só aceita algarismos.")]
        public string Contacto { get; set; }


        //******************************************************

        /// <summary>
        /// Lista de projetos associados a este cliente
        /// </summary>
        public ICollection<Projetos> ListaDeProjetos { get; set; }
    }
}
