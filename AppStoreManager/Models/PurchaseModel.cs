using AppStoreManager.Entities;

namespace AppStoreManager.Models
{
    public class PurchaseModel
    {
        public int AppCatalogueId { get; set; }
        public int StoreUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string AppCatalogue { get; set; }
        public required string StoreUser { get; set; }
    }
}
