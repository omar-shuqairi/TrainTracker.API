﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;
using TrainTracker.Core.DTO;

namespace TrainTracker.Core.Repository
{
    public interface IUsersRepository
    {
        List<UsersDetailsDto> GetAllUsers();
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        User GetUserById(int id);
        int GetCountOfUsers();
    }
}
