using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;

namespace TrainTracker.Core.Services
{
    public interface IPageSettingsService
    {
        List<PageSetting> GetAllPageSettings();
        void CreatePageSetting(PageSetting pageSetting);
        void UpdatePageSetting(PageSetting pageSetting);
        void DeletePageSetting(int id);
        PageSetting GetPageSettingById(int id);
    }
}
