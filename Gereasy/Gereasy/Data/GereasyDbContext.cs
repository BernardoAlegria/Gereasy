using Gereasy.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gereasy.Data {
    public class GereasyDbContext : IdentityDbContext {
        public GereasyDbContext(DbContextOptions<GereasyDbContext> options)
            : base(options) {
        }



        // Tabelas da base de dados
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Colaboradores> Colaboradores { get; set; }
        public DbSet<Projetos> Projetos { get; set; }
        public DbSet<Tarefas> Tarefas { get; set; }
        public DbSet<TarefasColaboradores> TarefasColaboradores { get; set; }


    }
}
