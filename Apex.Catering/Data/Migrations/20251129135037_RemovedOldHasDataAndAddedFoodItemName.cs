using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Apex.Catering.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedOldHasDataAndAddedFoodItemName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FoodBookings",
                keyColumn: "FoodBookingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FoodBookings",
                keyColumn: "FoodBookingId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FoodBookings",
                keyColumn: "FoodBookingId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "FoodItemId", "MenuId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "FoodItemId", "MenuId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "FoodItemId", "MenuId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "FoodItems",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "FoodItems");

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "UnitPrice" },
                values: new object[,]
                {
                    { 1, "Chicken Sandwich", 5.9900000000000002 },
                    { 2, "Veggie Wrap", 4.9900000000000002 },
                    { 3, "Caesar Salad", 3.9900000000000002 }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "MenuName" },
                values: new object[,]
                {
                    { 1, "Conference Menu" },
                    { 2, "Party Menu" },
                    { 3, "Wedding Menu" }
                });

            migrationBuilder.InsertData(
                table: "FoodBookings",
                columns: new[] { "FoodBookingId", "ClientReferenceId", "EventId", "MenuId", "NumberOfGuests" },
                values: new object[,]
                {
                    { 1, 1001, 0, 1, 50 },
                    { 2, 1002, 0, 2, 100 },
                    { 3, 1003, 0, 3, 200 }
                });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 1, 2 },
                    { 2, 2 }
                });
        }
    }
}
