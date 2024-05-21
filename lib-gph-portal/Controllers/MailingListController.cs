using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace sa.gov.libgph.Controllers
{
    public class MailingListController : SurfaceController
    {
        // GET: MailingList
        public IEnumerable<IPublishedContent> GetMailingList()
        {
            var Subscribers = Umbraco
                                .ContentAtRoot()
                                .FirstOrDefault()
                                .ChildrenOfType("newsletterSubscribers")
                                .FirstOrDefault()
                                .ChildrenOfType("newsletterSubscriber")
                                .ToArray();


            return Subscribers;
        }
    }
}