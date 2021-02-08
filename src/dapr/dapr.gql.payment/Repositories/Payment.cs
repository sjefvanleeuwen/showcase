namespace dapr.gql.payment.Repositories
{
        // C# 9.0 records are supported by the compiler, but not yet by the XML documenter.
        // The XML documenter is needed by GraphQL Hot Chocolate to document your entities.
        //public record Payment(int Id, int BasketId, int CustomerId, float Total);
        public class Payment {
                public Payment(int paymentId, int basketId, int customerId, float total) {
            PaymentId = paymentId;
            BasketId = basketId;
            CustomerId = customerId;
            Total = total;
        }

        /// <summary>
        /// Unique field for the payment transaction
        /// </summary>
        /// <value></value>
        public int PaymentId { get; }
        /// <summary>
        /// The relationship with the basket containing the product items for purchase
        /// </summary>
        /// <value></value>
        public int BasketId { get; }
        /// <summary>
        /// The relationship with the customer who is purchasing the product items
        /// </summary>
        /// <value></value>
        public int CustomerId { get; }
        /// <summary>
        /// The total amount due in payment for the order
        /// </summary>
        /// <value></value>
        public float Total { get; }
    }
}