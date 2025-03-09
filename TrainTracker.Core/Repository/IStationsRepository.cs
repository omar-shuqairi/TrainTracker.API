using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;

namespace TrainTracker.Core.Repository
{
    public interface IStationsRepository
    {
        List<Station> GetAllStations();
        void CreateStation(Station station);
        void UpdateStation(Station station);
        void DeleteStation(int id);
        Station GetStationById(int id);
    }
}
