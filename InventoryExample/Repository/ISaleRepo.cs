using InventoryExample.Entities;

namespace InventoryExample.Repository
{
    public interface ISaleRepo
    {
        int CreateSaleHeader(SaleHeader saleHeader); 
        SaleHeader GetSaleHeader(int id);
        int CreateSaleDetails(SaleDetails saleDetails);
        SaleDetails GetSaleDetails(int id);

    }
}
