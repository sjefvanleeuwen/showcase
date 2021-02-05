namespace dapr.gql.payment.Repositories
{
        public record Payment(int Id, int BasketId, int CustomerId, float Total);
}