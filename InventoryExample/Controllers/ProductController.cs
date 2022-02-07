using InventoryExample.Entities;
using InventoryExample.Models;
using InventoryExample.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InventoryExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepo productRepo;
        private IPurchaseRepo purchaseRepo;
        private ISaleRepo saleRepo;

        public ProductController(IProductRepo productRepo, IPurchaseRepo purchaseRepo, ISaleRepo saleRepo)
        {
            this.productRepo = productRepo;
            this.purchaseRepo = purchaseRepo;
            this.saleRepo = saleRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateControllerAsync(ProductModel model)
        {
            try
            {
                //generate product code
                var allp = productRepo.GetAllProduct()+1;
                string productCode = "PD"+allp.ToString("D4");
                Product product = new Product();
                product.ProductCode = productCode;
                product.ProductName = model.ProductName;
                product.Description = model.Description;
                product.Price  = model.Price;
                product.Quantity = model.Quantity;
                product.ReOrderLevel =  model.ReOrderLevel;
                product.isActive = model.isActive;
                product.CreatedBy = "get logged in user";
                product.CreatedOn = DateTime.Now;
                var createdProduct = await productRepo.CreateProductAsync(product);
                if(createdProduct)
                {
                    return Created(nameof(GetProducts), new { id = product.ProductCode });
                }
                return Ok(JsonConvert.SerializeObject(createdProduct));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("AllProducts")]
        public IActionResult GetProducts()
        {
            try
            {
                var products = productRepo.GetAllProducts(50);
                return Ok(products);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetProduct/{productCode}")]
        public IActionResult GetProducts(string productCode)
        {
            try
            {
                var product = productRepo.GetProductByProductCode(productCode);

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Sale")]
        public IActionResult SaleProduct(SaleHeaderModel model)
        {
            try
            {
                //check for product quantity
                for (int x = 0; x < model.SaleDetails.Count; x++)
                {
                    //get the product Quantity 
                    var sales = model.SaleDetails.ToArray();
                    SaleDetailsModel DetailModel = sales[x];
                    Product product = productRepo.GetProductByProductCode(DetailModel.ProductCode);
                    if (product.Quantity <= 0 && product.Quantity <= DetailModel.Quantity)
                    {
                        return BadRequest("Adjust Quantity for "+ product.ProductName+" the remaining quantity is "+ product.Quantity);
                    }
                }
                //create a sale header
                SaleHeader saleHeader = new SaleHeader();
                saleHeader.InvoiceTotal = model.InvoiceTotal;
                saleHeader.InvoiceDate = model.InvoiceDate;
                saleHeader.InvoiceStatus = model.InvoiceStatus;
                saleHeader.CreatedBy = "loggedin user";
                saleHeader.CreatedOn = DateTime.Now;
                var SaleHeaderId =  saleRepo.CreateSaleHeader(saleHeader);
                saleHeader.id = SaleHeaderId;
                for(int x=0; x < model.SaleDetails.Count; x++)
                {
                    
                    var sales = model.SaleDetails.ToArray();
                    SaleDetailsModel DetailModel = sales[x];
                    //get product
                    Product product = productRepo.GetProductByProductCode(DetailModel.ProductCode);
                    SaleDetails saleDetails = new SaleDetails();
                    saleDetails.Product = product;
                    saleDetails.Quantity = DetailModel.Quantity;
                    saleDetails.Price = DetailModel.Price;
                    saleDetails.Total = DetailModel.Total;
                    saleDetails.SaleHeader = saleHeader;
                    var SalesDetailId = saleRepo.CreateSaleDetails(saleDetails);
                    // update product quantity
                    var remainingQuantity = product.Quantity - DetailModel.Quantity;
                    product.Quantity = remainingQuantity;
                    productRepo.Update(product);
                }

                return Ok(SaleHeaderId);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Purchase")]
        public IActionResult PurchaseProduct(PurchaseHeaderModel model)
        {
            try
            {
                //create a purchase header
                PurchaseHeader purchaseHeader = new PurchaseHeader();
                purchaseHeader.PurchaseTotal = model.PurchaseTotal;
                purchaseHeader.PurchaseDate  = model.PurchaseDate;
                purchaseHeader.PurchaseInvoiceStatus = model.PurchaseInvoiceStatus;
                purchaseHeader.CreatedBy = "loggedin user";
                purchaseHeader.CreatedOn = DateTime.Now;
                var PurchaseHeaderId = purchaseRepo.CreatePurchaseHeader(purchaseHeader);
                purchaseHeader.id = PurchaseHeaderId;
                for (int x = 0; x < model.PurchaseDetails.Count; x++)
                {

                    var sales = model.PurchaseDetails.ToArray();
                    PurchaseDetailModel DetailModel = sales[x];
                    //get product
                    Product product = productRepo.GetProductByProductCode(DetailModel.ProductCode);
                    PurchaseDetail purchaseDetails = new PurchaseDetail();
                    purchaseDetails.Product = product;
                    purchaseDetails.Quantity = DetailModel.Quantity;
                    purchaseDetails.Price = DetailModel.Price;
                    purchaseDetails.Total = DetailModel.Total;
                    purchaseDetails.PurchaseHeader = purchaseHeader;
                    var PurchaseDetailId = purchaseRepo.CreatePurchaseDetails(purchaseDetails);
                    // update product quantity
                    var remainingQuantity = product.Quantity + DetailModel.Quantity;
                    product.Quantity = remainingQuantity;
                    productRepo.Update(product);
                }

                return Ok(PurchaseHeaderId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
