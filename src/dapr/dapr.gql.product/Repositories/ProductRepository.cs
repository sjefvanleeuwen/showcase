using System.Collections.Generic;
using System.Linq;

namespace dapr.gql.product.Repositories
{
    public class ProductRepository {
        private Dictionary<int, Product> _products;

        public ProductRepository()
        {
            _products = new Product[]
            {
                new Product(1, "Milk", "Some Milk", 1.50f),
                new Product(1, "Cheese", "Some Cheese", 2.50f),
            }.ToDictionary(t => t.ProductId);
        }

        public Product GetProduct(int id) => _products[id];
        public IEnumerable<Product> GetProducts() => _products.Values;
    }
}