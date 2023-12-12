using Microsoft.AspNetCore.Razor.TagHelpers;
using TurkcellDemo.Web.Models;

namespace TurkcellDemo.Web.TagHelpers
{
    public class ProductShowTagHelper : TagHelper
    {
        public Product Product { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div"; //bu div içine al
            output.Content.SetHtmlContent(@$"<ul class='list-group'> 
                <li class='list-group-item'>{Product.Id}</li>   
                <li class='list-group-item'>{Product.Name}</li> 
                <li class='list-group-item'>{Product.Price}</li> 
                <li class='list-group-item'>{Product.Stock}</li> 
</ul>");
        }
    }
}
