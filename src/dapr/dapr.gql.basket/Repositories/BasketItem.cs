using System;

namespace dapr.gql.basket.Repositories
{
    public record BasketItem(int CustomerId, string ProductId, int Quantity);
}