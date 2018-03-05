using InventoryManagment.Models;
using System.Collections.Generic;

namespace InventoryManagment.Services
{
    public interface IInventoryDatabase
    {
        IEnumerable<InventoryModel> GetAllProduct();
        InventoryModel GetProduct(int id);
        void AddProduct(string name, double price, int quantity, ProductType type);
        void DeleteProduct(InventoryModel model);
        void UpdateProduct(int id, string name, double price, int quantity, ProductType type);
    }
}
