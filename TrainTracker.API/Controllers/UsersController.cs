using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTracker.Core.Data;
using TrainTracker.Core.Services;
using TrainTracker.Infra.Services;

namespace TrainTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public List<User> GetAllUsers()
        {
            return _usersService.GetAllUsers();
        }

        [HttpGet]
        [Route("getbyId/{id}")]
        public User GetUserById(int id)
        {
            return _usersService.GetUserById(id);
        }


        [HttpPost]
        public void CreateUser(User user)
        {
            _usersService.CreateUser(user);
        }

        [HttpPut]
        public void UpdateUser(User user)
        {
            _usersService.UpdateUser(user);
        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]

        public void DeleteUser(int id)
        {
            _usersService.DeleteUser(id);
        }

    }
}
