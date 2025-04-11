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
    public class ContactFormService : IContactFormService
    {

        private readonly IContactFormRepository _contactFormRepository;

        public ContactFormService(IContactFormRepository contactFormRepository)
        {
            _contactFormRepository = contactFormRepository;
        }

        public void CreateContactForm(Contactform contactform)
        {
            _contactFormRepository.CreateContactForm(contactform);
        }

        public List<Contactform> GetAllContactForm()
        {
            return _contactFormRepository.GetAllContactForm();
        }
    }
}
