using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTracker.Core.Data;
using TrainTracker.Core.Services;
using TrainTracker.Infra.Services;

namespace TrainTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }
        [HttpGet]
        public List<UserProfile> GetAllUsersProfile()
        {
            return _userProfileService.GetAllUsersProfile();
        }

        [HttpGet]
        [Route("getbyId/{id}")]
        public UserProfile GetUserProfileById(int id)
        {
            return _userProfileService.GetUserProfileById(id);
        }


        [HttpPost]
        public void CreateUserProfile(UserProfile userProfile)
        {
            _userProfileService.CreateUserProfile(userProfile);
        }

        [HttpPut]
        public void UpdateUserProfile(UserProfile userProfile)
        {
            _userProfileService.UpdateUserProfile(userProfile);
        }

        [HttpDelete]
        [Route("DeleteUserProfile/{id}")]

        public void DeleteUserProfile(int id)
        {
            _userProfileService.DeleteUserProfile(id);
        }
    }
}
