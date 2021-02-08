using System.Collections.Generic;
using HotChocolate;

namespace dapr.gql.customer.Repositories
{
    /// <summary>
    /// GraphQL Query Schema for Customers
    /// </summary>
    public class Query
    {
        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        public IEnumerable<Customer> GetCustomers([Service] ICustomerRepository repository) =>
            repository.GetUsers();
        /// <summary>
        /// Gets a customer by unique identity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public Customer GetCustomer(int id, [Service] ICustomerRepository repository) => 
            repository.GetUser(id);
    }
}