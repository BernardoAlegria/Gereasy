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
                new Clientes { Id = 1, Nome = "BioVip", Descricao = "Empresa de Suplementos alimentares e produtos cosméticos", Email = "biovip@biovip.pt", Contacto = "926926926" },
                new Clientes { Id = 2, Nome = "XPTO", Descricao = "Empresa produtora de produtos XPTO", Email = "xpto@xpto.pt", Contacto = "912912912" },
                new Clientes { Id = 3, Nome = "ACME", Descricao = "American Company Makes Everything. Empresa conhecida, em particular, pelo seu patrocínio a Coiote, na sua caça pelo Bip-Bip", Email = "acme@acme.com", Contacto = "903903903" }
            );

            // Colaboradores

            builder.Entity<Colaboradores>().HasData(
                new Colaboradores { Id = 1, Nome = "Patrícia Contente", DataNasc = new DateTime(1990, 2, 2), Cargo = "Gestor", Departamento = "Gestão", Email = "PatriciaContente@empresa.com", Contacto = "9111111111", Foto = "PatriciaContente.jpg"},
                new Colaboradores { Id = 2, Nome = "Beatriz Bonito", DataNasc = new DateTime(1994, 9, 28), Cargo = "Gestor", Departamento = "Administração", Email = "BeatrizBonito@empresa.com", Contacto = "9111111112", Foto = "BeatrizBonito.jpg" },
                new Colaboradores { Id = 3, Nome = "Paulo Pereira", DataNasc = new DateTime(1996, 6, 16), Cargo = "Gestor", Departamento = "Gestão", Email = "PauloPereira@empresa.com", Contacto = "9111111113", Foto = "PauloPereira.jpg" },
                new Colaboradores { Id = 4, Nome = "Vadims Zinatulins", DataNasc = new DateTime(1995, 1, 9), Cargo = "Gestor", Departamento = "Gestão", Email = "VadimsZinatulins@empresa.com", Contacto = "9111111114", Foto = "VadimsZinatulins.jpg" },
                new Colaboradores { Id = 5, Nome = "Zé Maria", DataNasc = new DateTime(1996, 3, 4), Cargo = "Técnico", Departamento = "Informática", Email = "ZeMaria@empresa.com", Contacto = "9111111115", Foto = "ZeMaria.jpg" },
                new Colaboradores { Id = 6, Nome = "Marisa Vieira", DataNasc = new DateTime(1996, 12, 13), Cargo = "Técnico", Departamento = "Informática", Email = "Marisa Vieira@empresa.com", Contacto = "9111111116", Foto = "MarisaVieira.jpg" },
                new Colaboradores { Id = 7, Nome = "Paula Silva", DataNasc = new DateTime(1992, 11, 12), Cargo = "Técnico", Departamento = "Informática", Email = "PaulaSilva@empresa.com", Contacto = "9111111117", Foto = "PaulaSilva.jpg" },
                new Colaboradores { Id = 8, Nome = "Marco Rocha", DataNasc = new DateTime(1993, 1, 30), Cargo = "Técnico", Departamento = "Informática", Email = "MarcoRocha@empresa.com", Contacto = "9111111118", Foto = "MarcoRocha.jpg" }
            );


            builder.Entity<Projetos>().HasData(
                new Projetos { Id = 1, Nome = "WebSite Comercial", Descricao = "Realização de um WebSite aberto ao público para divulgação e venda dos seus produtos.", DataCriacao = new DateTime(2021, 6, 18), DataPrevista = new DateTime(2022, 6, 18), DataInicio = new DateTime(2022, 6, 29), ClienteFK = 1, CriadorFK = 1 },
                new Projetos { Id = 2, Nome = "App mobile Comercial", Descricao = "Realização de uma aplicação para Android e IOS para divuldagação e venda dos produtos do cliente.", DataCriacao = new DateTime(2021, 5, 18), DataPrevista = new DateTime(2022, 4, 1), DataInicio = new DateTime(2022, 6, 2), ClienteFK = 1, CriadorFK = 2 },
                new Projetos { Id = 3, Nome = "Jogo Mobile", Descricao = "Realização de um Jogo para Android para promoção dos produtos XPTO do cliente.", DataCriacao = new DateTime(2020, 1, 1), DataPrevista = new DateTime(2020, 9, 1), DataInicio = new DateTime(2020, 1, 8), DataFim = new DateTime(2020, 8, 1), ClienteFK = 2, CriadorFK = 3 },
                new Projetos { Id = 4, Nome = "XPTOshop", Descricao = "Realização de um WebSite para venda de produtos para todo o mundo.", DataCriacao = new DateTime(2020, 2, 20), DataPrevista = new DateTime(2020, 12, 1), DataInicio = new DateTime(2020, 2, 22), ClienteFK = 2, DataFim = new DateTime(2021, 1, 8), CriadorFK = 2 },
                new Projetos { Id = 5, Nome = "Programa De Gestão de Rega", Descricao = "Realização de um programa para gerir sistema de rega.", DataCriacao = new DateTime(2021, 6, 18), DataPrevista = new DateTime(2022, 7, 18), DataInicio = new DateTime(2022, 6, 18), ClienteFK = 1, CriadorFK = 4 }
            );

            builder.Entity<Tarefas>().HasData(
                // Estado de conclusão do projeto. Pendente, em curso, por testar, concluido, aguarda ação externa, cancelado.
                new Tarefas { Id = 1, Titulo = "Front-end", Descricao = "Criar um front-end para apresentar ao cliente", DataCriacao = new DateTime(2021, 6, 18), DataLimite = new DateTime(2022, 6, 18), Estado = "Pendente", Prioridade = "baixa", ProjetoFK = 1, ColaboradorFK = 1 , TempoDedicadoTimeSpan = new TimeSpan(1,8,0,0)},
                new Tarefas { Id = 2, Titulo = "Base de Dados", Descricao = "Concretizar o modelo acordado com o cliente", DataCriacao = new DateTime(2021, 6, 18), DataLimite = new DateTime(2022, 6, 18), Estado = "Pendente", Prioridade = "baixa", ProjetoFK = 1, ColaboradorFK = 1, TempoDedicadoTimeSpan = new TimeSpan(1, 8, 0, 0) },
                new Tarefas { Id = 3, Titulo = "Testes Unitários", Descricao = "Preparar testes unitários para as funções desenvolvidas em back-end", DataCriacao = new DateTime(2021, 6, 18), DataLimite = new DateTime(2021, 6, 18), Estado = "Pendente", Prioridade = "media", ProjetoFK = 1, ColaboradorFK = 1, TempoDedicadoTimeSpan = new TimeSpan(1, 8, 0, 0) },

                new Tarefas { Id = 4, Titulo = "API", Descricao = "Desenvolver a api para ser consumida por ambas as apps mobile", DataCriacao = new DateTime(2021, 5, 18), DataLimite = new DateTime(2022, 1, 1), Estado = "Pendente", Prioridade = "media", ProjetoFK = 2, ColaboradorFK = 2, TempoDedicadoTimeSpan = new TimeSpan(1, 8, 0, 0) },
                new Tarefas { Id = 5, Titulo = "App Android", Descricao = "Desenvolver a aplicação para dispositivos Android", DataCriacao = new DateTime(2021, 5, 18), DataLimite = new DateTime(2022, 4, 1), Estado = "Pendente", Prioridade = "baixa", ProjetoFK = 2, ColaboradorFK = 2, TempoDedicadoTimeSpan = new TimeSpan(1, 8, 0, 0) },
                new Tarefas { Id = 6, Titulo = "App IOS", Descricao = "Desenvolver a aplicação para dispositivos IOS", DataCriacao = new DateTime(2021, 5, 18), DataLimite = new DateTime(2022, 4, 1), Estado = "Pendente", Prioridade = "baixa", ProjetoFK = 2, ColaboradorFK = 2 , TempoDedicadoTimeSpan = new TimeSpan(1, 8, 0, 0) },

                new Tarefas { Id = 7, Titulo = "Banda Sonora", Descricao = "Criar uma banda sonora para o jogo", DataCriacao = new DateTime(2020, 1, 1), DataLimite = new DateTime(2020, 9, 1), Estado = "concluido", Prioridade = "alta", ProjetoFK = 3, ColaboradorFK = 3 , TempoDedicadoTimeSpan = new TimeSpan(1, 8, 0, 0) },
                new Tarefas { Id = 8, Titulo = "Art Assets", Descricao = "Desenvolver os assets necessários para os personagens", DataCriacao = new DateTime(2020, 1, 1), DataLimite = new DateTime(2020, 9, 1), Estado = "concluido", Prioridade = "media", ProjetoFK = 3, ColaboradorFK = 3 , TempoDedicadoTimeSpan = new TimeSpan(1, 8, 0, 0) },
                new Tarefas { Id = 9, Titulo = "Jogabilidade", Descricao = "Melhorar mecanismos relacionados com a jogabilidade", DataCriacao = new DateTime(2020, 1, 1), DataLimite = new DateTime(2020, 9, 1), Estado = "concluido", Prioridade = "baixa", ProjetoFK = 3, ColaboradorFK = 3 , TempoDedicadoTimeSpan = new TimeSpan(1, 8, 0, 0) },
                new Tarefas { Id = 10, Titulo = "História", Descricao = "Alterar último capítulo", DataCriacao = new DateTime(2020, 1, 1), DataLimite = new DateTime(2020, 9, 1), Estado = "concluido", Prioridade = "baixa", ProjetoFK = 3, ColaboradorFK = 3, TempoDedicadoTimeSpan = new TimeSpan(1, 8, 0, 0) },

                new Tarefas { Id = 11, Titulo = "BD", Descricao = "Concretizar a base de dados", DataCriacao = new DateTime(2020, 2, 20), DataLimite = new DateTime(2020, 4, 20), Estado = "concluido", Prioridade = "alta", ProjetoFK = 4, ColaboradorFK = 2, TempoDedicadoTimeSpan = new TimeSpan(1, 8, 0, 0) },
                new Tarefas { Id = 12, Titulo = "Front-end", Descricao = "Elaborar um mock-up do front-end para apresentar ao cliente", DataCriacao = new DateTime(2020, 4, 21), DataLimite = new DateTime(2020, 5, 22), Estado = "concluido", Prioridade = "alta", ProjetoFK = 4, ColaboradorFK = 2, TempoDedicadoTimeSpan = new TimeSpan(1, 8, 0, 0) },

                new Tarefas { Id = 13, Titulo = "Api com previsão de tempo", Descricao = "Encontrar uma API que permite obter previsões do tempo", DataCriacao = new DateTime(2021, 6, 18), DataLimite = new DateTime(2022, 7, 18), Estado = "Pendente", Prioridade = "baixa", ProjetoFK = 5, ColaboradorFK = 4, TempoDedicadoTimeSpan = new TimeSpan(1, 8, 0, 0) },
                new Tarefas { Id = 14, Titulo = "Testar regadores IOT", Descricao = "Testar o funcionamento dos regadores adquiridos", DataCriacao = new DateTime(2021, 6, 18), DataLimite = new DateTime(2022, 7, 18), Estado = "Pendente", Prioridade = "baixa", ProjetoFK = 5, ColaboradorFK = 4, TempoDedicadoTimeSpan = new TimeSpan(1, 8, 0, 0) }
            );

            // Tarefas colaboradores


        }


        // Tabelas da base de dados
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Colaboradores> Colaboradores { get; set; }
        public DbSet<Projetos> Projetos { get; set; }
        public DbSet<Tarefas> Tarefas { get; set; }
        public DbSet<TarefasColaboradores> TarefasColaboradores { get; set; }


    }
}
