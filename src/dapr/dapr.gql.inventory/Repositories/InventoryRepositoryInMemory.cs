using System.Collections.Generic;
using System.Linq;

namespace dapr.gql.inventory.Repositories
{

    public class InventoryRepositoryInMemory : IInventoryRepository
    {
        private Dictionary<int, Inventory> _inventory;

        public InventoryRepositoryInMemory()
        {
            _inventory = new Inventory[]
            {
                new Inventory(1, 50),
                new Inventory(2, 100)
            }.ToDictionary(t => t.ProductId);
        }

        public Inventory Get(int productId) => _inventory[productId];
        public IEnumerable<Inventory> Get() => _inventory.Values;
        public void Set(Inventory product) => _inventory[product.ProductId] = product;
    }
}