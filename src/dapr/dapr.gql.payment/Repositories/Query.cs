using System.Collections.Generic;
using HotChocolate;

namespace dapr.gql.payment.Repositories
{
    /// <summary>
    /// GraphQL Query Schema for Products
    /// </summary>
    public class Query
    {
        /// <summary>
        /// Gets all Payments
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        public IEnumerable<Payment> GetPayments([Service] IPaymentRepository repository) =>
            repository.GetPayments();
        /// <summary>
        /// Gets a Product by unique identity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public Payment GetProduct(int id, [Service] IPaymentRepository repository) => 
            repository.GetPayment(id);
    }
}