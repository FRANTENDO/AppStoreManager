using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppStoreManager.Migrations
{
    /// <inheritdoc />
    public partial class Purchase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "AppCatalogueId", "StoreUserId", "CreatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 7, 8, 14, 33, 0, 566, DateTimeKind.Local).AddTicks(1661) },
                    { 2, 2, new DateTime(2024, 7, 8, 14, 33, 0, 566, DateTimeKind.Local).AddTicks(1712) },
                    { 3, 3, new DateTime(2024, 7, 8, 14, 33, 0, 566, DateTimeKind.Local).AddTicks(1715) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumns: new[] { "AppCatalogueId", "StoreUserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumns: new[] { "AppCatalogueId", "StoreUserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumns: new[] { "AppCatalogueId", "StoreUserId" },
                keyValues: new object[] { 3, 3 });
        }
    }
}
