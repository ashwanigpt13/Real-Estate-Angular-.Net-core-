using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class PhotosPublic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdatedOn",
                value: new DateTime(2024, 6, 4, 3, 43, 4, 797, DateTimeKind.Local).AddTicks(1883));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdatedOn",
                value: new DateTime(2024, 6, 4, 3, 43, 4, 797, DateTimeKind.Local).AddTicks(1885));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastUpdatedOn",
                value: new DateTime(2024, 6, 4, 3, 43, 4, 797, DateTimeKind.Local).AddTicks(1887));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastUpdatedOn",
                value: new DateTime(2024, 6, 4, 3, 43, 4, 797, DateTimeKind.Local).AddTicks(1888));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastUpdatedOn",
                value: new DateTime(2024, 6, 4, 3, 43, 4, 797, DateTimeKind.Local).AddTicks(1889));

            migrationBuilder.UpdateData(
                table: "FurnishingTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdatedOn",
                value: new DateTime(2024, 6, 4, 3, 43, 4, 797, DateTimeKind.Local).AddTicks(1857));

            migrationBuilder.UpdateData(
                table: "FurnishingTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdatedOn",
                value: new DateTime(2024, 6, 4, 3, 43, 4, 797, DateTimeKind.Local).AddTicks(1859));

            migrationBuilder.UpdateData(
                table: "FurnishingTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastUpdatedOn",
                value: new DateTime(2024, 6, 4, 3, 43, 4, 797, DateTimeKind.Local).AddTicks(1860));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LastUpdatedOn", "PostedOn" },
                values: new object[] { new DateTime(2024, 6, 4, 3, 43, 4, 797, DateTimeKind.Local).AddTicks(1920), new DateTime(2024, 6, 4, 3, 43, 4, 797, DateTimeKind.Local).AddTicks(1932) });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LastUpdatedOn", "PostedOn" },
                values: new object[] { new DateTime(2024, 6, 4, 3, 43, 4, 797, DateTimeKind.Local).AddTicks(1934), new DateTime(2024, 6, 4, 3, 43, 4, 797, DateTimeKind.Local).AddTicks(1939) });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdatedOn",
                value: new DateTime(2024, 6, 4, 3, 43, 4, 797, DateTimeKind.Local).AddTicks(1832));

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdatedOn",
                value: new DateTime(2024, 6, 4, 3, 43, 4, 797, DateTimeKind.Local).AddTicks(1834));

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastUpdatedOn",
                value: new DateTime(2024, 6, 4, 3, 43, 4, 797, DateTimeKind.Local).AddTicks(1836));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdatedOn",
                value: new DateTime(2024, 6, 4, 3, 43, 4, 797, DateTimeKind.Local).AddTicks(1692));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Photos");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdatedOn",
                value: new DateTime(2024, 5, 31, 17, 4, 39, 767, DateTimeKind.Local).AddTicks(4788));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdatedOn",
                value: new DateTime(2024, 5, 31, 17, 4, 39, 767, DateTimeKind.Local).AddTicks(4790));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastUpdatedOn",
                value: new DateTime(2024, 5, 31, 17, 4, 39, 767, DateTimeKind.Local).AddTicks(4792));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastUpdatedOn",
                value: new DateTime(2024, 5, 31, 17, 4, 39, 767, DateTimeKind.Local).AddTicks(4793));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastUpdatedOn",
                value: new DateTime(2024, 5, 31, 17, 4, 39, 767, DateTimeKind.Local).AddTicks(4795));

            migrationBuilder.UpdateData(
                table: "FurnishingTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdatedOn",
                value: new DateTime(2024, 5, 31, 17, 4, 39, 767, DateTimeKind.Local).AddTicks(4755));

            migrationBuilder.UpdateData(
                table: "FurnishingTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdatedOn",
                value: new DateTime(2024, 5, 31, 17, 4, 39, 767, DateTimeKind.Local).AddTicks(4757));

            migrationBuilder.UpdateData(
                table: "FurnishingTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastUpdatedOn",
                value: new DateTime(2024, 5, 31, 17, 4, 39, 767, DateTimeKind.Local).AddTicks(4759));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LastUpdatedOn", "PostedOn" },
                values: new object[] { new DateTime(2024, 5, 31, 17, 4, 39, 767, DateTimeKind.Local).AddTicks(4832), new DateTime(2024, 5, 31, 17, 4, 39, 767, DateTimeKind.Local).AddTicks(4848) });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LastUpdatedOn", "PostedOn" },
                values: new object[] { new DateTime(2024, 5, 31, 17, 4, 39, 767, DateTimeKind.Local).AddTicks(4851), new DateTime(2024, 5, 31, 17, 4, 39, 767, DateTimeKind.Local).AddTicks(4857) });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdatedOn",
                value: new DateTime(2024, 5, 31, 17, 4, 39, 767, DateTimeKind.Local).AddTicks(4723));

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdatedOn",
                value: new DateTime(2024, 5, 31, 17, 4, 39, 767, DateTimeKind.Local).AddTicks(4725));

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastUpdatedOn",
                value: new DateTime(2024, 5, 31, 17, 4, 39, 767, DateTimeKind.Local).AddTicks(4727));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdatedOn",
                value: new DateTime(2024, 5, 31, 17, 4, 39, 767, DateTimeKind.Local).AddTicks(4566));
        }
    }
}
