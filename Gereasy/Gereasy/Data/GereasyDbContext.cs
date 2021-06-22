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

            // Seed da base de dados
            // TODO roles

            // Adicionar dados às tabelas

            builder.Entity<Clientes>().HasData(
                new Clientes { Id = 1, Nome = "BioVip", Descricao = "Empresa de Suplementos alimentares e produtos cosméticos" , Email = "biovip@biovip.pt", Contacto = "926926926" },
                new Clientes { Id = 2, Nome = "XPTO", Descricao = "Empresa produtora de produtos XPTO", Email = "xpto@xpto.pt", Contacto = "912912912" },
                new Clientes { Id = 3, Nome = "ACME", Descricao = "American Company Makes Everything. Empresa conhecida, em particular, pelo seu patrocínio a Coiote, na sua caça pelo Bip-Bip", Email = "acme@acme.com", Contacto = "903903903" }
            );

            // Colaboradores



            builder.Entity<Projetos>().HasData(
                new Projetos { Id = 1, Nome = "WebSite Comercial", Descricao = "Realização de um WebSite aberto ao público para divulgação e venda dos seus produtos.", DataCriacao = new DateTime(2021, 6, 18), DataPrevista = new DateTime(2022, 6, 18), DataInicio = new DateTime(2022, 6, 29), ClienteFK = 1, CriadorFK = 999999999 },
                new Projetos { Id = 2, Nome = "App mobile Comercial", Descricao = "Realização de uma aplicação para Android e IOS para divuldagação e venda dos produtos do cliente.", DataCriacao = new DateTime(2021, 5, 18), DataPrevista = new DateTime(2022, 4, 1), DataInicio = new DateTime(2022, 6, 2), ClienteFK = 1, CriadorFK = 999999999 },
                new Projetos { Id = 3, Nome = "Jogo Mobile", Descricao = "Realização de um Jogo para Android para promoção dos produtos XPTO do cliente.", DataCriacao = new DateTime(2020, 1, 1), DataPrevista = new DateTime(2020, 9, 1), DataInicio = new DateTime(2020, 1, 8), DataFim = new DateTime(2020, 8, 1) ,ClienteFK = 2, CriadorFK = 999999999 },
                new Projetos { Id = 4, Nome = "XPTOshop", Descricao = "Realização de um WebSite para venda de produtos para todo o mundo.", DataCriacao = new DateTime(2020, 2, 20), DataPrevista = new DateTime(2020, 12, 1), DataInicio = new DateTime(2020, 2, 22), ClienteFK = 2, DataFim = new DateTime(2021, 1, 8) ,CriadorFK = 999999999 },
                new Projetos { Id = 5, Nome = "Programa De Gestão de Rega", Descricao = "Realização de um programa para gerir sistema de rega.", DataCriacao = new DateTime(2021, 6, 18), DataPrevista = new DateTime(2022, 7, 18), DataInicio = new DateTime(2022, 6, 18), ClienteFK = 1, CriadorFK = 999999999 }
            );


        }


        // Tabelas da base de dados
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Colaboradores> Colaboradores { get; set; }
        public DbSet<Projetos> Projetos { get; set; }
        public DbSet<Tarefas> Tarefas { get; set; }
        public DbSet<TarefasColaboradores> TarefasColaboradores { get; set; }


    }
}
