namespace InventoryExample.Entities
{
    public class PurchaseDetail
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public decimal Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public PurchaseHeader PurchaseHeader { get; set; }
    }
}
