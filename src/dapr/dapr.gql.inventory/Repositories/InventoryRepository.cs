using System.Collections.Generic;
using System.Linq;

namespace dapr.gql.inventory.Repositories
{
    public class InventoryRepository {
        private Dictionary<int, Inventory> _customers;

        public InventoryRepository()
        {
            _customers = new Inventory[]
            {
                new Inventory(1, 50),
                new Inventory(2, 100)
            }.ToDictionary(t => t.ProductId);
        }

        public Inventory GetProduct(int id) => _customers[id];
        public IEnumerable<Inventory> GetProducts() => _customers.Values;
    }
}