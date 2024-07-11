﻿// <auto-generated />
using System;
using AppStoreManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppStoreManager.Migrations
{
    [DbContext(typeof(AppManagerDbContext))]
    [Migration("20240708103906_Permission")]
    partial class Permission
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                });

            modelBuilder.Entity("AppStoreManager.Entities.StoreUser", b =>
                {
                    b.Property<int>("StoreUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StoreUserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            StoreUserId = 1,
                            NickName = "Francoxxx"
                        },
                        new
                        {
                            StoreUserId = 2,
                            NickName = "ReVlasta_official"
                        },
                        new
                        {
                            StoreUserId = 3,
                            NickName = "non_mi_drogo_"
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
