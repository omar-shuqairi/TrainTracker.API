using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;
using TrainTracker.Core.DTO;
using TrainTracker.Core.Repository;
using TrainTracker.Core.Services;

namespace TrainTracker.Infra.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public void CreateUser(User user)
        {
            _usersRepository.CreateUser(user);
        }

        public void DeleteUser(int id)
        {
            _usersRepository.DeleteUser(id);
        }

        public List<UsersDetailsDto> GetAllUsers()
        {
            return _usersRepository.GetAllUsers();
        }

        public UsersDetailsDto GetUserById(int id)
        {
            return _usersRepository.GetUserById(id);
        }

        public void UpdateUser(User user)
        {
            _usersRepository.UpdateUser(user);
        }
        public int GetCountOfUsers()
        {
            return _usersRepository.GetCountOfUsers();
        }

    }
}
