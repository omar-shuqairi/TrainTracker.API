using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;
using TrainTracker.Core.Repository;
using TrainTracker.Core.Services;

namespace TrainTracker.Infra.Services
{
    public class ContactPageService : IContactPageService
    {
        private readonly IContactPageRepository _contactPageRepository;

        public ContactPageService(IContactPageRepository contactPageRepository)
        {
            _contactPageRepository = contactPageRepository;
        }

        public void UpdateContactPage(ContactPage contactPage)
        {
            _contactPageRepository.UpdateContactPage(contactPage);
        }

        public ContactPage GetContactPage()
        {
            return _contactPageRepository.GetContactPage();
        }
    }

}
