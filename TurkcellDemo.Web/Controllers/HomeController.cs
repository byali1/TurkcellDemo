using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;
using TurkcellDemo.Web.Models;
using TurkcellDemo.Web.ViewModels;

namespace TurkcellDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TurkcellDbContext _turkcellDbContext;
        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger, TurkcellDbContext turkcellDbContext, IMapper mapper)
        {
            _logger = logger;
            _turkcellDbContext = turkcellDbContext;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var products = _turkcellDbContext.Products.OrderByDescending(x => x.Id).Select(x => new ProductPartialViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock
            }).ToList();

            ViewBag.productListPartialViewModel = new ProductListPartialViewModel()
            {
                ProductsPartial = products
            };
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Visitor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveVisitorComment(VisitorViewModel visitorViewModel)
        {
            try
            {
                var visitor = _mapper.Map<Visitor>(visitorViewModel);
                visitor.Created = DateTime.UtcNow;

                _turkcellDbContext.Visitors.Add(visitor);
                _turkcellDbContext.SaveChanges();

                TempData["result"] = "[SUCCESSFUL] Your comment has been saved.";
                return RedirectToAction("Visitor");
            }
            catch (Exception)
            {
                TempData["result"] = "[ERROR] Your comment has NOT been saved!";
                return RedirectToAction("Visitor");
            }
        }
    }
}