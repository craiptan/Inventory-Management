using InventoryExample.DbContexts;
using InventoryExample.Entities;

namespace InventoryExample.Repository.Implementation
{
    public class PurchaseRepoImpl : IPurchaseRepo
    {
        private readonly ApplicationDbContext dbContext;

        public PurchaseRepoImpl(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int CreatePurchaseDetails(PurchaseDetail purchaseDetail)
        {
            try
            {
                dbContext.PurchaseDetails.AddAsync(purchaseDetail);
                dbContext.SaveChangesAsync();
                return purchaseDetail.Id; 
            }catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public int CreatePurchaseHeader(PurchaseHeader purchaseHeader)
        {
            try
            {
                dbContext.PurchaseHeaders.AddAsync(purchaseHeader);
                dbContext.SaveChangesAsync();
                return purchaseHeader.id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public PurchaseDetail GetPurchaseDetails(int id)
        {
            try
            {
               var detail = dbContext.PurchaseDetails.Where(x=>x.Id == id).FirstOrDefault();
                return detail;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public PurchaseHeader GetPurchaseHeader(int id)
        {
            try
            {
                var detail = dbContext.PurchaseHeaders.Where(x => x.id == id).FirstOrDefault();
                return detail;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
