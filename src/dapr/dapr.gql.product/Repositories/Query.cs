using System.Collections.Generic;
using HotChocolate;

namespace dapr.gql.product.Repositories
{
    /// <summary>
    /// GraphQL Query Schema for Products
    /// </summary>
    public class Query
    {
        /// <summary>
        /// Gets all Products
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts([Service] IProductRepository repository) =>
            repository.GetProducts();
        /// <summary>
        /// Gets a Product by unique identity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public Product GetProduct(int id, [Service] IProductRepository repository) => 
            repository.GetProduct(id);
    }
}