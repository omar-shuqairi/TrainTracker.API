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
    public class StationsService : IStationsService
    {
        private readonly IStationsRepository _stationsRepository;

        public StationsService(IStationsRepository stationsRepository)
        {
            _stationsRepository = stationsRepository;
        }

        public void CreateStation(Station station)
        {
            _stationsRepository.CreateStation(station);
        }

        public void DeleteStation(int id)
        {
            _stationsRepository.DeleteStation(id);
        }

        public List<Station> GetAllStations()
        {
            return _stationsRepository.GetAllStations();
        }


        public Station GetStationById(int id)
        {
            return _stationsRepository.GetStationById(id);
        }

        public void UpdateStation(Station station)
        {
            _stationsRepository.UpdateStation(station);
        }
        public int GetCountOfStations()
        {
            return _stationsRepository.GetCountOfStations();
        }

        public List<Station> SearchStationsByName(string name)
        {
            return _stationsRepository.SearchStationsByName(name);
        }
    }
}
