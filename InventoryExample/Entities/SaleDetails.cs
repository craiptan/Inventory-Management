namespace InventoryExample.Entities
{
    public class SaleDetails
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public decimal Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public SaleHeader SaleHeader { get; set; }

    }
}
