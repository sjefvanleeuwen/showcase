using System.Collections.Generic;

namespace dapr.gql.customer.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetUser(int id);
        IEnumerable<Customer> GetUsers();
    }
}