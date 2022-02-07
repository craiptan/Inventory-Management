namespace InventoryExample.Models
{
    public class PurchaseHeaderModel
    {
        public double PurchaseTotal { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool PurchaseInvoiceStatus { get; set; }
        public ICollection<PurchaseDetailModel> PurchaseDetails { get; set; }
    }
}
