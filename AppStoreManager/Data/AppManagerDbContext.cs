using AppStoreManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppStoreManager.Data
{
    public class AppManagerDbContext(DbContextOptions<AppManagerDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            List<Category> categories = new List<Category>()
            {
                new Category() { CategoryId = 1, Name = "Game" },
                new Category() { CategoryId = 2, Name = "Social" },
                new Category() { CategoryId = 3, Name = "Messaging" }
            };

            modelBuilder.Entity<Category>().HasData(categories);

            List<AppCatalogue> apps = new List<AppCatalogue>()
            {
                new AppCatalogue() { AppCatalogueId = 1, CategoryId = 1, Title = "Clash of Clans", Description = "Brutto", Price = 0 },
                new AppCatalogue() { AppCatalogueId = 2, CategoryId = 1, Title = "Minecraft", Description = "Bello", Price = 6.50 },
                new AppCatalogue() { AppCatalogueId = 3, CategoryId = 2, Title = "Instagram", Description = "Vecchio", Price = 0 },
                new AppCatalogue() { AppCatalogueId = 4, CategoryId = 2, Title = "TikTok", Description = "Nuovo", Price = 0 },
                new AppCatalogue() { AppCatalogueId = 5, CategoryId = 3, Title = "Whatsapp", Description = "Vecchissimo", Price = 0 },
                new AppCatalogue() { AppCatalogueId = 6, CategoryId = 3, Title = "Telegram", Description = "Russo", Price = 0 }
            };
            modelBuilder.Entity<AppCatalogue>().HasData(apps);

            List<PayMethod> payMethods = new List<PayMethod>()
            {
                new PayMethod() { StoreUserId = 1, PayMethodId = 1, Name = "PayPal" },
                new PayMethod() { StoreUserId = 2, PayMethodId = 2, Name = "Carta di debito" },
                new PayMethod() { StoreUserId = 3, PayMethodId = 3, Name = "Carta di credito" },
            };
            modelBuilder.Entity<PayMethod>().HasData(payMethods);
            
            List<StoreUser> users = new List<StoreUser>()
            {
                new StoreUser() { StoreUserId = 1, NickName = "Francoxxx", Password = "Password1" },
                new StoreUser() { StoreUserId = 2, NickName = "ReVlasta_official", Password = "Password2" },
                new StoreUser() { StoreUserId = 3, NickName = "non_mi_drogo_", Password = "Password3" }
                };
            modelBuilder.Entity<StoreUser>().HasData(users);

            List<Permission> permissions = new List<Permission>()
            {
                new Permission() { PermissionId = 1, Name = "Foto" },
                new Permission() { PermissionId = 2, Name = "Contatti" },
                new Permission() { PermissionId = 3, Name = "Posizione" },
            };
            modelBuilder.Entity<Permission>().HasData(permissions);

            List<Purchase> purchases = new List<Purchase>()
            {
                new Purchase() { AppCatalogueId = 1, StoreUserId = 1, CreatedAt = DateTime.Now },
                new Purchase() { AppCatalogueId = 2, StoreUserId = 2, CreatedAt = DateTime.Now },
                new Purchase() { AppCatalogueId = 3, StoreUserId = 3, CreatedAt = DateTime.Now },
                new Purchase() { AppCatalogueId = 4, StoreUserId = 1, CreatedAt = DateTime.Now },
                new Purchase() { AppCatalogueId = 5, StoreUserId = 2, CreatedAt = DateTime.Now },
                new Purchase() { AppCatalogueId = 6, StoreUserId = 3, CreatedAt = DateTime.Now }
            };
            modelBuilder.Entity<Purchase>().HasData(purchases);
        }

        public DbSet<StoreUser> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppCatalogue> AppCatalogues { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PayMethod> PayMethods { get; set; }
        public DbSet<Permission> Permissions { get; set; }
    }
}
