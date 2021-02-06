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
        public IEnumerable<BasketItem> GetBaskets() => _basket.Values;
        public IEnumerable<BasketItem> GetBasket(int basketId) => _basket.Values;
    #endregion  

    #region Commands
        public BasketItem Add(BasketItem item) {
            if (_basket.ContainsKey(item.Id)) {
                _basket[item.Id] = item;
            }
            else {
                _basket.Add(item.Id, item);
            }
            return item;
        }
        
        public void Remove(int id) => _basket.Remove(id);
        public void Update(BasketItem item) =>  _basket[item.Id] = item;
    #endregion
    }

}