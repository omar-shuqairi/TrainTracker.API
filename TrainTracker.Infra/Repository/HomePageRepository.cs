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
    public class HomePageRepository : IHomePageRepository
    {

        private readonly IDbContext _dbContext;

        public HomePageRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void UpdateHomePage(HomePage homePage)
        {
            var p = new DynamicParameters();
            p.Add("p_Home_ID", homePage.HomeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Logo_Img", homePage.LogoImg, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Bg_Hero", homePage.BgHero, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Paragraph1", homePage.Paragraph1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Paragraph2", homePage.Paragraph2, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("HomePage_PKG.UpdateHome", p, commandType: CommandType.StoredProcedure);
        }

        public HomePage GetHomePage()
        {

            IEnumerable<HomePage> result = _dbContext.Connection.Query<HomePage>
               ("HomePage_PKG.GetAllHome", commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }


    }
}
