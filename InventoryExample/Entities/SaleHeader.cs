namespace InventoryExample.Entities
{
    public class SaleHeader
    {
        public int id { get; set; }
        public double InvoiceTotal { get; set; }
        public DateTime InvoiceDate { get; set; }
        public bool InvoiceStatus { get; set; }
        public ICollection<SaleDetails> SaleDetails { get; set; }   
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
