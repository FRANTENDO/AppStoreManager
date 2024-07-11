using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppStoreManager.Migrations
{
    /// <inheritdoc />
    public partial class PayMethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "StoreUserId", "NickName" },
                values: new object[,]
                {
                    { 1, "Francoxxx" },
                    { 2, "ReVlasta_official" },
                    { 3, "non_mi_drogo_" }
                });

            migrationBuilder.InsertData(
                table: "PayMethods",
                columns: new[] { "PayMethodId", "Name", "StoreUserId" },
                values: new object[,]
                {
                    { 1, "PayPal", 1 },
                    { 2, "Carta di debito", 2 },
                    { 3, "Carta di credito", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PayMethods",
                keyColumn: "PayMethodId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PayMethods",
                keyColumn: "PayMethodId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PayMethods",
                keyColumn: "PayMethodId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "StoreUserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "StoreUserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "StoreUserId",
                keyValue: 3);
        }
    }
}
