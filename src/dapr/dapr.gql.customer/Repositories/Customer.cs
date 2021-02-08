using System;

namespace dapr.gql.customer.Repositories
{
    // C# 9.0 records are supported by the compiler, but not yet by the XML documenter.
    // The XML documenter is needed by GraphQL Hot Chocolate to document your entities.
    //public record Customer(int Id, string Name, DateTime Birthdate, string Username);

    /// <summary>
    /// Basic customer information
    /// </summary>
    public class Customer{ 
        public Customer(int customerId, string name, DateTime birthdate, string username) {
            this.CustomerId = customerId;
            this.Name = name;
            this.Birthdate = birthdate;
            this.Username = username;
        }

        /// <summary>
        /// Unique identifier for this customer
        /// </summary>
        /// <value></value>
        public int CustomerId { get; }
        /// <summary>
        /// The full name of this customer
        /// </summary>
        /// <value></value>
        public string Name { get; }
        /// <summary>
        /// The date of birth of this customer
        /// </summary>
        /// <value></value>
        public DateTime Birthdate { get; }
        /// <summary>
        /// The login username of this customer
        /// </summary>
        /// <value></value>
        public string Username { get; }
    }
}