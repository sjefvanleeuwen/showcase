namespace dapr.gql.product.Repositories
{
    // C# 9.0 records are supported by the compiler, but not yet by the XML documenter.
    // The XML documenter is needed by GraphQL Hot Chocolate to document your entities.
    // public record Product(int ProductId, string Name, string Description, float UnitPrice);

    /// <summary>
    /// Describes a product in detail
    /// </summary>
    public class Product{
        public Product(int productId, string name, string description, float unitPrice){
            ProductId = productId;
            Name = name;
            Description = description;
            UnitPrice = unitPrice;
        }

        /// <summary>
        /// The unique identifier for the product
        /// </summary>
        /// <value></value>
        public int ProductId { get; }
        /// <summary>
        /// The product name / title of the product
        /// </summary>
        /// <value></value>
        public string Name { get; }
        /// <summary>
        /// The description of the product
        /// </summary>
        /// <value></value>
        public string Description { get; }
        /// <summary>
        /// The unit price for the product
        /// </summary>
        /// <value></value>
        public float UnitPrice { get; }
    }
}