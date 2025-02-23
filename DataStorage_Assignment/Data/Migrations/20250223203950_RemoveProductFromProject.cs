using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveProductFromProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Products_ProductId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProductId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "ProductEntityId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProductEntityId",
                table: "Projects",
                column: "ProductEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Products_ProductEntityId",
                table: "Projects",
                column: "ProductEntityId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Products_ProductEntityId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProductEntityId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProductEntityId",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProductId",
                table: "Projects",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Products_ProductId",
                table: "Projects",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
