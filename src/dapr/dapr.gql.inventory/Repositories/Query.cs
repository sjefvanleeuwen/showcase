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
        /// Gets all invtory items
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        public IEnumerable<Inventory> Get([Service] InventoryRepository repository) =>
            repository.Get();
        /// <summary>
        /// Gets a an inventory item for a specific product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public Inventory GetInventory(int id, [Service] InventoryRepository repository) => 
            repository.Get(id);
    }
}