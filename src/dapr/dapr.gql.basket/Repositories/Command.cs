using System.Collections.Generic;
using HotChocolate;

namespace dapr.gql.basket.Repositories
{
    /// <summary>
    /// GraphQL Command Schema for Baskets
    /// </summary>
    public class Command {
        /// <summary>
        /// Gets all baskets
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        public BasketItem UpsertItemToBasket(BasketItem item, [Service] BasketRepository repository) {
            return repository.Add(item);
        }
    }
}