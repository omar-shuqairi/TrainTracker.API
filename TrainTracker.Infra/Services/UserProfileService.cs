using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;
using TrainTracker.Core.DTO;
using TrainTracker.Core.Repository;
using TrainTracker.Core.Services;
using TrainTracker.Infra.Repository;

namespace TrainTracker.Infra.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileService(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }
        public void CreateUserProfile(UserProfile userProfile)
        {
            _userProfileRepository.CreateUserProfile(userProfile);
        }

        public void DeleteUserProfile(int id)
        {
            _userProfileRepository.DeleteUserProfile(id);
        }

        public List<UserProfile> GetAllUsersProfile()
        {
            return _userProfileRepository.GetAllUsersProfile();
        }

        public UserProfile GetUserProfileById(int id)
        {
            return _userProfileRepository.GetUserProfileById(id);
        }


        public void UpdateUserProfile(UserProfile userProfile)
        {
            _userProfileRepository.UpdateUserProfile(userProfile);
        }
        public Task<int> RegisterUserAsync(RegisterDto Registeruser)
        {
            return _userProfileRepository.RegisterUserAsync(Registeruser);
        }
    }
}
