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
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly IDbContext _dbContext;
        public UserProfileRepository(IDbContext dbContext)
        {

            _dbContext = dbContext;

        }
        public void CreateUserProfile(UserProfile userProfile)
        {
            var p = new DynamicParameters();
            p.Add("p_First_Name", userProfile.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Last_Name", userProfile.LastName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Gender", userProfile.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Date_Of_Birth", userProfile.DateOfBirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_Profile_Image", userProfile.ProfileImage, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_City", userProfile.City, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_User_ID", userProfile.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("UserProfile_PKG.CreateProfile", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteUserProfile(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Profile_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("UserProfile_PKG.DeleteProfile", p, commandType: CommandType.StoredProcedure);
        }

        public List<UserProfile> GetAllUsersProfile()
        {
            IEnumerable<UserProfile> result = _dbContext.Connection.Query<UserProfile>
             ("UserProfile_PKG.GetAllProfiles", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public UserProfile GetUserProfileById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Profile_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<UserProfile> result = _dbContext.Connection.Query<UserProfile>
               ("UserProfile_PKG.GetProfileById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateUserProfile(UserProfile userProfile)
        {
            var p = new DynamicParameters();
            p.Add("p_Profile_ID", userProfile.ProfileId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_First_Name", userProfile.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Last_Name", userProfile.LastName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Gender", userProfile.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Date_Of_Birth", userProfile.DateOfBirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_Profile_Image", userProfile.ProfileImage, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_City", userProfile.City, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_User_ID", userProfile.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("UserProfile_PKG.UpdateProfile", p, commandType: CommandType.StoredProcedure);
        }
    }
}
