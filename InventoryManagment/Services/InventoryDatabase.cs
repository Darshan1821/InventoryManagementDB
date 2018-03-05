using InventoryManagment.Data;
using InventoryManagment.Models;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagment.Services
{
    public class InventoryDatabase : IInventoryDatabase
    {
        private InventoryDbContext context;

        public InventoryDatabase(InventoryDbContext dbContext)
        {
            context = dbContext;
        }

        public void AddProduct(string name, double price, int quantity, ProductType type)
        {
            context.Products.Add(new InventoryModel() { Name = name, Price = price, Quantity = quantity, Type = type });
            context.SaveChanges();
        }

        public void DeleteProduct(InventoryModel model)
        {
            context.Products.Remove(model);
            context.SaveChanges();
        }

        public IEnumerable<InventoryModel> GetAllProduct()
        {
            return context.Products.OrderBy(p => p.Id);
        }

        public InventoryModel GetProduct(int id)
        {
            return context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateProduct(int id, string name, double price, int quantity, ProductType type)
        {
            context.Products.Update(new InventoryModel() { Id = id, Name = name, Price = price, Quantity = quantity, Type = type });
            context.SaveChanges();
        }
    }
}
