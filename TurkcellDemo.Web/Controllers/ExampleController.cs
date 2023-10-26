using Microsoft.AspNetCore.Mvc;

namespace TurkcellDemo.Web.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
