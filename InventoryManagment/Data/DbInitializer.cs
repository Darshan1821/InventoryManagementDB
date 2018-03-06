using InventoryManagment.Models;
using InventoryManagment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagment.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IInventoryDatabase context)
        {

            if (context.GetAllProduct().ToList().Count != 0)
            {
                return;
            }

            var productList = new List<InventoryModel>()
            {
                new InventoryModel() { Name="Lettuce", Price=10.5, Quantity=50, Type = ProductType.LeafyGreen },
                new InventoryModel() { Name="Cabbage", Price=20, Quantity=100, Type = ProductType.Cruciferous },
                new InventoryModel() { Name="Pumpkin", Price=30, Quantity=30, Type = ProductType.Marrow },
                new InventoryModel() { Name="Cauliflower", Price=10, Quantity=25, Type = ProductType.Cruciferous },
                new InventoryModel() { Name="Zucchini", Price=20.5, Quantity=50, Type = ProductType.Marrow },
                new InventoryModel() { Name="Yam", Price=30, Quantity=50, Type = ProductType.Root },
                new InventoryModel() { Name="Spinach", Price=10, Quantity=100, Type = ProductType.LeafyGreen },
                new InventoryModel() { Name="Broccoli", Price=20.2, Quantity=75, Type = ProductType.Cruciferous },
                new InventoryModel() { Name="Garlic", Price=30, Quantity=20, Type = ProductType.LeafyGreen },
                new InventoryModel() { Name="Silverbeet", Price=10, Quantity=50, Type = ProductType.Marrow }
            };

            foreach (InventoryModel p in productList)
            {
                context.AddProduct(p.Name, p.Price, p.Quantity, p.Type);
            }
        }
    }

}
