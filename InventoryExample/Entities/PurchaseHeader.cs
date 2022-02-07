namespace InventoryExample.Entities
{
    public class PurchaseHeader
    {
        public int id { get; set; }
        public double PurchaseTotal { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool PurchaseInvoiceStatus { get; set; }
        public ICollection<PurchaseDetail> PurchaseDetails { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
