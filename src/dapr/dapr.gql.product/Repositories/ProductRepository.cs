using System.Collections.Generic;
using System.Linq;

namespace dapr.gql.product.Repositories
{

    public class ProductRepositoryInMemory : IProductRepository
    {
        private Dictionary<int, Product> _products;

        public ProductRepositoryInMemory()
        {
            _products = new Product[]
            {
                new Product(1, "Milk", "Some Milk", 1.50f),
                new Product(2, "Cheese", "Some Cheese", 2.50f),
            }.ToDictionary(t => t.ProductId);
        }

        public Product GetProduct(int id) => _products[id];
        public IEnumerable<Product> GetProducts() => _products.Values;
    }
}