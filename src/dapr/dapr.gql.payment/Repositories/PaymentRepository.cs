using System.Collections.Generic;
using System.Linq;

namespace dapr.gql.payment.Repositories
{
    public class PaymentRepository {
        private Dictionary<int, Payment> _payments;

        public PaymentRepository()
        {
            _payments = new Payment[]
            {
                new Payment(1, 1, 1, 1.50f),
                new Payment(2, 2, 1, 5.00f),
            }.ToDictionary(t => t.Id);
        }

        public Payment GetPayment(int id) => _payments[id];
        public IEnumerable<Payment> GetPayments() => _payments.Values;
    }
}