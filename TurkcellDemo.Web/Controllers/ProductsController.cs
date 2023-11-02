﻿using Microsoft.AspNetCore.Mvc;
using TurkcellDemo.Web.Models;

namespace TurkcellDemo.Web.Controllers
{
    public class ProductsController : Controller
    {
        //private readonly ProductRepository _productRepository;
        private readonly TurkcellDbContext _turkcellDbContext;

        public ProductsController(TurkcellDbContext turkcellDbContext)
        {
            _turkcellDbContext = turkcellDbContext;

            if (!_turkcellDbContext.Products.Any())
            {
                string productName = "Telefon 1";
                int productNo = 1;
                int productPrice = 80000;
                int productStock = 210;


                for (int i = 0; i < 30; i++)
                {
                    _turkcellDbContext.Products.Add(new()
                    {
                        Name = productName,
                        Price = productPrice,
                        Stock = productStock,
                        Color = "Siyah"

                    });
                    productPrice += 100;
                    productStock += 10;
                    productNo += 1;
                    productName = $"Telefon {productNo}";
                }

                _turkcellDbContext.SaveChanges();
            }
        }

        public IActionResult Index()
        {
            var products = _turkcellDbContext.Products.ToList();
            return View(products);
        }

        public IActionResult DeleteProduct(int id)
        {
            var product = _turkcellDbContext.Products.Find(id);

            if (product != null)
            {
                _turkcellDbContext.Products.Remove(product);
                _turkcellDbContext.SaveChanges();
                TempData["status"] = "Product has been deleted.";
            }


            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.PublishExpireTime = new Dictionary<string, int>()
            {
                { "1 month", 1 },
                { "3 months", 3 },
                { "6 months", 6 },
                { "12 months", 12 }
            };
            return View();

        }

        [HttpPost]
        public IActionResult CreateProduct(Product newProduct)
        {

            _turkcellDbContext.Products.Add(newProduct);
            _turkcellDbContext.SaveChanges();

            TempData["status"] = "Product has been added.";

            return RedirectToAction("Index");

        }



        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _turkcellDbContext.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product updateProduct)
        {
            _turkcellDbContext.Products.Update(updateProduct);
            _turkcellDbContext.SaveChanges();

            TempData["status"] = "Product has been updated.";

            return RedirectToAction("Index");

        }
    }
}
