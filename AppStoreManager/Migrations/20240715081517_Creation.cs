using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppStoreManager.Migrations
{
    /// <inheritdoc />
    public partial class Creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    StoreUserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NickName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.StoreUserId);
                });

            migrationBuilder.CreateTable(
                name: "AppCatalogues",
                columns: table => new
                {
                    AppCatalogueId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCatalogues", x => x.AppCatalogueId);
                    table.ForeignKey(
                        name: "FK_AppCatalogues_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayMethods",
                columns: table => new
                {
                    PayMethodId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    StoreUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayMethods", x => x.PayMethodId);
                    table.ForeignKey(
                        name: "FK_PayMethods_Users_StoreUserId",
                        column: x => x.StoreUserId,
                        principalTable: "Users",
                        principalColumn: "StoreUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppCataloguePermission",
                columns: table => new
                {
                    AppsAppCatalogueId = table.Column<int>(type: "INTEGER", nullable: false),
                    PermissionsPermissionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCataloguePermission", x => new { x.AppsAppCatalogueId, x.PermissionsPermissionId });
                    table.ForeignKey(
                        name: "FK_AppCataloguePermission_AppCatalogues_AppsAppCatalogueId",
                        column: x => x.AppsAppCatalogueId,
                        principalTable: "AppCatalogues",
                        principalColumn: "AppCatalogueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppCataloguePermission_Permissions_PermissionsPermissionId",
                        column: x => x.PermissionsPermissionId,
                        principalTable: "Permissions",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    AppCatalogueId = table.Column<int>(type: "INTEGER", nullable: false),
                    StoreUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => new { x.AppCatalogueId, x.StoreUserId });
                    table.ForeignKey(
                        name: "FK_Purchases_AppCatalogues_AppCatalogueId",
                        column: x => x.AppCatalogueId,
                        principalTable: "AppCatalogues",
                        principalColumn: "AppCatalogueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_Users_StoreUserId",
                        column: x => x.StoreUserId,
                        principalTable: "Users",
                        principalColumn: "StoreUserId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                table: "Permissions",
                columns: new[] { "PermissionId", "Name" },
                values: new object[,]
                {
                    { 1, "Foto" },
                    { 2, "Contatti" },
                    { 3, "Posizione" }
                });

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

            migrationBuilder.InsertData(
                table: "PayMethods",
                columns: new[] { "PayMethodId", "Name", "StoreUserId" },
                values: new object[,]
                {
                    { 1, "PayPal", 1 },
                    { 2, "Carta di debito", 2 },
                    { 3, "Carta di credito", 3 }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "AppCatalogueId", "StoreUserId", "CreatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 7, 15, 10, 15, 17, 103, DateTimeKind.Local).AddTicks(9306) },
                    { 2, 2, new DateTime(2024, 7, 15, 10, 15, 17, 103, DateTimeKind.Local).AddTicks(9388) },
                    { 3, 3, new DateTime(2024, 7, 15, 10, 15, 17, 103, DateTimeKind.Local).AddTicks(9394) },
                    { 4, 1, new DateTime(2024, 7, 15, 10, 15, 17, 103, DateTimeKind.Local).AddTicks(9400) },
                    { 5, 2, new DateTime(2024, 7, 15, 10, 15, 17, 103, DateTimeKind.Local).AddTicks(9405) },
                    { 6, 3, new DateTime(2024, 7, 15, 10, 15, 17, 103, DateTimeKind.Local).AddTicks(9419) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppCataloguePermission_PermissionsPermissionId",
                table: "AppCataloguePermission",
                column: "PermissionsPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCatalogues_CategoryId",
                table: "AppCatalogues",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PayMethods_StoreUserId",
                table: "PayMethods",
                column: "StoreUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_StoreUserId",
                table: "Purchases",
                column: "StoreUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppCataloguePermission");

            migrationBuilder.DropTable(
                name: "PayMethods");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "AppCatalogues");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
