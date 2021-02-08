namespace dapr.gql.basket.Repositories
{
    /// <summary>
    /// This is a basket item. Multiple items form the shopping basket for a customer.
    /// </summary>
    public class BasketItem {
        public BasketItem(int BaketItemId, int CustomerId, int ProductId, int Quantity){
            this.BasketItemId = BaketItemId;
            this.CustomerId = CustomerId;
            this.ProductId = ProductId;
            this.Quantity = Quantity;
        }

        /// <summary>
        /// Unique Id of the basket item
        /// </summary>
        /// <value></value>
        public int BasketItemId { get; }
        /// <summary>
        /// Customer to basket item relation
        /// </summary>
        /// <value></value>
        public int CustomerId { get; }
        /// <summary>
        /// Product to basket item relation
        /// </summary>
        /// <value></value>
        public int ProductId { get; }
        /// <summary>
        /// Quantity of the product in the basket item
        /// </summary>
        /// <value></value>
        public int Quantity { get; }
    } 
}