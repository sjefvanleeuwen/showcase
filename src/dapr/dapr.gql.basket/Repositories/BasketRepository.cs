using System.Collections.Generic;
using System.Linq;

namespace dapr.gql.basket.Repositories
{
    public class BasketRepository {
        private Dictionary<int, BasketItem> _basket;

        public BasketRepository()
        {
            _basket = new BasketItem[]
            {
                new BasketItem(1,"1",2),
                new BasketItem(2,"2",3),
            }.ToDictionary(t => t.CustomerId);
        }

        public BasketItem GetBasketItem(int id) => _basket[id];
        public IEnumerable<BasketItem> GetBasket() => _basket.Values;
    }
}