using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;

namespace TrainTracker.Core.Services
{
    public interface IJWTService
    {
        string Auth(User user);
    }
}
