﻿// <auto-generated />
using System;
using AppStoreManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppStoreManager.Migrations
{
    [DbContext(typeof(AppManagerDbContext))]
    partial class AppManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("AppCataloguePermission", b =>
                {
                    b.Property<int>("AppsAppCatalogueId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PermissionsPermissionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AppsAppCatalogueId", "PermissionsPermissionId");

                    b.HasIndex("PermissionsPermissionId");

                    b.ToTable("AppCataloguePermission");
                });

            modelBuilder.Entity("AppStoreManager.Entities.AppCatalogue", b =>
                {
                    b.Property<int>("AppCatalogueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AppCatalogueId");

                    b.HasIndex("CategoryId");

                    b.ToTable("AppCatalogues");

                    b.HasData(
                        new
                        {
                            AppCatalogueId = 1,
                            CategoryId = 1,
                            Description = "Brutto",
                            Price = 0.0,
                            Title = "Clash of Clans"
                        },
                        new
                        {
                            AppCatalogueId = 2,
                            CategoryId = 1,
                            Description = "Bello",
                            Price = 6.5,
                            Title = "Minecraft"
                        },
                        new
                        {
                            AppCatalogueId = 3,
                            CategoryId = 2,
                            Description = "Vecchio",
                            Price = 0.0,
                            Title = "Instagram"
                        },
                        new
                        {
                            AppCatalogueId = 4,
                            CategoryId = 2,
                            Description = "Nuovo",
                            Price = 0.0,
                            Title = "TikTok"
                        },
                        new
                        {
                            AppCatalogueId = 5,
                            CategoryId = 3,
                            Description = "Vecchissimo",
                            Price = 0.0,
                            Title = "Whatsapp"
                        },
                        new
                        {
                            AppCatalogueId = 6,
                            CategoryId = 3,
                            Description = "Russo",
                            Price = 0.0,
                            Title = "Telegram"
                        });
                });

            modelBuilder.Entity("AppStoreManager.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Game"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Social"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Messaging"
                        });
                });

            modelBuilder.Entity("AppStoreManager.Entities.PayMethod", b =>
                {
                    b.Property<int>("PayMethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StoreUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PayMethodId");

                    b.HasIndex("StoreUserId");

                    b.ToTable("PayMethods");

                    b.HasData(
                        new
                        {
                            PayMethodId = 1,
                            Name = "PayPal",
                            StoreUserId = 1
                        },
                        new
                        {
                            PayMethodId = 2,
                            Name = "Carta di debito",
                            StoreUserId = 2
                        },
                        new
                        {
                            PayMethodId = 3,
                            Name = "Carta di credito",
                            StoreUserId = 3
                        });
                });

            modelBuilder.Entity("AppStoreManager.Entities.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PermissionId");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            PermissionId = 1,
                            Name = "Foto"
                        },
                        new
                        {
                            PermissionId = 2,
                            Name = "Contatti"
                        },
                        new
                        {
                            PermissionId = 3,
                            Name = "Posizione"
                        });
                });

            modelBuilder.Entity("AppStoreManager.Entities.Purchase", b =>
                {
                    b.Property<int>("AppCatalogueId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StoreUserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("AppCatalogueId", "StoreUserId");

                    b.HasIndex("StoreUserId");

                    b.ToTable("Purchases");

                    b.HasData(
                        new
                        {
                            AppCatalogueId = 1,
                            StoreUserId = 1,
                            CreatedAt = new DateTime(2024, 7, 15, 14, 11, 21, 822, DateTimeKind.Local).AddTicks(2536)
                        },
                        new
                        {
                            AppCatalogueId = 2,
                            StoreUserId = 2,
                            CreatedAt = new DateTime(2024, 7, 15, 14, 11, 21, 822, DateTimeKind.Local).AddTicks(2587)
                        },
                        new
                        {
                            AppCatalogueId = 3,
                            StoreUserId = 3,
                            CreatedAt = new DateTime(2024, 7, 15, 14, 11, 21, 822, DateTimeKind.Local).AddTicks(2591)
                        },
                        new
                        {
                            AppCatalogueId = 4,
                            StoreUserId = 1,
                            CreatedAt = new DateTime(2024, 7, 15, 14, 11, 21, 822, DateTimeKind.Local).AddTicks(2597)
                        },
                        new
                        {
                            AppCatalogueId = 5,
                            StoreUserId = 2,
                            CreatedAt = new DateTime(2024, 7, 15, 14, 11, 21, 822, DateTimeKind.Local).AddTicks(2600)
                        },
                        new
                        {
                            AppCatalogueId = 6,
                            StoreUserId = 3,
                            CreatedAt = new DateTime(2024, 7, 15, 14, 11, 21, 822, DateTimeKind.Local).AddTicks(2605)
                        });
                });

            modelBuilder.Entity("AppStoreManager.Entities.StoreUser", b =>
                {
                    b.Property<int>("StoreUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StoreUserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            StoreUserId = 1,
                            NickName = "Francoxxx",
                            Password = "Password1"
                        },
                        new
                        {
                            StoreUserId = 2,
                            NickName = "ReVlasta_official",
                            Password = "Password2"
                        },
                        new
                        {
                            StoreUserId = 3,
                            NickName = "non_mi_drogo_",
                            Password = "Password3"
                        });
                });

            modelBuilder.Entity("AppCataloguePermission", b =>
                {
                    b.HasOne("AppStoreManager.Entities.AppCatalogue", null)
                        .WithMany()
                        .HasForeignKey("AppsAppCatalogueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppStoreManager.Entities.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionsPermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AppStoreManager.Entities.AppCatalogue", b =>
                {
                    b.HasOne("AppStoreManager.Entities.Category", "Category")
                        .WithMany("Apps")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("AppStoreManager.Entities.PayMethod", b =>
                {
                    b.HasOne("AppStoreManager.Entities.StoreUser", "StoreUser")
                        .WithMany("PayMethods")
                        .HasForeignKey("StoreUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StoreUser");
                });

            modelBuilder.Entity("AppStoreManager.Entities.Purchase", b =>
                {
                    b.HasOne("AppStoreManager.Entities.AppCatalogue", "App")
                        .WithMany("Purchases")
                        .HasForeignKey("AppCatalogueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppStoreManager.Entities.StoreUser", "User")
                        .WithMany("Purchases")
                        .HasForeignKey("StoreUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("App");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AppStoreManager.Entities.AppCatalogue", b =>
                {
                    b.Navigation("Purchases");
                });

            modelBuilder.Entity("AppStoreManager.Entities.Category", b =>
                {
                    b.Navigation("Apps");
                });

            modelBuilder.Entity("AppStoreManager.Entities.StoreUser", b =>
                {
                    b.Navigation("PayMethods");

                    b.Navigation("Purchases");
                });
#pragma warning restore 612, 618
        }
    }
}
