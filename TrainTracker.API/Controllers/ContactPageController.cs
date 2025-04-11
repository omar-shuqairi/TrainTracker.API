using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTracker.Core.Data;
using TrainTracker.Core.Services;

namespace TrainTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactPageController : ControllerBase
    {

        private readonly IContactPageService _contactPageService;
        public ContactPageController(IContactPageService contactPageService)
        {
            _contactPageService = contactPageService;
        }
        [HttpGet]
        public ContactPage GetContactPage()
        {
            return _contactPageService.GetContactPage();
        }
        [HttpPut]
        [Authorize]
        [CheckClaimsAtt("RoleId", "1")]
        public void UpdateContactPage([FromBody] ContactPage contactPage)
        {
            _contactPageService.UpdateContactPage(contactPage);
        }
    }
}
