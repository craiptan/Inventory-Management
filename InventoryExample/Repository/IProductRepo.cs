using InventoryExample.Entities;

namespace InventoryExample.Repository
{
    public interface IProductRepo
    {
        Task<bool> CreateUpdateProductAsync(Product product);
        Product GetProductByProductCode(string productCode);
        List<Product> GetAllProducts(int pageSize);
        int GetAllProduct();
        void DeleteProduct(Product product);

    }
}
