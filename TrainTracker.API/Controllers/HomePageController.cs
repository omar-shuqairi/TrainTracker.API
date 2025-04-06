using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTracker.Core.Data;
using TrainTracker.Core.Services;

namespace TrainTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePageController : ControllerBase
    {
        private readonly IHomePageService _homePageService;

        public HomePageController(IHomePageService homePageService)
        {
            _homePageService = homePageService;
        }

        [HttpGet]
        public HomePage GetHomePage()
        {
            return _homePageService.GetHomePage();

        }

        [HttpPut]
        public void UpdateHomePage([FromBody] HomePage homePage)
        {
            _homePageService.UpdateHomePage(homePage);
        }

    }
}
