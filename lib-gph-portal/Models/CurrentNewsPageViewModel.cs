using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;

namespace sa.gov.libgph.Models
{
    public class CurrentNewsPageViewModel
    {
        public List<IPublishedContent> NewsList { get; set; }
        public string CurrentPageNumber { get; set; }
        public string CurrentLanguage { get; set; }
        public int Pagination { get; set; }
        public int PageSize { get; set; }
    }
}