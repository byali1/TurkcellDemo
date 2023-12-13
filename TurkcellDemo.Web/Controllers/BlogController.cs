using Microsoft.AspNetCore.Mvc;

namespace TurkcellDemo.Web.Controllers
{
    public class BlogController : Controller
    {
        //blog/article/makale-ismi/id
        [Route("[controller]/[action]/{articleName}/{id}")]
        public IActionResult Article(string articleName, int id)
        {
            return View();
        }


    }
}
