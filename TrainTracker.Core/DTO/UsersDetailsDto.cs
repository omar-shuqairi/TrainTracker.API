using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTracker.Core.DTO
{
    public class UsersDetailsDto
    {

        public int User_ID { get; set; }
        public string Email { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Gender { get; set; }
        public DateTime Date_Of_Birth { get; set; }
        public string Profile_Image { get; set; }
        public string City { get; set; }
    }
}
