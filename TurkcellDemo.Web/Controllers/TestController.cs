using Microsoft.AspNetCore.Mvc;

namespace TurkcellDemo.Web.Controllers
{

    public class ExampleData
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var productList = new List<ExampleData>
            {
                new ()
                {
                    Id = 1,Name = "Kalem"
                },
                new ()
                {
                    Id = 2,Name = "Defter A4 Kare 80"
                },
            };


            ViewBag.name = "Ben viewBag name";
            ViewData["age"] = 31;
            ViewData["names"] = new List<string> { "ali", "ahmet", "mustafa" };

            TempData["surname"] = "aslan";

            return View(productList);
        }

        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult ContentResult()
        {
            return Content("Result");
        }

        public IActionResult EmptyResult()
        {
            return new EmptyResult();
        }

        public IActionResult RedirectToHome()
        {
            return RedirectToAction("Index", "Home");
        }
        public IActionResult RedirectById(int id)
        {
            return RedirectToAction("JsonResult", "Test", new { id = id });
        }

        public IActionResult JsonResult(int id)
        {
            return Json(new { Id = id, name = "ali" });
        }



    }
}
