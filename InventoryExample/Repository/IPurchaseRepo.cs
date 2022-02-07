using InventoryExample.Entities;

namespace InventoryExample.Repository
{
    public interface IPurchaseRepo
    {
        int CreatePurchaseHeader(PurchaseHeader purchaseHeader);
        PurchaseHeader GetPurchaseHeader(int id);
        int CreatePurchaseDetails(PurchaseDetail purchaseDetail);
        PurchaseDetail GetPurchaseDetails(int id);
    }
}
