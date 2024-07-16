using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppStoreManager.Migrations
{
    /// <inheritdoc />
    public partial class AddIconPathToAppCatalogue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconPath",
                table: "AppCatalogues",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppCatalogues",
                keyColumn: "AppCatalogueId",
                keyValue: 1,
                column: "IconPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "AppCatalogues",
                keyColumn: "AppCatalogueId",
                keyValue: 2,
                column: "IconPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "AppCatalogues",
                keyColumn: "AppCatalogueId",
                keyValue: 3,
                column: "IconPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "AppCatalogues",
                keyColumn: "AppCatalogueId",
                keyValue: 4,
                column: "IconPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "AppCatalogues",
                keyColumn: "AppCatalogueId",
                keyValue: 5,
                column: "IconPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "AppCatalogues",
                keyColumn: "AppCatalogueId",
                keyValue: 6,
                column: "IconPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumns: new[] { "AppCatalogueId", "StoreUserId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2024, 7, 16, 16, 39, 15, 56, DateTimeKind.Local).AddTicks(2006));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumns: new[] { "AppCatalogueId", "StoreUserId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedAt",
                value: new DateTime(2024, 7, 16, 16, 39, 15, 56, DateTimeKind.Local).AddTicks(2061));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumns: new[] { "AppCatalogueId", "StoreUserId" },
                keyValues: new object[] { 3, 3 },
                column: "CreatedAt",
                value: new DateTime(2024, 7, 16, 16, 39, 15, 56, DateTimeKind.Local).AddTicks(2068));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumns: new[] { "AppCatalogueId", "StoreUserId" },
                keyValues: new object[] { 4, 1 },
                column: "CreatedAt",
                value: new DateTime(2024, 7, 16, 16, 39, 15, 56, DateTimeKind.Local).AddTicks(2072));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumns: new[] { "AppCatalogueId", "StoreUserId" },
                keyValues: new object[] { 5, 2 },
                column: "CreatedAt",
                value: new DateTime(2024, 7, 16, 16, 39, 15, 56, DateTimeKind.Local).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumns: new[] { "AppCatalogueId", "StoreUserId" },
                keyValues: new object[] { 6, 3 },
                column: "CreatedAt",
                value: new DateTime(2024, 7, 16, 16, 39, 15, 56, DateTimeKind.Local).AddTicks(2083));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconPath",
                table: "AppCatalogues");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumns: new[] { "AppCatalogueId", "StoreUserId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2024, 7, 15, 14, 11, 21, 822, DateTimeKind.Local).AddTicks(2536));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumns: new[] { "AppCatalogueId", "StoreUserId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedAt",
                value: new DateTime(2024, 7, 15, 14, 11, 21, 822, DateTimeKind.Local).AddTicks(2587));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumns: new[] { "AppCatalogueId", "StoreUserId" },
                keyValues: new object[] { 3, 3 },
                column: "CreatedAt",
                value: new DateTime(2024, 7, 15, 14, 11, 21, 822, DateTimeKind.Local).AddTicks(2591));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumns: new[] { "AppCatalogueId", "StoreUserId" },
                keyValues: new object[] { 4, 1 },
                column: "CreatedAt",
                value: new DateTime(2024, 7, 15, 14, 11, 21, 822, DateTimeKind.Local).AddTicks(2597));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumns: new[] { "AppCatalogueId", "StoreUserId" },
                keyValues: new object[] { 5, 2 },
                column: "CreatedAt",
                value: new DateTime(2024, 7, 15, 14, 11, 21, 822, DateTimeKind.Local).AddTicks(2600));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumns: new[] { "AppCatalogueId", "StoreUserId" },
                keyValues: new object[] { 6, 3 },
                column: "CreatedAt",
                value: new DateTime(2024, 7, 15, 14, 11, 21, 822, DateTimeKind.Local).AddTicks(2605));
        }
    }
}
