namespace AppStoreManager.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public List<AppCatalogue>? Apps { get; set; }
    }
}
