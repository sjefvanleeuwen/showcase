namespace dapr.gql.basket.Repositories
{
    /// <summary>
    /// This is a basket item.
    /// </summary>
    /// <param name="Id">Unieuq Id of the basket item</param>
    /// <param name="CustomerId">Customer Id this basket belongs to</param>
    /// <param name="ProductId">The product Id in this basket item</param>
    /// <param name="Quantity">The quantity selected</param>
    /// <returns></returns>
    public record BasketItem(int Id, int CustomerId, int ProductId, int Quantity);
}