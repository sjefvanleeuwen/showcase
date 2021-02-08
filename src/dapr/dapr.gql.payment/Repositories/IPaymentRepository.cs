using System.Collections.Generic;

namespace dapr.gql.payment.Repositories
{
    public interface IPaymentRepository
    {
        Payment GetPayment(int id);
        IEnumerable<Payment> GetPayments();
    }
}