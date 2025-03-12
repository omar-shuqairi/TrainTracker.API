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
using static System.Collections.Specialized.BitVector32;

namespace TrainTracker.Infra.Repository
{
    public class PageSettingsRepository : IPageSettingsRepository
    {
        private readonly IDbContext _dbContext;

        public PageSettingsRepository(IDbContext dbContext)
        {

            _dbContext = dbContext;

        }
        public void CreatePageSetting(PageSetting pageSetting)
        {
            var p = new DynamicParameters();
            p.Add("p_Logo_URL", pageSetting.LogoUrl, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_About_Us", pageSetting.AboutUs, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Contact_Phone", pageSetting.ContactPhone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Contact_Email", pageSetting.ContactEmail, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Contact_Address", pageSetting.ContactAddress, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Facebook_Link", pageSetting.FacebookLink, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_LinkedIn_Link", pageSetting.LinkedinLink, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Instagram_Link", pageSetting.InstagramLink, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Page_Settings_PKG.CreatePageSetting", p, commandType: CommandType.StoredProcedure);
        }

        public void DeletePageSetting(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Page_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Page_Settings_PKG.DeletePageSetting", p, commandType: CommandType.StoredProcedure);
        }

        public List<PageSetting> GetAllPageSettings()
        {
            IEnumerable<PageSetting> result = _dbContext.Connection.Query<PageSetting>
            ("Page_Settings_PKG.GetAllPageSettings", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public PageSetting GetPageSettingById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Page_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<PageSetting> result = _dbContext.Connection.Query<PageSetting>
               ("Page_Settings_PKG.GetPageSettingById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdatePageSetting(PageSetting pageSetting)
        {
            var p = new DynamicParameters();
            p.Add("p_Page_ID", pageSetting.PageId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Logo_URL", pageSetting.LogoUrl, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_About_Us", pageSetting.AboutUs, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Contact_Phone", pageSetting.ContactPhone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Contact_Email", pageSetting.ContactEmail, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Contact_Address", pageSetting.ContactAddress, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Facebook_Link", pageSetting.FacebookLink, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_LinkedIn_Link", pageSetting.LinkedinLink, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Instagram_Link", pageSetting.InstagramLink, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Page_Settings_PKG.UpdatePageSetting", p, commandType: CommandType.StoredProcedure);
        }
    }
}
