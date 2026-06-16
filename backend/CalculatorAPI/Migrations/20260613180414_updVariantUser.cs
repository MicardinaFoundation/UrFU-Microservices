using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalculatorAPI.Migrations
{
    /// <inheritdoc />
    public partial class updVariantUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VariantUsers_Variants_VariantId",
                table: "VariantUsers");

            migrationBuilder.DropIndex(
                name: "IX_VariantUsers_VariantId",
                table: "VariantUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VariantUsers_VariantId",
                table: "VariantUsers",
                column: "VariantId");

            migrationBuilder.AddForeignKey(
                name: "FK_VariantUsers_Variants_VariantId",
                table: "VariantUsers",
                column: "VariantId",
                principalTable: "Variants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
