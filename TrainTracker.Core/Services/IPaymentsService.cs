using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;

namespace TrainTracker.Core.Services
{
    public interface IPaymentsService
    {
        List<Payment> GetAllPayments();
        void CreatePayment(Payment payment);
        void UpdatePayment(Payment payment);
        void DeletePayment(int id);
        Payment GetPaymentById(int id);
    }
}
