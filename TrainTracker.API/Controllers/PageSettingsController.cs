using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTracker.Core.Data;
using TrainTracker.Core.Services;
using TrainTracker.Infra.Services;

namespace TrainTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageSettingsController : ControllerBase
    {
        private readonly IPageSettingsService _pageSettingsService;

        public PageSettingsController(IPageSettingsService pageSettingsService)
        {
            _pageSettingsService = pageSettingsService;
        }

        [HttpGet]
        public List<PageSetting> GetAllPageSettings()
        {
            return _pageSettingsService.GetAllPageSettings();
        }

        [HttpGet]
        [Route("getbyId/{id}")]
        public PageSetting GetPageSettingById(int id)
        {
            return _pageSettingsService.GetPageSettingById(id);
        }


        [HttpPost]
        public void CreatePageSetting(PageSetting pageSetting)
        {
            _pageSettingsService.CreatePageSetting(pageSetting);
        }

        [HttpPut]
        public void UpdatePageSetting(PageSetting pageSetting)
        {
            _pageSettingsService.UpdatePageSetting(pageSetting);
        }

        [HttpDelete]
        [Route("DeletePageSetting/{id}")]

        public void DeletePageSetting(int id)
        {
            _pageSettingsService.DeletePageSetting(id);
        }
    }
}
