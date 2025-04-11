﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;
using TrainTracker.Core.DTO;

namespace TrainTracker.Core.Repository
{
    public interface ITripsRepository
    {
        List<TripDto> GetAllTrips();
        void CreateTrip(Trip trip);
        void UpdateTrip(Trip trip);
        void DeleteTrip(int id);
        Trip GetTripById(int id);

        List<TripDto> GetTripsBetweenDates(DateTime? startDate, DateTime? endDate);

        List<TripDto> GetAllTripsUpToDate();
    }
}
