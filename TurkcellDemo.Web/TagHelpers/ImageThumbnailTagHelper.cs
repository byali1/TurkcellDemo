using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TurkcellDemo.Web.TagHelpers
{

    public class ImageThumbnailTagHelper : TagHelper
    {
        public string ImageSrc { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";
            string fileName = ImageSrc.Split(".")[0]; //car
            string fileExtension = Path.GetExtension(ImageSrc); //.jpg
            output.Attributes.SetAttribute("src", $"{fileName}400{fileExtension}");
        }
    }
}
