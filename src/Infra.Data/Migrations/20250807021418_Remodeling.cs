using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Remodeling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comandas_Users_UserId",
                table: "Comandas");

            migrationBuilder.DropIndex(
                name: "IX_Comandas_UserId",
                table: "Comandas");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comandas",
                newName: "IdUsuario");

            migrationBuilder.AddColumn<string>(
                name: "NomeUsuario",
                table: "Comandas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TelefoneUsuario",
                table: "Comandas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeUsuario",
                table: "Comandas");

            migrationBuilder.DropColumn(
                name: "TelefoneUsuario",
                table: "Comandas");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Comandas",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Comandas_UserId",
                table: "Comandas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comandas_Users_UserId",
                table: "Comandas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
