using InventoryExample.DbContexts;
using InventoryExample.Entities;
using InventoryExample.Models;

namespace InventoryExample.Repository.Implementation
{
    public class ProductRepoImpl : IProductRepo
    {
        private readonly ApplicationDbContext dbContext;

        public ProductRepoImpl(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            try
            {
                await dbContext.Products.AddAsync(product);
                var res = await dbContext.SaveChangesAsync();
                if (res > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public void DeleteProduct(Product product)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int GetAllProduct()
        {
            try
            {
                var allproducts = dbContext.Products.ToList();
                return allproducts.Count;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Product> GetAllProducts(int pageSize)
        {
            try
            {
                var products= dbContext.Products.ToList();
                return products;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Product GetProductByProductCode(string productCode)
        {
            try
            {
                var product = dbContext.Products.Where(x=>x.ProductCode==productCode).FirstOrDefault();
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Product Update(Product product)
        {
            try
            {
                dbContext.Products.Update(product);
                dbContext.SaveChanges();
                return product;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
