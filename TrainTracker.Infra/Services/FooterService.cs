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
    public class FooterService : IFooterService
    {
        private readonly IFooterRepository _footerRepository;

        public FooterService(IFooterRepository footerRepository)
        {
            _footerRepository = footerRepository;
        }

        public void UpdateFooter(Footer footer)
        {
            _footerRepository.UpdateFooter(footer);
        }

        public Footer GetFooter()
        {
            return _footerRepository.GetFooter();
        }
    }
}
