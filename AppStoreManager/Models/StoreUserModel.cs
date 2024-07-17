namespace AppStoreManager.Models
{
    public class StoreUserModel
    {
        public int Id { get; set; }
        public required string NickName { get; set; }
        public required string Pass { get; set; }
        public required string Mail { get; set; }
        public required string FullName { get; set; }
    }
}
