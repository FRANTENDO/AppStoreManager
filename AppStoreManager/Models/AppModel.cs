namespace AppStoreManager.Models
{
    public class AppModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public required string Category { get; set; }
    }
}
