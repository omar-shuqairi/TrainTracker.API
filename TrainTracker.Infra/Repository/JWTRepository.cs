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
    public class JWTRepository : IJWTRepository
    {


        private readonly IDbContext _dbContext;

        public JWTRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Auth(User user)
        {

            var p = new DynamicParameters();
            p.Add("p_email", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_password", user.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<User>("Login_package.User_Login", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
