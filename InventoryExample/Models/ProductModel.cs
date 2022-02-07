namespace InventoryExample.Models
{
    public class ProductModel
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal ReOrderLevel { get; set; }
        public bool isActive { get; set; }
    }
}
