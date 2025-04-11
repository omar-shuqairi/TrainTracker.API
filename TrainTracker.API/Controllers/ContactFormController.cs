using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTracker.Core.Data;
using TrainTracker.Core.Services;

namespace TrainTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactFormController : ControllerBase
    {
        private readonly IContactFormService _contactFormService;

        public ContactFormController(IContactFormService contactFormService)
        {
            _contactFormService = contactFormService;
        }

        [HttpGet]
        [Authorize]
        [CheckClaimsAtt("RoleId", "1")]
        public List<Contactform> GetAllContactForms()
        {
            return _contactFormService.GetAllContactForm();

        }

        [HttpPost]
        public void CreateContactForm([FromBody] Contactform contactform)
        {

            _contactFormService.CreateContactForm(contactform);
        }
    }
}
