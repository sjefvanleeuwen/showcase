using System.Collections.Generic;
using System.Linq;

namespace dapr.gql.basket.Repositories
{
    public class BasketRepository
    {
        private Dictionary<int, BasketItem> _basket {get;set;}
        public BasketRepository()
        {
            _basket = new BasketItem[]
            {
                new BasketItem(1, 1,"1",2),
                new BasketItem(1, 2,"2",3),
            }.ToDictionary(t => t.CustomerId);
        }

    #region Queries
        public BasketItem GetBasketItem(int id) => _basket[id];
        public IEnumerable<BasketItem> GetBasket() => _basket.Values;
    #endregion  

    #region Commands
        public void Add(BasketItem item) =>  _basket.Add(item.Id, item);
        public void Remove(int id) => _basket.Remove(id);
        public void Update(BasketItem item) =>  _basket[item.Id] = item;
    #endregion
    }

}