using sa.gov.libgph.Models;
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
                var t = Task.Run(() => apiClient.GetAsync<object>());
                var t2 = Task.Run(() => apiClient.GetAsync<GiftedBookResponse>());
                t.Wait();
                t2.Wait();

                var GiftedBook = t.Result;
                t2.Wait();
                var GiftedBook2 = t2.Result;
                 
                return GiftedBook;

            }
            catch (Exception ex)
            {

                return null;
            }

        }

    }
}