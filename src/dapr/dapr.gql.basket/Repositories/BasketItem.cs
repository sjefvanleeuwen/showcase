namespace dapr.gql.basket.Repositories
{
    public record BasketItem(int Id, int CustomerId, string ProductId, int Quantity);
}