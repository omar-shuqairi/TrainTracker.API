﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;
using TrainTracker.Core.DTO;

namespace TrainTracker.Core.Repository
{
    public interface IUserProfileRepository
    {
        List<UserProfile> GetAllUsersProfile();
        void CreateUserProfile(UserProfile userProfile);
        void UpdateUserProfile(UserProfile userProfile);
        void DeleteUserProfile(int id);
        UserProfile GetUserProfileById(int id);

        Task<int> RegisterUserAsync(RegisterDto Registeruser);
    }
}
