using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TurkcellDemo.Web.Models;
using TurkcellDemo.Web.ViewModels;

namespace TurkcellDemo.Web.Views.Shared.ViewComponents
{
    public class VisitorViewComponent : ViewComponent
    {

        private readonly TurkcellDbContext _turkcellDbContext;
        private readonly IMapper _mapper;

        public VisitorViewComponent(TurkcellDbContext turkcellDbContext, IMapper mapper)
        {
            _turkcellDbContext = turkcellDbContext;
            _mapper = mapper;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {

            var visitors = _turkcellDbContext.Visitors.ToList();
            var visitorViewModels = _mapper.Map<List<VisitorViewModel>>(visitors);

            ViewBag.visitorViewModels = visitorViewModels;
            return View();
        }
    }
}