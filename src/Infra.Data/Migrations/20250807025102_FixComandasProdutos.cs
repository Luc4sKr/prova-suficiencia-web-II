using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixComandasProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ComandasProdutos_ComandaId",
                table: "ComandasProdutos");

            migrationBuilder.CreateIndex(
                name: "IX_ComandasProdutos_ComandaId",
                table: "ComandasProdutos",
                column: "ComandaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ComandasProdutos_ComandaId",
                table: "ComandasProdutos");

            migrationBuilder.CreateIndex(
                name: "IX_ComandasProdutos_ComandaId",
                table: "ComandasProdutos",
                column: "ComandaId",
                unique: true);
        }
    }
}
