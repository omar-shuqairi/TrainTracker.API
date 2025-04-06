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
    public class AboutPageRepository : IAboutPageRepository
    {
        private readonly IDbContext _dbContext;

        public AboutPageRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void UpdateAboutPage(AboutPage aboutPage)
        {
            var p = new DynamicParameters();
            p.Add("p_About_ID", aboutPage.AboutId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Our_Mission", aboutPage.OurMission, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_How_It_Works", aboutPage.HowItWorks, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Why_Choose_Us", aboutPage.WhyChooseUs, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("AboutPage_PKG.UpdateAbout", p, commandType: CommandType.StoredProcedure);
        }

        public AboutPage GetAboutPage()
        {

            IEnumerable<AboutPage> result = _dbContext.Connection.Query<AboutPage>
               ("AboutPage_PKG.GetAllAbout", commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
