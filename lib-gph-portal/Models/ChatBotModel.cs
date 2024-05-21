using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Models.PublishedContent;
using Umbraco.Web.Models;

namespace sa.gov.libgph.Models
{
    public class ChatBotModel
    {
        public string title { get; set; }
        public string nodeId { get; set; }

        public string currentLevel { get; set; }

        public IEnumerable<Link> links { get; set; }
    }
}