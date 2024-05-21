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
        public object GetRequest()
        {
            try
            {
                string GiftedBookURL = System.Web
                                       .Configuration
                                       .WebConfigurationManager
                                       .AppSettings["GiftedBookURL"];

                ApiClient apiClient = new ApiClient(new Uri(GiftedBookURL));
                //var t = Task.Run(() => apiClient.GetAsync<GenericVM<List<ServiceModel>>>());
                //var t = Task.Run(() => apiClient.GetAsync<object>());
                //t.Wait();
                //var GiftedBook = t.Result;

                var t2 = Task.Run(() => apiClient.GetAsync<GiftedBookResponse>());
                t2.Wait();

                t2.Wait();
                var GiftedBook2 = t2.Result;
                var converter = new GiftedBookConverter();

                return converter.getSearchResponse(GiftedBook2);
                //return GiftedBook;

            }
            catch (Exception ex)
            {

                return null;
            }

        }

    }
}