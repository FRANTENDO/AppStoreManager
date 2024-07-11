using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppStoreManager.Migrations
{
    /// <inheritdoc />
    public partial class DbCreation : Migration
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
