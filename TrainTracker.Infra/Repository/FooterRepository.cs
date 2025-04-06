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
    public class FooterRepository : IFooterRepository
    {
        private readonly IDbContext _dbContext;
        public FooterRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void UpdateFooter(Footer footer)
        {
            var p = new DynamicParameters();
            p.Add("p_Footer_ID", footer.FooterId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_About_Us", footer.AboutUs, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Copyright", footer.Copyright, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Footer_PKG.UpdateFooter", p, commandType: CommandType.StoredProcedure);
        }

        public Footer GetFooter()
        {
            IEnumerable<Footer> result = _dbContext.Connection.Query<Footer>
              ("Footer_PKG.GetAllFooter", commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }

}
