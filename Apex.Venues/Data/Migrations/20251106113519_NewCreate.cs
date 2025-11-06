using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Apex.Venues.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[,]
                {
                    { new DateTime(2026, 1, 6, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK", 51.789999999999999 },
                    { new DateTime(2026, 1, 11, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK", 46.770000000000003 },
                    { new DateTime(2026, 1, 11, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR", 72.069999999999993 },
                    { new DateTime(2026, 1, 12, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 91.030000000000001 },
                    { new DateTime(2026, 1, 12, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK", 57.18 },
                    { new DateTime(2026, 1, 13, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 61.130000000000003 },
                    { new DateTime(2026, 1, 14, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR", 139.55000000000001 },
                    { new DateTime(2026, 1, 19, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 96.379999999999995 },
                    { new DateTime(2026, 1, 21, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR", 92.689999999999998 },
                    { new DateTime(2026, 1, 23, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 95.010000000000005 },
                    { new DateTime(2026, 1, 23, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK", 59.859999999999999 },
                    { new DateTime(2026, 1, 26, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 57.450000000000003 },
                    { new DateTime(2026, 1, 27, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK", 55.439999999999998 },
                    { new DateTime(2026, 1, 27, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR", 79.260000000000005 },
                    { new DateTime(2026, 1, 28, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 80.489999999999995 },
                    { new DateTime(2026, 1, 29, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 97.650000000000006 },
                    { new DateTime(2026, 1, 31, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 57.399999999999999 },
                    { new DateTime(2026, 2, 1, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK", 58.020000000000003 },
                    { new DateTime(2026, 2, 2, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 78.489999999999995 },
                    { new DateTime(2026, 2, 2, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK", 50.630000000000003 },
                    { new DateTime(2026, 2, 3, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR", 94.670000000000002 },
                    { new DateTime(2026, 2, 4, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK", 32.43 },
                    { new DateTime(2026, 2, 6, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 68.049999999999997 },
                    { new DateTime(2026, 2, 7, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 92.519999999999996 },
                    { new DateTime(2026, 2, 8, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 53.119999999999997 },
                    { new DateTime(2026, 2, 9, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK", 49.280000000000001 },
                    { new DateTime(2026, 2, 9, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR", 104.76000000000001 },
                    { new DateTime(2026, 2, 11, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK", 30.91 },
                    { new DateTime(2026, 2, 12, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 99.439999999999998 },
                    { new DateTime(2026, 2, 13, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 69.359999999999999 },
                    { new DateTime(2026, 2, 14, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 76.140000000000001 },
                    { new DateTime(2026, 2, 15, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 64.019999999999996 },
                    { new DateTime(2026, 2, 16, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK", 51.479999999999997 },
                    { new DateTime(2026, 2, 16, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR", 112.88 },
                    { new DateTime(2026, 2, 17, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR", 109.15000000000001 },
                    { new DateTime(2026, 2, 18, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR", 115.89 },
                    { new DateTime(2026, 2, 19, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 64.030000000000001 },
                    { new DateTime(2026, 2, 20, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK", 53.840000000000003 },
                    { new DateTime(2026, 2, 21, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 92.319999999999993 },
                    { new DateTime(2026, 2, 21, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK", 40.109999999999999 },
                    { new DateTime(2026, 2, 21, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR", 76.810000000000002 },
                    { new DateTime(2026, 2, 22, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 80.659999999999997 },
                    { new DateTime(2026, 2, 22, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK", 43.719999999999999 },
                    { new DateTime(2026, 2, 25, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK", 42.299999999999997 },
                    { new DateTime(2026, 2, 26, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK", 51.560000000000002 },
                    { new DateTime(2026, 2, 26, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR", 87.870000000000005 },
                    { new DateTime(2026, 2, 27, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK", 48.590000000000003 },
                    { new DateTime(2026, 2, 28, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 84.980000000000004 },
                    { new DateTime(2026, 3, 1, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 80.769999999999996 },
                    { new DateTime(2026, 3, 1, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK", 35.850000000000001 },
                    { new DateTime(2026, 3, 1, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR", 83.709999999999994 },
                    { new DateTime(2026, 3, 2, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 91.530000000000001 },
                    { new DateTime(2026, 3, 2, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR", 132.13 },
                    { new DateTime(2026, 3, 3, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR", 104.41 },
                    { new DateTime(2026, 3, 4, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR", 114.65000000000001 },
                    { new DateTime(2026, 3, 6, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK", 50.390000000000001 },
                    { new DateTime(2026, 3, 6, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR", 95.829999999999998 },
                    { new DateTime(2026, 3, 8, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 62.539999999999999 },
                    { new DateTime(2026, 3, 10, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 78.430000000000007 },
                    { new DateTime(2026, 3, 18, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR", 77.700000000000003 },
                    { new DateTime(2026, 3, 22, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK", 33.030000000000001 },
                    { new DateTime(2026, 3, 23, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR", 110.11 },
                    { new DateTime(2026, 3, 24, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 77.640000000000001 },
                    { new DateTime(2026, 3, 26, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR", 130.16999999999999 },
                    { new DateTime(2026, 3, 27, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK", 35.670000000000002 },
                    { new DateTime(2026, 3, 27, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR", 101.31999999999999 },
                    { new DateTime(2026, 3, 28, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 53.219999999999999 },
                    { new DateTime(2026, 3, 30, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 74.150000000000006 },
                    { new DateTime(2026, 3, 30, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR", 102.22 },
                    { new DateTime(2026, 4, 1, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK", 44.049999999999997 },
                    { new DateTime(2026, 4, 2, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR", 99.879999999999995 },
                    { new DateTime(2026, 4, 3, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR", 115.3 },
                    { new DateTime(2026, 4, 4, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL", 72.340000000000003 },
                    { new DateTime(2026, 4, 4, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK", 53.810000000000002 },
                    { new DateTime(2026, 4, 5, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK", 52.939999999999998 },
                    { new DateTime(2026, 4, 5, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR", 112.63 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 6, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 11, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 11, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 12, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 12, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 13, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 14, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 19, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 21, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 23, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 23, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 26, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 27, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 27, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 28, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 29, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 1, 31, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 1, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 2, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 2, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 3, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 4, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 6, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 7, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 8, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 9, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 9, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 11, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 12, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 13, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 14, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 15, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 16, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 16, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 17, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 18, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 19, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 20, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 21, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 21, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 21, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 22, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 22, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 25, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 26, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 26, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 27, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 2, 28, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 1, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 1, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 1, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 2, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 2, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 3, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 4, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 6, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 6, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 8, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 10, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 18, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 22, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 23, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 24, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 26, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 27, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 27, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 28, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 30, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 3, 30, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 4, 1, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 4, 2, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 4, 3, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 4, 4, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 4, 4, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 4, 5, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2026, 4, 5, 11, 35, 17, 910, DateTimeKind.Local).AddTicks(6072), "TNDMR" });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[,]
                {
                    { new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 51.789999999999999 },
                    { new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 46.770000000000003 },
                    { new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 72.069999999999993 },
                    { new DateTime(2026, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 91.030000000000001 },
                    { new DateTime(2026, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 57.18 },
                    { new DateTime(2026, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 61.130000000000003 },
                    { new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 139.55000000000001 },
                    { new DateTime(2026, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 96.379999999999995 },
                    { new DateTime(2026, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 92.689999999999998 },
                    { new DateTime(2026, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 95.010000000000005 },
                    { new DateTime(2026, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 59.859999999999999 },
                    { new DateTime(2026, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 57.450000000000003 },
                    { new DateTime(2026, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 55.439999999999998 },
                    { new DateTime(2026, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 79.260000000000005 },
                    { new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 80.489999999999995 },
                    { new DateTime(2026, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 97.650000000000006 },
                    { new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 57.399999999999999 },
                    { new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 58.020000000000003 },
                    { new DateTime(2026, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 78.489999999999995 },
                    { new DateTime(2026, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 50.630000000000003 },
                    { new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 94.670000000000002 },
                    { new DateTime(2026, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 32.43 },
                    { new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 68.049999999999997 },
                    { new DateTime(2026, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 92.519999999999996 },
                    { new DateTime(2026, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 53.119999999999997 },
                    { new DateTime(2026, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 49.280000000000001 },
                    { new DateTime(2026, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 104.76000000000001 },
                    { new DateTime(2026, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 30.91 },
                    { new DateTime(2026, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 99.439999999999998 },
                    { new DateTime(2026, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 69.359999999999999 },
                    { new DateTime(2026, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 76.140000000000001 },
                    { new DateTime(2026, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 64.019999999999996 },
                    { new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 51.479999999999997 },
                    { new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 112.88 },
                    { new DateTime(2026, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 109.15000000000001 },
                    { new DateTime(2026, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 115.89 },
                    { new DateTime(2026, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 64.030000000000001 },
                    { new DateTime(2026, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 53.840000000000003 },
                    { new DateTime(2026, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 92.319999999999993 },
                    { new DateTime(2026, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 40.109999999999999 },
                    { new DateTime(2026, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 76.810000000000002 },
                    { new DateTime(2026, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 80.659999999999997 },
                    { new DateTime(2026, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 43.719999999999999 },
                    { new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 42.299999999999997 },
                    { new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 51.560000000000002 },
                    { new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 87.870000000000005 },
                    { new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 48.590000000000003 },
                    { new DateTime(2026, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 84.980000000000004 },
                    { new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 80.769999999999996 },
                    { new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 35.850000000000001 },
                    { new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 83.709999999999994 },
                    { new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 91.530000000000001 },
                    { new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 132.13 },
                    { new DateTime(2026, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 104.41 },
                    { new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 114.65000000000001 },
                    { new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 50.390000000000001 },
                    { new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 95.829999999999998 },
                    { new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 62.539999999999999 },
                    { new DateTime(2026, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 78.430000000000007 },
                    { new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 77.700000000000003 },
                    { new DateTime(2026, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 33.030000000000001 },
                    { new DateTime(2026, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 110.11 },
                    { new DateTime(2026, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 77.640000000000001 },
                    { new DateTime(2026, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 130.16999999999999 },
                    { new DateTime(2026, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 35.670000000000002 },
                    { new DateTime(2026, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 101.31999999999999 },
                    { new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 53.219999999999999 },
                    { new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 74.150000000000006 },
                    { new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 102.22 },
                    { new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 44.049999999999997 },
                    { new DateTime(2026, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 99.879999999999995 },
                    { new DateTime(2026, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 115.3 },
                    { new DateTime(2026, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 72.340000000000003 },
                    { new DateTime(2026, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 53.810000000000002 },
                    { new DateTime(2026, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 52.939999999999998 },
                    { new DateTime(2026, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 112.63 }
                });
        }
    }
}
