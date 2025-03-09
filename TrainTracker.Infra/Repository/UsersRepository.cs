using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Common;
using TrainTracker.Core.Data;
using TrainTracker.Core.Repository;

namespace TrainTracker.Infra.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IDbContext _dbContext;
        public UsersRepository(IDbContext dbContext)
        {

            _dbContext = dbContext;

        }
        public void CreateUser(User user)
        {
            var p = new DynamicParameters();
            p.Add("p_Email", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Password", user.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Role_ID", user.RoleId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Users_PKG.CreateUser", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_User_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Users_PKG.DeleteUser", p, commandType: CommandType.StoredProcedure);
        }

        public List<User> GetAllUsers()
        {
            IEnumerable<User> result = _dbContext.Connection.Query<User>
               ("Users_PKG.GetAllUsers", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public User GetUserById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_User_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<User> result = _dbContext.Connection.Query<User>
               ("Users_PKG.GetUserById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateUser(User user)
        {
            var p = new DynamicParameters();
            p.Add("p_User_ID", user.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Email", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Password", user.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Role_ID", user.RoleId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Users_PKG.UpdateUser", p, commandType: CommandType.StoredProcedure);
        }
    }
}
