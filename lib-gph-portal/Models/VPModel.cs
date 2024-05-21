using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;

namespace sa.gov.libgph.Models
{
    public class VPModel
    {
        public IEnumerable<IPublishedElement> iePublishedContent { get; set; }

        public IEnumerable<Link> relatedLinks { get; set; }
        //public RelatedLinks relatedLinks { get; set; }


        public int level { get; set; }

        public string nodeId { get; set; }

        public string chatType { get; set; }

        public List<ChatBotModel> searchResult { get; set; }

        public List<ChatBotModel> chatBotTreeList { get; set; }

        public string message { get; set; }

        public List<string> chatBotAnswer { get; set; }

        public string notFoundMessage { get; set; }
    }
}