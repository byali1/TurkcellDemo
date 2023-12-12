using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace TurkcellDemo.Web.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

       // [Remote(action: "HasProductName", controller:"Products")]
        [Required(ErrorMessage = "İsim boş olamaz.")]
        public string? Name { get; set; }


        [Required(ErrorMessage = "Fiyat boş olamaz.")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Stok boş olamaz.")]
        public int? Stock { get; set; }
        [Required(ErrorMessage = "Renk boş olamaz.")]

        public string? Color { get; set; }
        public bool IsPublish { get; set; } = false;

        [Required(ErrorMessage = "Yayınlanma süresi boş olamaz.")]
        public int? PublishExpireTime { get; set; }
        [Required(ErrorMessage = "Açıklama boş olamaz.")]

        public string? Description { get; set; }

        [Required(ErrorMessage = "Yayınlanma tarihi boş olamaz.")]
        public DateTime? PublishedTime { get; set; }
    }
}
