using System.Collections.Generic;

namespace dapr.gql.payment.Repositories
{
    public interface IOrderRepository
    {
        OrderItem Add(OrderItem item);
        IEnumerable<OrderItem> GetOrder(int OrderId);
        IEnumerable<OrderItem> GetOrderForCustomer(int customerId);
        OrderItem GetOrderItem(int id);
        IEnumerable<OrderItem> GetOrders();
        void Remove(int id);
        void Update(OrderItem item);
    }

}