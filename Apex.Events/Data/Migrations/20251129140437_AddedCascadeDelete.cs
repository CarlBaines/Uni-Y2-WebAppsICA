using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apex.Events.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestBookings_Events_EventId",
                table: "GuestBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestBookings_Guests_GuestId",
                table: "GuestBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffings_Events_EventId",
                table: "Staffings");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffings_Staff_EventStaffId",
                table: "Staffings");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestBookings_Events_EventId",
                table: "GuestBookings",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestBookings_Guests_GuestId",
                table: "GuestBookings",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "GuestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffings_Events_EventId",
                table: "Staffings",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffings_Staff_EventStaffId",
                table: "Staffings",
                column: "EventStaffId",
                principalTable: "Staff",
                principalColumn: "EventStaffId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestBookings_Events_EventId",
                table: "GuestBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestBookings_Guests_GuestId",
                table: "GuestBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffings_Events_EventId",
                table: "Staffings");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffings_Staff_EventStaffId",
                table: "Staffings");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestBookings_Events_EventId",
                table: "GuestBookings",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestBookings_Guests_GuestId",
                table: "GuestBookings",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "GuestId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffings_Events_EventId",
                table: "Staffings",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffings_Staff_EventStaffId",
                table: "Staffings",
                column: "EventStaffId",
                principalTable: "Staff",
                principalColumn: "EventStaffId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
