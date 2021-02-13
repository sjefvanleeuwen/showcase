using Dapr.Client;
using HotChocolate;
using Microsoft.AspNetCore.Mvc;

namespace dapr.gql.basket.Repositories
{
    /// <summary>
    /// GraphQL Command Schema for Baskets
    /// </summary>
    public class Command {
        /// <summary>
        /// Update or insert a product item in the customers shopping basket
        /// </summary>
        /// <param name="repository">The repository where this item is stored</param>
        /// <param name="item">The product item to upsert</param>
        /// <returns></returns>
        public BasketItem UpsertItemToBasket(BasketItem item, [Service] IBasketRepository repository)=> repository.Add(item);
        /// <summary>
        /// Removes a product item from the customers shopping basket
        /// </summary>
        /// <param name="basketItemId">The unique identifier of the basket item</param>
        /// <param name="repository">The repository where this item is stored</param>
        public void RemoveItemFromBasket(int basketItemId, [Service] IBasketRepository repository)
        {
            repository.Remove(basketItemId);
            //daprClient.de
        }
    }
}