using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTracker.Core.Data;
using TrainTracker.Core.Services;

namespace TrainTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutPageController : ControllerBase
    {
        private readonly IAboutPageService _aboutPageService;

        public AboutPageController(IAboutPageService aboutPageService)
        {
            _aboutPageService = aboutPageService;
        }

        [HttpGet]
        public AboutPage GetAboutPage()
        {
            return _aboutPageService.GetAboutPage();
        }

        [HttpPut]
        [Authorize]
        [CheckClaimsAtt("RoleId", "1")]
        public void UpdateAboutPage([FromBody] AboutPage aboutPage)
        {
            _aboutPageService.UpdateAboutPage(aboutPage);
        }

    }
}
