using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppStoreManager.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Game" },
                    { 2, "Social" },
                    { 3, "Messaging" }
                });

            migrationBuilder.InsertData(
                table: "AppCatalogues",
                columns: new[] { "AppCatalogueId", "CategoryId", "Description", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Brutto", 0.0, "Clash of Clans" },
                    { 2, 1, "Bello", 6.5, "Minecraft" },
                    { 3, 2, "Vecchio", 0.0, "Instagram" },
                    { 4, 2, "Nuovo", 0.0, "TikTok" },
                    { 5, 3, "Vecchissimo", 0.0, "Whatsapp" },
                    { 6, 3, "Russo", 0.0, "Telegram" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppCatalogues",
                keyColumn: "AppCatalogueId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppCatalogues",
                keyColumn: "AppCatalogueId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AppCatalogues",
                keyColumn: "AppCatalogueId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AppCatalogues",
                keyColumn: "AppCatalogueId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AppCatalogues",
                keyColumn: "AppCatalogueId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AppCatalogues",
                keyColumn: "AppCatalogueId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);
        }
    }
}
