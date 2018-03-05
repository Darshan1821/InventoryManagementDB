using System.Diagnostics;
using System.Linq;
using InventoryManagment.Models;
using InventoryManagment.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagment.Controllers
{
    public class InventoryController : Controller
    {

        public IInventoryRepository IInventoryRepository { get; set; }

        public InventoryController(IInventoryRepository inventoryRepostiory)
        {
            IInventoryRepository = inventoryRepostiory;
        }

        public IActionResult Index()
        {
            var products = IInventoryRepository.GetAllProduct();
            return View(products);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(InventoryModel model)
        {
            if (ModelState.IsValid)
            {
                IInventoryRepository.AddProduct(model.Name, model.Price, model.Quantity, model.Type);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult EditProduct(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Error));
            }
            else
            {
                var product = IInventoryRepository.GetProduct(id);
                return View(product);
            }
        }

        [HttpPost]
        public IActionResult EditProduct(InventoryModel model)
        {
            if (ModelState.IsValid)
            {
                IInventoryRepository.UpdateProduct(model.Id,model.Name, model.Price, model.Quantity, model.Type);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult DeleteProduct(int id)
        {
            if (id < 0)
            {
                return RedirectToAction(nameof(Error));
            }

            IInventoryRepository.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}