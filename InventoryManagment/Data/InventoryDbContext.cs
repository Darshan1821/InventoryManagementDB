using InventoryManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagment.Data
{
    public class InventoryDbContext: DbContext
    {
        public InventoryDbContext(DbContextOptions contextOptions): base(contextOptions)
        {
                
        }

        public DbSet<InventoryModel> Products { get; set; }
    }
}
