namespace AppStoreManager.Entities
{
    public class AppCatalogue
    {
        public int AppCatalogueId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<Purchase>? Purchases { get; set; }
        public List<Permission>? Permissions { get; set; }
    }
}
