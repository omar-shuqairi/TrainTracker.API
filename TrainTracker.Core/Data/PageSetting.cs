using System;
using System.Collections.Generic;

namespace TrainTracker.Core.Data
{
    public partial class PageSetting
    {
        public decimal PageId { get; set; }
        public string? LogoUrl { get; set; }
        public string? AboutUs { get; set; }
        public string? ContactPhone { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactAddress { get; set; }
        public string? FacebookLink { get; set; }
        public string? LinkedinLink { get; set; }
        public string? InstagramLink { get; set; }
    }
}
