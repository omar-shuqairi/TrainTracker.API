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
    public class TrainsService : ITrainsService
    {
        private readonly ITrainsRepository _trainsRepository;

        public TrainsService(ITrainsRepository trainsRepository)
        {
            _trainsRepository = trainsRepository;
        }
        public void CreateTrain(Train train)
        {
            _trainsRepository.CreateTrain(train);
        }

        public void DeleteTrain(int id)
        {
            _trainsRepository.DeleteTrain(id);
        }

        public List<Train> GetAllTrains()
        {
            return _trainsRepository.GetAllTrains();
        }

        public Train GetTrainById(int id)
        {
            return _trainsRepository.GetTrainById(id);
        }

        public void UpdateTrain(Train train)
        {
            _trainsRepository.UpdateTrain(train);
        }
    }
}
