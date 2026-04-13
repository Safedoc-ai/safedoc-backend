using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SafeDocAI.API.Migrations
{
    /// <inheritdoc />
    public partial class Semana2Ajustes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativa",
                table: "Unidades",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Unidades",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Unidades",
                type: "TEXT",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Documentos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEmissao",
                table: "Documentos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_UnidadeId",
                table: "Documentos",
                column: "UnidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documentos_Unidades_UnidadeId",
                table: "Documentos",
                column: "UnidadeId",
                principalTable: "Unidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documentos_Unidades_UnidadeId",
                table: "Documentos");

            migrationBuilder.DropIndex(
                name: "IX_Documentos_UnidadeId",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "Ativa",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "DataEmissao",
                table: "Documentos");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Documentos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
