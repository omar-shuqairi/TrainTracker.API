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
    public class HomePageService : IHomePageService
    {
        private readonly IHomePageRepository _homePageRepository;

        public HomePageService(IHomePageRepository homePageRepository)
        {
            _homePageRepository = homePageRepository;
        }

        public void UpdateHomePage(HomePage homePage)
        {
            _homePageRepository.UpdateHomePage(homePage);
        }

        public HomePage GetHomePage()
        {
            return _homePageRepository.GetHomePage();
        }
    }

}
