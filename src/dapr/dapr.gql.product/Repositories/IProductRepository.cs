using System.Collections.Generic;

namespace dapr.gql.product.Repositories
{
    public interface IProductRepository
    {
        Product GetProduct(int id);
        IEnumerable<Product> GetProducts();
    }
}