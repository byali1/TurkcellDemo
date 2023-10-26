using Microsoft.AspNetCore.Mvc;
using TurkcellDemo.Web.Models;

namespace TurkcellDemo.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductRepository _productRepository;

        public ProductsController() 
        {
            _productRepository = new ProductRepository();
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }

        public IActionResult DeleteProduct(int id)
        {
           _productRepository.Delete(id);
           return RedirectToAction("Index");

        }
        public IActionResult AddProduct()
        {

            return View();

        }

        public IActionResult UpdateProduct(int id)
        {

            return View();

        }
    }
}
