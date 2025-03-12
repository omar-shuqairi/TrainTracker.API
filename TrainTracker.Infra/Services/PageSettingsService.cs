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
    public class PageSettingsService : IPageSettingsService
    {
        private readonly IPageSettingsRepository _pageSettingsRepository;

        public PageSettingsService(IPageSettingsRepository pageSettingsRepository)
        {
            _pageSettingsRepository = pageSettingsRepository;
        }
        public void CreatePageSetting(PageSetting pageSetting)
        {
            _pageSettingsRepository.CreatePageSetting(pageSetting);
        }

        public void DeletePageSetting(int id)
        {
            _pageSettingsRepository.DeletePageSetting(id);
        }

        public List<PageSetting> GetAllPageSettings()
        {
            return _pageSettingsRepository.GetAllPageSettings();
        }

        public PageSetting GetPageSettingById(int id)
        {
            return _pageSettingsRepository.GetPageSettingById(id);
        }

        public void UpdatePageSetting(PageSetting pageSetting)
        {
            _pageSettingsRepository.UpdatePageSetting(pageSetting);
        }
    }
}
