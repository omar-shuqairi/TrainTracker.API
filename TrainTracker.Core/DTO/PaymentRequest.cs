using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTracker.Core.DTO
{
    public class PaymentRequest
    {
        public string PaymentMethodId { get; set; }

        public UsersDetailsDto UsersDetails { get; set; }

        public TripDto Trip { get; set; }

    }
}
