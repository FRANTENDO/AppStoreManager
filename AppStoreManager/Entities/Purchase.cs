using Microsoft.EntityFrameworkCore;

namespace AppStoreManager.Entities
{
    [PrimaryKey(nameof(AppCatalogueId), nameof(StoreUserId))]
    public class Purchase
    {
        public int AppCatalogueId { get; set; }
        public int StoreUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public AppCatalogue? App { get; set; }
        public StoreUser? User { get; set; }
    }
}
