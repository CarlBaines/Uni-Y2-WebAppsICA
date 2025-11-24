using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apex.Events.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEventDatePlusType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "EventDate",
                table: "Events",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "EventType",
                table: "Events",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventDate",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventType",
                table: "Events");
        }
    }
}
