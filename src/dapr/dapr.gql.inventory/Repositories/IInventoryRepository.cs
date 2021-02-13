using System.Collections.Generic;

namespace dapr.gql.inventory.Repositories
{
    public interface IInventoryRepository
    {
        Inventory Get(int productId);
        IEnumerable<Inventory> Get();
        void Set(Inventory product);
    }
}