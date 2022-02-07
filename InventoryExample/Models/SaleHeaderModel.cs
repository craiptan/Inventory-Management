namespace InventoryExample.Models
{
    public class SaleHeaderModel
    {
        public double InvoiceTotal { get; set; }
        public DateTime InvoiceDate { get; set; }
        public bool InvoiceStatus { get; set; }
        public ICollection<SaleDetailsModel> SaleDetails { get; set; }
    }
}
