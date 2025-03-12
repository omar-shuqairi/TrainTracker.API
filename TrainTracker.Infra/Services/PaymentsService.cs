using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;
using TrainTracker.Core.Repository;
using TrainTracker.Core.Services;

namespace TrainTracker.Infra.Services
{
    public class PaymentsService : IPaymentsService
    {
        private readonly IPaymentsRepository _paymentsRepository;

        public PaymentsService(IPaymentsRepository paymentsRepository)
        {
            _paymentsRepository = paymentsRepository;
        }
        public void CreatePayment(Payment payment)
        {
            _paymentsRepository.CreatePayment(payment);
        }

        public void DeletePayment(int id)
        {
            _paymentsRepository.DeletePayment(id);
        }

        public List<Payment> GetAllPayments()
        {
            return _paymentsRepository.GetAllPayments();
        }

        public Payment GetPaymentById(int id)
        {
            return _paymentsRepository.GetPaymentById(id);
        }

        public void UpdatePayment(Payment payment)
        {
            _paymentsRepository.UpdatePayment(payment);
        }
    }
}
