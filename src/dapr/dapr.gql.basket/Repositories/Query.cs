using System.Collections.Generic;
using HotChocolate;

namespace dapr.gql.basket.Repositories
{
    /// <summary>
    /// GraphQL Query Schema for Customers
    /// </summary>
    public class Query
    {
        /// <summary>
        /// Gets all baskets
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        public IEnumerable<BasketItem> GetBaskets([Service] BasketRepository repository) =>
            repository.GetBaskets();
        /// <summary>
        /// Gets a basket item for a customer by unique identity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public BasketItem GetBasket(int id, [Service] BasketRepository repository) => 
            repository.GetBasketItem(id);
    }
}