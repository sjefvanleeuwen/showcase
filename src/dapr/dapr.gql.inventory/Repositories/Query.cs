using System.Collections.Generic;
using HotChocolate;

namespace dapr.gql.inventory.Repositories
{
    /// <summary>
    /// GraphQL Query Schema for Customers
    /// </summary>
    public class Query
    {
        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        public IEnumerable<Inventory> GetCustomers([Service] InventoryRepository repository) =>
            repository.GetProducts();
        /// <summary>
        /// Gets a customer by unique identity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public Inventory GetCustomer(int id, [Service] InventoryRepository repository) => 
            repository.GetProduct(id);
    }
}