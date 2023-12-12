using AutoMapper;
using TurkcellDemo.Web.Models;
using TurkcellDemo.Web.ViewModels;

namespace TurkcellDemo.Web.Mapping
{
    public class ViewModelMapping:Profile
    {
        public ViewModelMapping()
        {
            //Product'ı , ProductViewModel'a çevir. (Ya da tam tersi)
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Visitor, VisitorViewModel>().ReverseMap();
        }
    }
}
