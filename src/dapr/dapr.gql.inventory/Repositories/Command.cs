using HotChocolate;

namespace dapr.gql.inventory.Repositories
{
    /// <summary>
    /// Primarily used by basket service, to request a reservation in quantiy.
    /// </summary>
    /// <param name="ProductId">The Id of the product</param>
    /// <param name="Quantity">The requested items to reserve, the request can be negative to liberate items.</param>
    /// <returns></returns>
    public record ReserveQuantityRequest(int ProductId, int Quantity);
    /// <summary>
    /// Used by the inventory service, to response with the actual reserved quantity of a product
    /// </summary>
    /// <param name="ProductId"></param>
    /// <param name="Quantity">The amount of items that are available after reservation.</param>
    /// <returns></returns>
    public record ReserveQuantityResponse(int ProductId, int Quantity);
    /// <summary>
    /// GraphQL Command Schema for Inventory
    /// </summary>
    public class Command {
        public ReserveQuantityResponse Reserve(ReserveQuantityRequest request, [Service] IInventoryRepository repository)
        {
            var product = repository.Get(request.ProductId);
            product.Quantity -= request.Quantity;
            repository.Set(product);
            return new ReserveQuantityResponse(product.ProductId, product.Quantity);
        }
    }
}