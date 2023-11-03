namespace TurkcellDemo.Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Color { get; set; }
        public bool IsPublish { get; set; } = false;
        public int PublishExpireTime { get; set; }
        public string? Description { get; set; }
        public DateTime? PublishedTime{ get; set; }


    }
}
