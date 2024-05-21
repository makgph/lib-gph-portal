using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Composing;
using Umbraco.Core.Events;
using Umbraco.Core.Services;
using Umbraco.Core.Services.Implement;
using Umbraco.Web;
using sa.gov.libgph.Controllers;
using Umbraco.Core.Models.PublishedContent;

namespace sa.gov.libgph.Services
{

    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class SubscribeToPublishEventComposer : ComponentComposer<SubscribeToPublishEventComponent>
    { }

    public class SubscribeToPublishEventComponent : IComponent
    {
        public void Initialize()
        {
            ContentService.Publishing += ContentService_Publishing;
        }


        private void ContentService_Publishing(IContentService sender, ContentPublishingEventArgs e)
        {

            var Email = new EmailHandler();
            var MailingList = new MailingListController();
            var GetMailingList = MailingList.GetMailingList().ToArray();

            foreach (var node in e.PublishedEntities)
            {
                //If the Published Target is a NewsItem
                if (node.ContentType.Alias == "newsItem")
                {
                    for (int i = 0; i < GetMailingList.Length; i++)
                    {
                        Email.EmailReceiver = GetMailingList[i].Value<string>("subscriberEmail");
                        Email.EmailSubject = $"خبر جديد -- {i} " + node.CultureInfos[0].Name;
                        Email.EmailBody = "خبر جديييييييييييييييييييييد";
                        Email.SendEmail();
                    }


                    #region Commented Code form Documentation

                    //var newsArticleTitle = node.GetValue<string>("newsTitle");

                    //if (newsArticleTitle.Equals(newsArticleTitle.ToUpper()))
                    //{
                    //    // Stop putting news article titles in upper case, so cancel publish
                    //    e.Cancel = true;

                    //    // Explain why the publish event is cancelled
                    //    e.Messages.Add(new EventMessage("Corporate style guideline infringement", "Don't put the news article title in upper case, no need to shout!",EventMessageType.Error));
                    //}
                    #endregion
                }
                if (node.ContentType.Alias == "registrationForm")
                {
                    if (node.HasProperty("status"))
                    {
                        Email.EmailReceiver = node.GetValue<string>("email");
                        var ParentID = node.ParentId;
                        var helper = Umbraco.Web.Composing.Current.UmbracoHelper;
                        IPublishedContent Parent = helper.Content(ParentID);


                        if (node.GetValue<string>("status") == "Accepted")
                        {

                            Email.EmailSubject = "تم قبول طلبك للانضمام للكورس";
                            Email.EmailBody =   $"تم قبول طلبك للانضمام لكورس  {Parent.Name}";
                            Email.SendEmail();

                        }
                        else if (node.GetValue<string>("status") == "Rejected")
                        {

                            Email.EmailSubject = "نأسف تم رفض طلبك للانضمام للكورس";
                            Email.EmailBody = $"نأسف تم رفض طلبك للانضمام لكورس  {Parent.Name}";
                            Email.SendEmail();
                        }
                        else
                        {

                        }


                    }

                }
            }
        }
        public void Terminate()
        {
            //unsubscribe during shutdown
            ContentService.Publishing -= ContentService_Publishing;
        }
    }
}