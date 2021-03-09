namespace dapr.gql.payment.Repositories
{
    /// <summary>
    /// This is a Order item. Multiple items form the shopping Order for a customer.
    /// </summary>
    public class OrderItem {
        public OrderItem(int OrderItemId, int CustomerId, int ProductId, int Quantity){
            this.OrderItemId = OrderItemId;
            this.CustomerId = CustomerId;
            this.ProductId = ProductId;
            this.Quantity = Quantity;
        }

        /// <summary>
        /// Unique Id of the Order item
        /// </summary>
        /// <value></value>
        public int OrderItemId { get; }
        /// <summary>
        /// Customer to Order item relation
        /// </summary>
        /// <value></value>
        public int CustomerId { get; }
        /// <summary>
        /// Product to Order item relation
        /// </summary>
        /// <value></value>
        public int ProductId { get; }
        /// <summary>
        /// Quantity of the product in the Order item
        /// </summary>
        /// <value></value>
        public int Quantity { get; }
    } 
}