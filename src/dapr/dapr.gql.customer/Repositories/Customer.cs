using System;

namespace dapr.gql.customer.Repositories
{
    public record Customer(int Id, string Name, DateTime Birthdate, string Username);
}