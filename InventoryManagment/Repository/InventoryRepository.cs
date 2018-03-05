using System.Collections.Generic;
using InventoryManagment.Models;
using InventoryManagment.Services;

namespace InventoryManagment.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private IInventoryDatabase database;

        public InventoryRepository(IInventoryDatabase inventoryDatabase)
        {
            database = inventoryDatabase;
        }

        public void AddProduct(string name, double price, int quantity, ProductType type)
        {
            database.AddProduct(name,price,quantity,type);
        }

        public void DeleteProduct(int id)
        {
            var product = database.GetProduct(id);
            database.DeleteProduct(product);
        }

        public void UpdateProduct(int id, string name, double price, int quantity, ProductType type)
        {
            database.UpdateProduct(id,name,price,quantity,type);
        }

        public IEnumerable<InventoryModel> GetAllProduct()
        {
            return database.GetAllProduct();
        }

        public InventoryModel GetProduct(int id)
        {
            return database.GetProduct(id);
        }
    }
}
