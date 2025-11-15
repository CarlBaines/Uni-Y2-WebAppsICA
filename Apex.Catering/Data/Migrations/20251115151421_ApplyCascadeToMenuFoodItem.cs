using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apex.Catering.Data.Migrations
{
    /// <inheritdoc />
    public partial class ApplyCascadeToMenuFoodItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuFoodItems_FoodItems_FoodItemId",
                table: "MenuFoodItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuFoodItems_Menus_MenuId",
                table: "MenuFoodItems");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuFoodItems_FoodItems_FoodItemId",
                table: "MenuFoodItems",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "FoodItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuFoodItems_Menus_MenuId",
                table: "MenuFoodItems",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuFoodItems_FoodItems_FoodItemId",
                table: "MenuFoodItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuFoodItems_Menus_MenuId",
                table: "MenuFoodItems");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuFoodItems_FoodItems_FoodItemId",
                table: "MenuFoodItems",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "FoodItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuFoodItems_Menus_MenuId",
                table: "MenuFoodItems",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
