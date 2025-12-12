using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apex.Events.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedVenueCodeToEventClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VenueId",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "VenueCode",
                table: "Events",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VenueCode",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "VenueId",
                table: "Events",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
