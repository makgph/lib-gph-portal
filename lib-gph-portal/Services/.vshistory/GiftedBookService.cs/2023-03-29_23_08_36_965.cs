using sa.gov.libgph.MedadApi.Models.Response;
using sa.gov.libgph.Models;
using sa.gov.libgph.Services.Converter;
using sa.gov.libgph.Services.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace sa.gov.libgph.Services
{
    public class GiftedBookService
    {
        public SearchResponse GetSearchResponse()
        {
            try
            {
                string GiftedBookURL = System.Web
                                       .Configuration
                                       .WebConfigurationManager
                                       .AppSettings["GiftedBookURL"];

                ApiClient apiClient = new ApiClient(new Uri(GiftedBookURL));
                var t = Task.Run(() => apiClient.GetAsync<GiftedBookResponse>(GiftedBookURL));
                t.Wait();
                var GiftedBook = t.Result;
                var converter = new GiftedBookConverter();
                return converter.getSearchResponse(GiftedBook);

            }
            catch (Exception ex)
            {

                return null;
            }

        }

    }
}