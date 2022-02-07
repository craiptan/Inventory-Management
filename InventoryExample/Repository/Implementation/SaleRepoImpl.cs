using InventoryExample.DbContexts;
using InventoryExample.Entities;

namespace InventoryExample.Repository.Implementation
{
    
    public class SaleRepoImpl : ISaleRepo
    {
        private readonly ApplicationDbContext DbContext;

        public SaleRepoImpl(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public int CreateSaleDetails(SaleDetails saleDetails)
        {
            try
            {
                DbContext.SaleDetails.AddAsync(saleDetails);
                DbContext.SaveChanges();
                return saleDetails.Id;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CreateSaleHeader(SaleHeader saleHeader)
        {
            try
            {
                DbContext.SaleHeaders.AddAsync(saleHeader);
                DbContext.SaveChanges();
                return saleHeader.id;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SaleDetails GetSaleDetails(int id)
        {
            try
            {
               return  DbContext.SaleDetails.Where(x=>x.Id==id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SaleHeader GetSaleHeader(int id)
        {
            try
            {
                return DbContext.SaleHeaders.Where(x => x.id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
