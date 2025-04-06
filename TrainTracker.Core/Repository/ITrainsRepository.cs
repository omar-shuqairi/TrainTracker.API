﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;

namespace TrainTracker.Core.Repository
{
    public interface ITrainsRepository
    {
        List<Train> GetAllTrains();
        void CreateTrain(Train train);
        void UpdateTrain(Train train);
        void DeleteTrain(int id);
        Train GetTrainById(int id);
        void UpdateSeatCapacity(int id);
    }
}
