using Microsoft.EntityFrameworkCore.Migrations;

namespace asp_assignment.Migrations
{
    public partial class CartItemCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Souvenir_SouvenirID",
                table: "CartItem");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Souvenir_SouvenirID",
                table: "CartItem",
                column: "SouvenirID",
                principalTable: "Souvenir",
                principalColumn: "SouvenirID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Souvenir_SouvenirID",
                table: "CartItem");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Souvenir_SouvenirID",
                table: "CartItem",
                column: "SouvenirID",
                principalTable: "Souvenir",
                principalColumn: "SouvenirID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
