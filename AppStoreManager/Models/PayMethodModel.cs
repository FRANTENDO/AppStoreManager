namespace AppStoreManager.Models
{
    public class PayMethodModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int StoreUserId { get; set; }
        public required string StoreUser { get; set; }
    }
}
