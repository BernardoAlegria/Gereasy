using Microsoft.EntityFrameworkCore.Migrations;

namespace Gereasy.Data.Migrations
{
    public partial class NomeDepartamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: 1,
                column: "Departamento",
                value: "gestao");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: 2,
                column: "Departamento",
                value: "gestao");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: 3,
                column: "Departamento",
                value: "gestao");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: 4,
                column: "Departamento",
                value: "gestao");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: 5,
                column: "Departamento",
                value: "informatica");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: 6,
                column: "Departamento",
                value: "informatica");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: 7,
                column: "Departamento",
                value: "informatica");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: 8,
                column: "Departamento",
                value: "informatica");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: 1,
                column: "Departamento",
                value: "Gestão");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: 2,
                column: "Departamento",
                value: "Administração");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: 3,
                column: "Departamento",
                value: "Gestão");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: 4,
                column: "Departamento",
                value: "Gestão");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: 5,
                column: "Departamento",
                value: "Informática");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: 6,
                column: "Departamento",
                value: "Informática");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: 7,
                column: "Departamento",
                value: "Informática");

            migrationBuilder.UpdateData(
                table: "Colaboradores",
                keyColumn: "Id",
                keyValue: 8,
                column: "Departamento",
                value: "Informática");
        }
    }
}
