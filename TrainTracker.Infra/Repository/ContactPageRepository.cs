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
    public class ContactPageRepository : IContactPageRepository
    {
        private readonly IDbContext _dbContext;

        public ContactPageRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void UpdateContactPage(ContactPage contactPage)
        {
            var p = new DynamicParameters();
            p.Add("p_Contact_ID", contactPage.ContactId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Address", contactPage.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Email", contactPage.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Phone", contactPage.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("ContactPage_PKG.UpdateContact", p, commandType: CommandType.StoredProcedure);
        }

        public ContactPage GetContactPage()
        {

            IEnumerable<ContactPage> result = _dbContext.Connection.Query<ContactPage>
               ("ContactPage_PKG.GetAllContacts", commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }

}
