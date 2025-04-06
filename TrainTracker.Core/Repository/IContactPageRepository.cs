using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;

namespace TrainTracker.Core.Repository
{
    public interface IContactPageRepository
    {
        void UpdateContactPage(ContactPage contactPage);
        ContactPage GetContactPage();
    }
}
