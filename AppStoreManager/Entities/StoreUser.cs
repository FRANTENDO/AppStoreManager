namespace AppStoreManager.Entities
{
    public class StoreUser
    {
        public int StoreUserId { get; set; }
        public required string NickName { get; set; }
        public required string Password { get; set; }
        public required string Mail { get; set; }
        public required string FullName { get; set; }
        public List<Purchase>? Purchases { get; set; }
        public List<PayMethod>? PayMethods { get; set; }
    }
}
