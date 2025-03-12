using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Common;
using TrainTracker.Core.Data;
using TrainTracker.Core.Repository;
using static System.Collections.Specialized.BitVector32;

namespace TrainTracker.Infra.Repository
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly IDbContext _dbContext;
        public PaymentsRepository(IDbContext dbContext)
        {

            _dbContext = dbContext;

        }
        public void CreatePayment(Payment payment)
        {
            var p = new DynamicParameters();
            p.Add("p_Payment_Amount", payment.PaymentAmount, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Payment_Method", payment.PaymentMethod, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Payment_Date", payment.PaymentDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_Ticket_ID", payment.TicketId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_User_ID", payment.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Payments_PKG.CreatePayment", p, commandType: CommandType.StoredProcedure);
        }

        public void DeletePayment(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Payment_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Payments_PKG.DeletePayment", p, commandType: CommandType.StoredProcedure);
        }

        public List<Payment> GetAllPayments()
        {
            IEnumerable<Payment> result = _dbContext.Connection.Query<Payment>
           ("Payments_PKG.GetAllPayments", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Payment GetPaymentById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Payment_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Payment> result = _dbContext.Connection.Query<Payment>
               ("Payments_PKG.GetPaymentById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdatePayment(Payment payment)
        {
            var p = new DynamicParameters();
            p.Add("p_Payment_ID", payment.PaymentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Payment_Amount", payment.PaymentAmount, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Payment_Method", payment.PaymentMethod, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Payment_Date", payment.PaymentDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_Ticket_ID", payment.TicketId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_User_ID", payment.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Payments_PKG.UpdatePayment", p, commandType: CommandType.StoredProcedure);
        }
    }
}
