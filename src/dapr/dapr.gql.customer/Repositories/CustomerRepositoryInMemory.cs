using System;
using System.Collections.Generic;
using System.Linq;

namespace dapr.gql.customer.Repositories
{

    public class CustomerRepositoryInmemory : ICustomerRepository
    {
        private Dictionary<int, Customer> _customers;

        public CustomerRepositoryInmemory()
        {
            _customers = new Customer[]
            {
                new Customer(1, "Lili Mccartney", new DateTime(1971, 11, 9), "@lili"),
                new Customer(2, "Shane Lovell", new DateTime(1984, 02, 21), "@shane")
            }.ToDictionary(t => t.CustomerId);
        }

        public Customer GetUser(int id) => _customers[id];
        public IEnumerable<Customer> GetUsers() => _customers.Values;
    }
}