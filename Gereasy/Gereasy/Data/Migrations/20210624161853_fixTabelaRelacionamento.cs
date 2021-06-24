using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gereasy.Data.Migrations
{
    public partial class fixTabelaRelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    DataNasc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contacto = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contacto = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ColaboradoresId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Colaboradores_ColaboradoresId",
                        column: x => x.ColaboradoresId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPrevista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteFK = table.Column<int>(type: "int", nullable: false),
                    CriadorFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projetos_Clientes_ClienteFK",
                        column: x => x.ClienteFK,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projetos_Colaboradores_CriadorFK",
                        column: x => x.CriadorFK,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataLimite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prioridade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempoDedicadoTotal = table.Column<long>(type: "bigint", nullable: false),
                    ProjetoFK = table.Column<int>(type: "int", nullable: true),
                    ColaboradorFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarefas_Colaboradores_ColaboradorFK",
                        column: x => x.ColaboradorFK,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarefas_Projetos_ProjetoFK",
                        column: x => x.ProjetoFK,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TarefasColaboradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Funcao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempoDedicado = table.Column<long>(type: "bigint", nullable: false),
                    ColaboradorFK = table.Column<int>(type: "int", nullable: false),
                    TarefaFK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarefasColaboradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TarefasColaboradores_Colaboradores_ColaboradorFK",
                        column: x => x.ColaboradorFK,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TarefasColaboradores_Tarefas_TarefaFK",
                        column: x => x.TarefaFK,
                        principalTable: "Tarefas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "ColaboradoresId", "Contacto", "Descricao", "Email", "Nome" },
                values: new object[,]
                {
                    { 1, null, "926926926", "Empresa de Suplementos alimentares e produtos cosméticos", "biovip@biovip.pt", "BioVip" },
                    { 2, null, "912912912", "Empresa produtora de produtos XPTO", "xpto@xpto.pt", "XPTO" },
                    { 3, null, "903903903", "American Company Makes Everything. Empresa conhecida, em particular, pelo seu patrocínio a Coiote, na sua caça pelo Bip-Bip", "acme@acme.com", "ACME" }
                });

            migrationBuilder.InsertData(
                table: "Colaboradores",
                columns: new[] { "Id", "Cargo", "Contacto", "DataNasc", "Departamento", "Email", "Foto", "Nome" },
                values: new object[,]
                {
                    { 1, "gestor", "9111111111", new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gestão", "PatriciaContente@empresa.com", "PatriciaContente.jpg", "Patrícia Contente" },
                    { 2, "gestor", "9111111112", new DateTime(1994, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administração", "BeatrizBonito@empresa.com", "BeatrizBonito.jpg", "Beatriz Bonito" },
                    { 3, "gestor", "9111111113", new DateTime(1996, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gestão", "PauloPereira@empresa.com", "PauloPereira.jpg", "Paulo Pereira" },
                    { 4, "gestor", "9111111114", new DateTime(1995, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gestão", "VadimsZinatulins@empresa.com", "VadimsZinatulins.jpg", "Vadims Zinatulins" },
                    { 5, "tecnico", "9111111115", new DateTime(1996, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Informática", "ZeMaria@empresa.com", "ZeMaria.jpg", "Zé Maria" },
                    { 6, "tecnico", "9111111116", new DateTime(1996, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Informática", "Marisa Vieira@empresa.com", "MarisaVieira.jpg", "Marisa Vieira" },
                    { 7, "tecnico", "9111111117", new DateTime(1992, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Informática", "PaulaSilva@empresa.com", "PaulaSilva.jpg", "Paula Silva" },
                    { 8, "tecnico", "9111111118", new DateTime(1993, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Informática", "MarcoRocha@empresa.com", "MarcoRocha.jpg", "Marco Rocha" }
                });

            migrationBuilder.InsertData(
                table: "Projetos",
                columns: new[] { "Id", "ClienteFK", "CriadorFK", "DataCriacao", "DataFim", "DataInicio", "DataPrevista", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Realização de um WebSite aberto ao público para divulgação e venda dos seus produtos.", "WebSite Comercial" },
                    { 2, 1, 2, new DateTime(2021, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Realização de uma aplicação para Android e IOS para divuldagação e venda dos produtos do cliente.", "App mobile Comercial" },
                    { 4, 2, 2, new DateTime(2020, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Realização de um WebSite para venda de produtos para todo o mundo.", "XPTOshop" },
                    { 3, 2, 3, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Realização de um Jogo para Android para promoção dos produtos XPTO do cliente.", "Jogo Mobile" },
                    { 5, 1, 4, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Realização de um programa para gerir sistema de rega.", "Programa De Gestão de Rega" }
                });

            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "Id", "ColaboradorFK", "DataCriacao", "DataLimite", "Descricao", "Estado", "Prioridade", "ProjetoFK", "TempoDedicadoTotal", "Titulo" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Criar um front-end para apresentar ao cliente", "Pendente", "baixa", 1, 1152000000000L, "Front-end" },
                    { 2, 1, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Concretizar o modelo acordado com o cliente", "Pendente", "baixa", 1, 1152000000000L, "Base de Dados" },
                    { 3, 1, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Preparar testes unitários para as funções desenvolvidas em back-end", "Pendente", "media", 1, 1152000000000L, "Testes Unitários" },
                    { 4, 2, new DateTime(2021, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desenvolver a api para ser consumida por ambas as apps mobile", "Pendente", "media", 2, 1152000000000L, "API" },
                    { 5, 2, new DateTime(2021, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desenvolver a aplicação para dispositivos Android", "Pendente", "baixa", 2, 1152000000000L, "App Android" },
                    { 6, 2, new DateTime(2021, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desenvolver a aplicação para dispositivos IOS", "Pendente", "baixa", 2, 1152000000000L, "App IOS" },
                    { 11, 2, new DateTime(2020, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Concretizar a base de dados", "concluido", "alta", 4, 1152000000000L, "BD" },
                    { 12, 2, new DateTime(2020, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elaborar um mock-up do front-end para apresentar ao cliente", "concluido", "alta", 4, 1152000000000L, "Front-end" },
                    { 7, 3, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Criar uma banda sonora para o jogo", "concluido", "alta", 3, 1152000000000L, "Banda Sonora" },
                    { 8, 3, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desenvolver os assets necessários para os personagens", "concluido", "media", 3, 1152000000000L, "Art Assets" },
                    { 9, 3, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Melhorar mecanismos relacionados com a jogabilidade", "concluido", "baixa", 3, 1152000000000L, "Jogabilidade" },
                    { 10, 3, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alterar último capítulo", "concluido", "baixa", 3, 1152000000000L, "História" },
                    { 13, 4, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Encontrar uma API que permite obter previsões do tempo", "Pendente", "baixa", 5, 1152000000000L, "Api com previsão de tempo" },
                    { 14, 4, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Testar o funcionamento dos regadores adquiridos", "Pendente", "baixa", 5, 1152000000000L, "Testar regadores IOT" }
                });

            migrationBuilder.InsertData(
                table: "TarefasColaboradores",
                columns: new[] { "Id", "ColaboradorFK", "Funcao", "TarefaFK", "TempoDedicado" },
                values: new object[,]
                {
                    { 1, 5, "implementador", 1, 1152000000000L },
                    { 2, 1, "revisor", 1, 0L },
                    { 3, 5, "implementador", 2, 1152000000000L },
                    { 4, 6, "revisor", 2, 0L },
                    { 5, 5, "implementador", 3, 864000000000L },
                    { 6, 6, "implementador", 3, 288000000000L },
                    { 7, 1, "revisor", 3, 0L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ColaboradoresId",
                table: "Clientes",
                column: "ColaboradoresId");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_ClienteFK",
                table: "Projetos",
                column: "ClienteFK");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_CriadorFK",
                table: "Projetos",
                column: "CriadorFK");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ColaboradorFK",
                table: "Tarefas",
                column: "ColaboradorFK");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ProjetoFK",
                table: "Tarefas",
                column: "ProjetoFK");

            migrationBuilder.CreateIndex(
                name: "IX_TarefasColaboradores_ColaboradorFK",
                table: "TarefasColaboradores",
                column: "ColaboradorFK");

            migrationBuilder.CreateIndex(
                name: "IX_TarefasColaboradores_TarefaFK",
                table: "TarefasColaboradores",
                column: "TarefaFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TarefasColaboradores");

            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.DropTable(
                name: "Projetos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Colaboradores");
        }
    }
}
