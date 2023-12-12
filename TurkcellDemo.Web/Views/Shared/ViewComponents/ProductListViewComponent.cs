using Microsoft.AspNetCore.Mvc;
using TurkcellDemo.Web.Models;
using TurkcellDemo.Web.ViewModels;

namespace TurkcellDemo.Web.Views.Shared.ViewComponents
{
    public class ProductListViewComponent : ViewComponent
    {
        private readonly TurkcellDbContext _turkcellDbContext;

        public ProductListViewComponent(TurkcellDbContext turkcellDbContext)
        {
            _turkcellDbContext = turkcellDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(int type=1)
        {
            var viewModels = _turkcellDbContext.Products.Select(x => new ProductListDescriptionComponentViewModel
            {
                Name = x.Name,
                Description = x.Description
            }).ToList();

            if (type == 1)
            {
                return View("Default",viewModels);
            }
            return View("Type2",viewModels);
        }
    }
}
