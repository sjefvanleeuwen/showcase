using System.Collections.Generic;

namespace dapr.gql.basket.Repositories
{
    public interface IBasketRepository
    {
        BasketItem Add(BasketItem item);
        IEnumerable<BasketItem> GetBasket(int basketId);
        IEnumerable<BasketItem> GetBasketForCustomer(int customerId);
        BasketItem GetBasketItem(int id);
        IEnumerable<BasketItem> GetBaskets();
        void Remove(int id);
        void Update(BasketItem item);
    }

}