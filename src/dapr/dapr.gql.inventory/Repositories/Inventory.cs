namespace dapr.gql.inventory.Repositories
{
    // C# 9.0 records are supported by the compiler, but not yet by the XML documenter.
    // The XML documenter is needed by GraphQL Hot Chocolate to document your entities.
    //public record Inventory(int ProductId, int Quantity);

    /// <summary>
    /// The inventory holds a list of products and their stock quantities
    /// </summary>
    public class Inventory {
        public Inventory(int productId, int quantity){
            ProductId = productId;
            Quantity = quantity;
        }

        /// <summary>
        /// Unique identifier for the product
        /// </summary>
        /// <value></value>
        public int ProductId { get; }
        /// <summary>
        /// The quantity of stock for the product
        /// </summary>
        /// <value></value>
        public int Quantity { get; set;}
    }
}