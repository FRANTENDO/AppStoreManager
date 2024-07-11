namespace AppStoreManager.Entities
{
    public class PayMethod
    {
        public int PayMethodId { get; set; }
        public required string Name { get; set; }
        public int StoreUserId { get; set; }
        public StoreUser? StoreUser { get; set; }
    }
}
