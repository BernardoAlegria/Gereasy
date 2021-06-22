using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gereasy.Data.Migrations
{
    public partial class FixDataPrevista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPrevista",
                table: "Projetos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "ColaboradoresId", "Contacto", "Descricao", "Email", "Nome" },
                values: new object[] { 1, null, "926926926", "Empresa de Suplementos alimentares e produtos cosméticos", "biovip@biovip.pt", "BioVip" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "ColaboradoresId", "Contacto", "Descricao", "Email", "Nome" },
                values: new object[] { 2, null, "912912912", "Empresa produtora de produtos XPTO", "xpto@xpto.pt", "XPTO" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "ColaboradoresId", "Contacto", "Descricao", "Email", "Nome" },
                values: new object[] { 3, null, "903903903", "American Company Makes Everything. Empresa conhecida, em particular, pelo seu patrocínio a Coiote, na sua caça pelo Bip-Bip", "acme@acme.com", "ACME" });

            migrationBuilder.InsertData(
                table: "Projetos",
                columns: new[] { "Id", "ClienteFK", "CriadorFK", "DataCriacao", "DataFim", "DataInicio", "DataPrevista", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, 1, 999999999, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Realização de um WebSite aberto ao público para divulgação e venda dos seus produtos.", "WebSite Comercial" },
                    { 2, 1, 999999999, new DateTime(2021, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Realização de uma aplicação para Android e IOS para divuldagação e venda dos produtos do cliente.", "App mobile Comercial" },
                    { 5, 1, 999999999, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Realização de um programa para gerir sistema de rega.", "Programa De Gestão de Rega" },
                    { 3, 2, 999999999, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Realização de um Jogo para Android para promoção dos produtos XPTO do cliente.", "Jogo Mobile" },
                    { 4, 2, 999999999, new DateTime(2020, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Realização de um WebSite para venda de produtos para todo o mundo.", "XPTOshop" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projetos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projetos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projetos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projetos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projetos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "DataPrevista",
                table: "Projetos",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
