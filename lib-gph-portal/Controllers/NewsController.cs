using sa.gov.libgph.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace sa.gov.libgph.Controllers
{
    public class NewsController : SurfaceController
    {

        private readonly IVariationContextAccessor _variationContextAccessor;
        public NewsController(IVariationContextAccessor variationContextAccessor)
        {
            _variationContextAccessor = variationContextAccessor;
        }


        [HttpPost]
        public ActionResult GetNewsSearchResult(string SearchTarget, string CurrentPageNumber, string CurrentLanguage, string pageSize)
        {
            try
            {
                _variationContextAccessor.VariationContext = new VariationContext(culture: CurrentLanguage);
                CurrentPageNumber = CurrentPageNumber == null ? "0" : CurrentPageNumber;

                var NewsPageViewModel = new CurrentNewsPageViewModel();
                NewsPageViewModel.CurrentPageNumber = CurrentPageNumber;
                NewsPageViewModel.CurrentLanguage = CurrentLanguage;
                
                var News = Umbraco.ContentAtRoot()
                                  .FirstOrDefault()
                                  .ChildrenOfType("News")
                                  .FirstOrDefault()
                                  .ChildrenOfType("newsitem").ToList();

                var NewsItemType = News.FirstOrDefault().GetType();
                // If Search Target is Null Or Empty String
                if (SearchTarget.Trim().Length == 0)
                {
                    var NewsList = News.OrderByDescending(x => x.SortOrder).Where(x => x.IsVisible());
                    NewsPageViewModel.NewsList = NewsList.ToList();
                }
                else
                {
                    //NewsContainer is Just a bridge to Carry News
                    List<IPublishedContent> NewsContainer = new List<IPublishedContent>();
                    var Results = Umbraco.ContentQuery.Search(SearchTarget).Where(x => x.Content.GetType() == NewsItemType).ToList();
                    foreach (var item in Results)
                    {
                        NewsContainer.Add(item.Content);
                    }
                    NewsPageViewModel.NewsList = NewsContainer;
                    if (NewsPageViewModel.NewsList.Count() == 0)
                    {
                        //Just Transfer the SearchTarget Value
                        NewsPageViewModel.CurrentPageNumber = SearchTarget;
                        return PartialView("~/Views/Partials/Search/_NoResult.cshtml", NewsPageViewModel);

                    }
                }
                int PageSize = int.Parse(pageSize);
                int CRPageNumber = int.Parse(CurrentPageNumber);
                int NewListCounter = NewsPageViewModel.NewsList.Count();
                //NewsPageViewModel.Pagination = (NewsPageViewModel.NewsList.Count() / PageSize) + 1;
                NewsPageViewModel.Pagination = NewListCounter % PageSize == 0 ? NewListCounter / PageSize : (NewListCounter / PageSize) + 1;
                NewsPageViewModel.NewsList = NewsPageViewModel.NewsList.Skip(PageSize * CRPageNumber).Take(PageSize).ToList();
               
                NewsPageViewModel.PageSize = NewsPageViewModel.NewsList.Count() < PageSize ? NewsPageViewModel.NewsList.Count(): PageSize;
                
                return PartialView("~/Views/Partials/Search/_News.cshtml", NewsPageViewModel);
            }
            catch
            {
                return PartialView("~/Views/Partials/Search/_error.cshtml");
            }
        }

    }
}
