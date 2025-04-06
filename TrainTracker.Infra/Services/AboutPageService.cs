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
    public class AboutPageService : IAboutPageService
    {
        private readonly IAboutPageRepository _aboutPageRepository;
        public AboutPageService(IAboutPageRepository aboutPageRepository)
        {
            _aboutPageRepository = aboutPageRepository;
        }
        public AboutPage GetAboutPage()
        {
            return _aboutPageRepository.GetAboutPage();
        }

        public void UpdateAboutPage(AboutPage aboutPage)
        {
            _aboutPageRepository.UpdateAboutPage(aboutPage);
        }
    }
}
