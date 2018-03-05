using InventoryManagment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
