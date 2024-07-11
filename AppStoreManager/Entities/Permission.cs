namespace AppStoreManager.Entities
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public required string Name { get; set; }
        public List<AppCatalogue>? Apps { get; set; }
    }
}
