using InventoryManagment.Models;
using System.Collections.Generic;

namespace InventoryManagment.Repository
{
    public interface IInventoryRepository
    {
        IEnumerable<InventoryModel> GetAllProduct();
        InventoryModel GetProduct(int id);
        void AddProduct(string name, double price, int quantity, ProductType type);
        void DeleteProduct(int id);
        void UpdateProduct(int id, string name, double price, int quantity, ProductType type);
    }
}
