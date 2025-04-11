using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTracker.Core.Data;
using TrainTracker.Core.Services;

namespace TrainTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterController : ControllerBase
    {
        private readonly IFooterService _footerService;

        public FooterController(IFooterService footerService)
        {
            _footerService = footerService;
        }

        [HttpGet]
        public Footer GetFooter()
        {
            return _footerService.GetFooter();
        }

        [HttpPut]
        [Authorize]
        [CheckClaimsAtt("RoleId", "1")]
        public void UpdateFooter([FromBody] Footer footer)
        {
            _footerService.UpdateFooter(footer);
        }
    }
}
