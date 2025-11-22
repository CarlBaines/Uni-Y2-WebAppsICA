using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Apex.Events.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOldHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GuestBookings",
                keyColumn: "GuestBookingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GuestBookings",
                keyColumn: "GuestBookingId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GuestBookings",
                keyColumn: "GuestBookingId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Staffings",
                keyColumn: "StaffingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staffings",
                keyColumn: "StaffingId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "GuestId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "GuestId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "GuestId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "EventStaffId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "EventStaffId",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "EventName" },
                values: new object[,]
                {
                    { 1, "Annual Conference" },
                    { 2, "Networking Gala" }
                });

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "GuestId", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "", "Alice", "Johnson" },
                    { 2, "", "Bob", "Smith" },
                    { 3, "", "Charlie", "Brown" }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "EventStaffId", "FirstName", "LastName", "Role" },
                values: new object[,]
                {
                    { 1, "David", "Wilson", "Coordinator" },
                    { 2, "Eva", "Davis", "Assistant" }
                });

            migrationBuilder.InsertData(
                table: "GuestBookings",
                columns: new[] { "GuestBookingId", "EventId", "GuestId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Staffings",
                columns: new[] { "StaffingId", "EventId", "EventStaffId", "StaffingName" },
                values: new object[,]
                {
                    { 1, 1, 1, "Conference Coordination" },
                    { 2, 2, 2, "Gala Assistance" }
                });
        }
    }
}
