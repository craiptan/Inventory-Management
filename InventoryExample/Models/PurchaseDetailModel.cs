namespace InventoryExample.Models
{
    public class PurchaseDetailModel
    {
        public string ProductCode { get; set; }
        public decimal Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
    }
}
