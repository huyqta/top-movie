using System;
using System.Collections.Generic;

namespace Movie.Services.Models
{
    public partial class TbCrawl
    {
        public int Id { get; set; }
        public string CrawlUrl { get; set; }
        public string SiteUrl { get; set; }
        public string SiteName { get; set; }
        public int IsSuccess { get; set; }
    }
}
