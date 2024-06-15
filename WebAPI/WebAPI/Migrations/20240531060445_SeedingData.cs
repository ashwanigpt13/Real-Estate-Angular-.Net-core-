using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Country", "LastUpdatedBy", "LastUpdatedOn", "Name" },
                values: new object[,]
                {
                    { 1, "USA", 1, new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(8988), "New York" },
                    { 2, "USA", 1, new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(8991), "Houston" },
                    { 3, "USA", 1, new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(8993), "Los Angeles" },
                    { 4, "India", 1, new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(8995), "New Delhi" },
                    { 5, "India", 1, new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(8997), "Bangalore" }
                });

            migrationBuilder.InsertData(
                table: "FurnishingTypes",
                columns: new[] { "Id", "LastUpdatedBy", "LastUpdatedOn", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(8950), "Fully" },
                    { 2, 1, new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(8953), "Semi" },
                    { 3, 1, new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(8955), "Unfurnished" }
                });

            migrationBuilder.InsertData(
                table: "PropertyTypes",
                columns: new[] { "Id", "LastUpdatedBy", "LastUpdatedOn", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(8915), "House" },
                    { 2, 1, new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(8918), "Apartment" },
                    { 3, 1, new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(8920), "Duplex" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "LastUpdatedBy", "LastUpdatedOn", "Password", "PasswordKey", "Username" },
                values: new object[] { 1, 0, new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(8698), new byte[] { 104, 97, 115, 104, 101, 100, 95, 112, 97, 115, 115, 119, 111, 114, 100 }, new byte[] { 104, 97, 115, 104, 101, 100, 95, 112, 97, 115, 115, 119, 111, 114, 100, 95, 107, 101, 121 }, "Demo" });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "Address2", "Age", "BHK", "BuiltArea", "CarpetArea", "CityId", "Description", "EstPossessionOn", "FloorNo", "FurnishingTypeId", "Gated", "LastUpdatedBy", "LastUpdatedOn", "MainEntrance", "Maintenance", "Name", "PostedBy", "PostedOn", "Price", "PropertyTypeId", "ReadyToMove", "Security", "SellRent", "TotalFloors" },
                values: new object[,]
                {
                    { 1, "6 Street", "Golf Course Road", 0, 2, 1400, 900, 1, "Well Maintained builder floor available for rent at prime location...", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, true, 0, new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(9039), "East", 300, "White House Demo", 1, new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(9057), 1800, 2, true, 0, 1, 3 },
                    { 2, "6 Street", "Golf Course Road", 0, 2, 1400, 900, 1, "Well Maintained builder floor available for rent at prime location...", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, true, 0, new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(9060), "East", 300, "Birla House Demo", 1, new DateTime(2024, 5, 31, 11, 34, 45, 6, DateTimeKind.Local).AddTicks(9066), 1800, 2, true, 0, 2, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FurnishingTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FurnishingTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FurnishingTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
