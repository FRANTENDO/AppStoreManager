using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppStoreManager.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "StoreUserId",
                keyValue: 1,
                column: "Password",
                value: "Password1");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "StoreUserId",
                keyValue: 2,
                column: "Password",
                value: "Password2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "StoreUserId",
                keyValue: 3,
                column: "Password",
                value: "Password3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumns: new[] { "AppCatalogueId", "StoreUserId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2024, 7, 15, 10, 15, 17, 103, DateTimeKind.Local).AddTicks(9306));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumns: new[] { "AppCatalogueId", "StoreUserId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedAt",
                value: new DateTime(2024, 7, 15, 10, 15, 17, 103, DateTimeKind.Local).AddTicks(9388));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumns: new[] { "AppCatalogueId", "StoreUserId" },
                keyValues: new object[] { 3, 3 },
                column: "CreatedAt",
                value: new DateTime(2024, 7, 15, 10, 15, 17, 103, DateTimeKind.Local).AddTicks(9394));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumns: new[] { "AppCatalogueId", "StoreUserId" },
                keyValues: new object[] { 4, 1 },
                column: "CreatedAt",
                value: new DateTime(2024, 7, 15, 10, 15, 17, 103, DateTimeKind.Local).AddTicks(9400));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumns: new[] { "AppCatalogueId", "StoreUserId" },
                keyValues: new object[] { 5, 2 },
                column: "CreatedAt",
                value: new DateTime(2024, 7, 15, 10, 15, 17, 103, DateTimeKind.Local).AddTicks(9405));

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumns: new[] { "AppCatalogueId", "StoreUserId" },
                keyValues: new object[] { 6, 3 },
                column: "CreatedAt",
                value: new DateTime(2024, 7, 15, 10, 15, 17, 103, DateTimeKind.Local).AddTicks(9419));
        }
    }
}
