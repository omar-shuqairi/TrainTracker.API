using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTracker.Core.DTO
{
    public class ReportDto
    {
        public string Period { get; set; }
        public int UsersCount { get; set; }
        public int ReservationsCount { get; set; }
    }
}
