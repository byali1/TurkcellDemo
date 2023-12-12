using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TurkcellDemo.Web.Models;
using TurkcellDemo.Web.ViewModels;

namespace TurkcellDemo.Web.Controllers
{
    public class ProductsController : Controller
    {
        //private readonly ProductRepository _productRepository;
        private readonly TurkcellDbContext _turkcellDbContext;
        private readonly IMapper _mapper;

        public ProductsController(TurkcellDbContext turkcellDbContext, IMapper mapper)
        {
            _turkcellDbContext = turkcellDbContext;
            _mapper = mapper;

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
            return View(_mapper.Map<List<ProductViewModel>>(products));
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

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
            {
                new (){Color="Mavi",Value ="Mavi" },
                new (){Color="Kırmızı",Value ="Kırmızı" },
                new (){Color="Siyah",Value ="Siyah" },
                new (){Color="Standart",Value ="Standart" }

            }, "Value", "Color");

            return View();

        }

        [HttpPost]
        public IActionResult CreateProduct(ProductViewModel newProduct)
        {
            ViewBag.PublishExpireTime = new Dictionary<string, int>()
            {
                { "1 month", 1 },
                { "3 months", 3 },
                { "6 months", 6 },
                { "12 months", 12 }
            };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
            {
                new (){Color="Mavi",Value ="Mavi" },
                new (){Color="Kırmızı",Value ="Kırmızı" },
                new (){Color="Siyah",Value ="Siyah" },
                new (){Color="Standart",Value ="Standart" }

            }, "Value", "Color");


            if (ModelState.IsValid)
            {
                try
                {
                    //throw new Exception("DB hatası");
                    _turkcellDbContext.Products.Add(_mapper.Map<Product>(newProduct));
                    _turkcellDbContext.SaveChanges();

                    TempData["status"] = "Product has been added.";

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(String.Empty, "Bir hata oldu! Daha sonra tekrar dene.");
                    return View("Add");
                }
            }



            return View("Add");




        }


        [AcceptVerbs("GET","POST")]
        public IActionResult HasProductName(string name)
        {
            var anyProduct = _turkcellDbContext.Products.Any(x => x.Name.ToLower() == name.ToLower());

            if (anyProduct)
            {
                return Json("Bu ürün zaten mevcut");
            }

            return Json(true);
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _turkcellDbContext.Products.Find(id);

            ViewBag.PublishExpireValue = product.PublishExpireTime;

            ViewBag.PublishExpireTime = new Dictionary<string, int>()
            {
                { "1 month", 1 },
                { "3 months", 3 },
                { "6 months", 6 },
                { "12 months", 12 }
            };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
            {
                new (){Color="Mavi",Value ="Mavi" },
                new (){Color="Kırmızı",Value ="Kırmızı" },
                new (){Color="Siyah",Value ="Siyah" },
                new (){Color="Standart",Value ="Standart" }

            }, "Value", "Color", product.Color);

            return View(_mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        public IActionResult UpdateProduct(ProductViewModel updateProduct)
        {

            if (!ModelState.IsValid)
            {
               
                ViewBag.PublishExpireTime = new Dictionary<string, int>()
                {
                    { "1 month", 1 },
                    { "3 months", 3 },
                    { "6 months", 6 },
                    { "12 months", 12 }
                };

                ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
                {
                    new (){Color="Mavi",Value ="Mavi" },
                    new (){Color="Kırmızı",Value ="Kırmızı" },
                    new (){Color="Siyah",Value ="Siyah" },
                    new (){Color="Standart",Value ="Standart" }

                }, "Value", "Color", updateProduct.Color);
            }

            _turkcellDbContext.Products.Update(_mapper.Map<Product>(updateProduct));
            _turkcellDbContext.SaveChanges();

            TempData["status"] = "Product has been updated.";

            return RedirectToAction("Index");

        }
    }
}
