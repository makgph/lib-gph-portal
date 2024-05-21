using sa.gov.libgph.MedadApi.Models.Request;
using System;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace sa.gov.libgph.Controllers
{
    public class MedadApiController : SurfaceController
    {
        // GET: MedadApi
        [HttpGet]
        public ActionResult SimpleSearch(string searchKeyWord)
        {
            string Query = $"simpleSearchKeyword={searchKeyWord}";
            return RedirectToUmbracoPage(new Guid("8204979d-649d-4f3d-ab3e-feb2a6fd5c0b"),Query);
        }
        [HttpGet]

        public ActionResult AdvancedSearch(AdvancedSearchRequestModel request)
        {
            string Query = $"advancedSearchQuery={request.ResolveQuery()}";
            return RedirectToUmbracoPage(new Guid("8204979d-649d-4f3d-ab3e-feb2a6fd5c0b"),Query);
        }
    }
}