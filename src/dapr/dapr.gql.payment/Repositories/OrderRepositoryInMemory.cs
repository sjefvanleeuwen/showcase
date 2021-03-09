using System.Collections.Generic;
using System.Linq;

namespace dapr.gql.payment.Repositories
{

    public class OrderRepositoryInMemory : IOrderRepository
    {
        private Dictionary<int, OrderItem> _Order { get; set; }
        public OrderRepositoryInMemory()
        {
            _Order = new OrderItem[]
            {
                new OrderItem(1, 1, 1, 2),
                new OrderItem(2, 1, 2, 3),
            }.ToDictionary(t => t.OrderItemId);
        }

        #region Queries

        public IEnumerable<OrderItem> GetOrderForCustomer(int customerId) => _Order.Where(t => t.Value.CustomerId == customerId).Select(t => t.Value);
        public OrderItem GetOrderItem(int id) => _Order[id];
        public IEnumerable<OrderItem> GetOrders() => _Order.Values;
        public IEnumerable<OrderItem> GetOrder(int OrderId) => _Order.Values;
        #endregion

        #region Commands
        public OrderItem Add(OrderItem item)
        {
            if (_Order.ContainsKey(item.OrderItemId))
            {
                _Order[item.OrderItemId] = item;
            }
            else
            {
                _Order.Add(item.OrderItemId, item);
            }
            return item;
        }

        public void Remove(int id) => _Order.Remove(id);
        public void Update(OrderItem item) => _Order[item.OrderItemId] = item;
        #endregion
    }

}