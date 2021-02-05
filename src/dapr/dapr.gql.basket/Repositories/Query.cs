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
        /// Gets all customers
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        public IEnumerable<BasketItem> GetBasket([Service] BasketRepository repository) =>
            repository.GetBasket();
        /// <summary>
        /// Gets a customer by unique identity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public BasketItem GetCustomer(int id, [Service] BasketRepository repository) => 
            repository.GetBasketItem(id);
    }
}