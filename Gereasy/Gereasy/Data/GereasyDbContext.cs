using Gereasy.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gereasy.Data {

    /// <summary>
    /// Representa a DB dos criadores de caes
    /// </summary>
    public class GereasyDbContext : IdentityDbContext {
        public GereasyDbContext(DbContextOptions<GereasyDbContext> options)
            : base(options) {
        }

        /// <summary>
        /// Metodo para assistir a criação da base de dados que representa o modelo
        /// </summary>
        /// <param name="builder"> opção de configuração</param>
        protected override void OnModelCreating(ModelBuilder builder) {


            // importar o comportamento deste método da clasee DbContext
            base.OnModelCreating(builder);
        }


        // Tabelas da base de dados
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Colaboradores> Colaboradores { get; set; }
        public DbSet<Projetos> Projetos { get; set; }
        public DbSet<Tarefas> Tarefas { get; set; }
        public DbSet<TarefasColaboradores> TarefasColaboradores { get; set; }


    }
}
