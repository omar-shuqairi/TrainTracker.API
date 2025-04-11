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
    public class ContactFormRepository : IContactFormRepository
    {
        private readonly IDbContext _dbContext;

        public ContactFormRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateContactForm(Contactform contactform)
        {
            var p = new DynamicParameters();
            p.Add("p_fullName", contactform.Fullname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_email", contactform.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_message", contactform.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("ContactForm_PKG.CreateContactForm", p, commandType: CommandType.StoredProcedure);
        }

        public List<Contactform> GetAllContactForm()
        {
            IEnumerable<Contactform> result = _dbContext.Connection.Query<Contactform>
          ("ContactForm_PKG.GetAllContactForm", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
