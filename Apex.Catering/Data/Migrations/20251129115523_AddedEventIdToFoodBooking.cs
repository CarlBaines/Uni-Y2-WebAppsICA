using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apex.Catering.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedEventIdToFoodBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "FoodBookings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "FoodBookings",
                keyColumn: "FoodBookingId",
                keyValue: 1,
                column: "EventId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "FoodBookings",
                keyColumn: "FoodBookingId",
                keyValue: 2,
                column: "EventId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "FoodBookings",
                keyColumn: "FoodBookingId",
                keyValue: 3,
                column: "EventId",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventId",
                table: "FoodBookings");
        }
    }
}
