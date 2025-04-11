using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTracker.Core.DTO
{
    public class TripDto
    {
        public int Trip_ID { get; set; }
        public DateTime Departure_Time { get; set; }
        public decimal Ticket_Price { get; set; }
        public string Trip_Description { get; set; }
        public string Start_Station_Name { get; set; }
        public string Start_City { get; set; }
        public string Start_Area { get; set; }
        public string End_Station_Name { get; set; }
        public string End_City { get; set; }
        public string End_Area { get; set; }
        public string Route_Number { get; set; }
        public int Train_ID { get; set; }

        public int TotalSeatCapacity { get; set; }

        public int Start_Station_ID { get; set; }

        public int End_Station_ID { get; set; }


    }
}
