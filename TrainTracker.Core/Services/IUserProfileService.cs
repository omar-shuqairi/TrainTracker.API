using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;

namespace TrainTracker.Core.Services
{
    public interface IUserProfileService
    {
        List<UserProfile> GetAllUsersProfile();
        void CreateUserProfile(UserProfile userProfile);
        void UpdateUserProfile(UserProfile userProfile);
        void DeleteUserProfile(int id);
        UserProfile GetUserProfileById(int id);
    }
}
