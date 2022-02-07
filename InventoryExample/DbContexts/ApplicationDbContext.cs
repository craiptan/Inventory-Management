using InventoryExample.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryExample.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public DbSet<PurchaseHeader> PurchaseHeaders { get; set; }
        public DbSet<SaleDetails> SaleDetails { get; set; }
        public DbSet<SaleHeader> SaleHeaders { get; set; }
        public DbSet<Customer> Customer { get; set; }
    }
}
