using sa.gov.libgph.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace sa.gov.libgph.Controllers
{
    public class MediaCenterItemsController : SurfaceController
    {

        private readonly IVariationContextAccessor _variationContextAccessor;
        public MediaCenterItemsController(IVariationContextAccessor variationContextAccessor)
        {
            _variationContextAccessor = variationContextAccessor;
        }


        [HttpPost]
        public ActionResult GetNewsSearchResult(string SearchTarget, string CurrentPageNumber, string CurrentLanguage, string CurrentType, string pageSize, string ChildrenType)
        {
            try
            {
                _variationContextAccessor.VariationContext = new VariationContext(culture: CurrentLanguage);
                CurrentPageNumber = CurrentPageNumber == null ? "0" : CurrentPageNumber;

                var NewsPageViewModel = new CurrentNewsPageViewModel();
                NewsPageViewModel.CurrentPageNumber = CurrentPageNumber;
                NewsPageViewModel.CurrentLanguage = CurrentLanguage;

                var MediaCenter = Umbraco.ContentAtRoot()
                                  .FirstOrDefault()
                                  .ChildrenOfType("mediaCenter")
                                  .FirstOrDefault();

                var CurrentMediaCenterElement = MediaCenter.ChildrenOfType(CurrentType).FirstOrDefault();
                var CurrentMediaItem = CurrentMediaCenterElement.ChildrenOfType(ChildrenType).ToList();


                var CurrentMediaCenterElementType = CurrentMediaCenterElement.GetType();
                var CurrentMediaItemType = CurrentMediaItem.FirstOrDefault().GetType();


                // If Search Target is Null Or Empty String
                if (SearchTarget.Trim().Length == 0)
                {
                    var MediaItemsList = CurrentMediaItem.OrderByDescending(x => x.SortOrder).Where(x => x.IsVisible());
                    NewsPageViewModel.NewsList = MediaItemsList.ToList();
                }
                else
                {
                    //NewsContainer is Just a bridge to Carry News
                    List<IPublishedContent> MediaItemsContainer = new List<IPublishedContent>();
                    var Res = Umbraco.ContentQuery.Search(SearchTarget);

                    var Results = Res.Where(x => x.Content.GetType() == CurrentMediaItemType && x.Content.Ancestor().GetType() == CurrentMediaCenterElementType).ToList();
                    foreach (var item in Results)
                    {
                        MediaItemsContainer.Add(item.Content);
                    }
                    NewsPageViewModel.NewsList = MediaItemsContainer;
                    if (NewsPageViewModel.NewsList.Count() == 0)
                    {
                        //Just Transfer the SearchTarget Value
                        NewsPageViewModel.CurrentPageNumber = SearchTarget;
                        return PartialView("~/Views/Partials/Search/_NoResult.cshtml", NewsPageViewModel);

                    }
                }

                int PageSize = int.Parse(pageSize);
                int CRPageNumber = int.Parse(CurrentPageNumber);
                int Counter = NewsPageViewModel.NewsList.Count();
                NewsPageViewModel.Pagination = Counter % PageSize == 0 ? Counter / PageSize : (Counter / PageSize) + 1;
                NewsPageViewModel.NewsList = NewsPageViewModel.NewsList.Skip(PageSize * CRPageNumber).Take(PageSize).ToList();
                NewsPageViewModel.PageSize = NewsPageViewModel.NewsList.Count() < PageSize ? NewsPageViewModel.NewsList.Count() : PageSize;

                return PartialView("~/Views/Partials/Search/_MediaCenterItem.cshtml", NewsPageViewModel);
            }
            catch
            {
                return PartialView("~/Views/Partials/Search/_error.cshtml");
            }
        }

    }
}
