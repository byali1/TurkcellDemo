namespace TurkcellDemo.Web.Models
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>()
        {
            new()
            {
                Id = 1,
                Name = "Telefon",
                Price = 20,
                Stock = 100
            },
            new(){
            Id = 2,
            Name = "Monitor 4K",
            Price = 20000,
            Stock = 200
                }
        };

        public List<Product> GetAll() => _products;

        public void Add(Product product) => _products.Add(product);

        public void Delete(int id)
        {
            var hasProduct = _products.FirstOrDefault(p => p.Id == id);
            if (hasProduct == null)
            {
                throw new Exception($"{id} id no'lu ürün bulunmamaktadır.");

            }

            _products.Remove(hasProduct);
        }

        public void Update(Product updateProduct)
        {
            var hasProduct = _products.FirstOrDefault(p => p.Id == updateProduct.Id);
            if (hasProduct == null)
            {
                throw new Exception($"{updateProduct.Id} id no'lu ürün bulunmamaktadır.");

            }
            hasProduct.Name = updateProduct.Name;
            hasProduct.Price = updateProduct.Price;
            hasProduct.Stock = updateProduct.Stock;

            var index = _products.FindIndex(p => p.Id == updateProduct.Id);
            _products[index] = hasProduct;


        }

    }
}
