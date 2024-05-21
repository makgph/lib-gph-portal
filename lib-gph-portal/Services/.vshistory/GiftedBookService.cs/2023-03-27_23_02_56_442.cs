using sa.gov.libgph.Models;
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
                                                    .AppSettings["GiftedBookURL"]+"/50";

                ApiClient apiClient = new ApiClient(new Uri(GiftedBookURL));
                //var t = Task.Run(() => apiClient.GetAsync<GenericVM<List<ServiceModel>>>());
                var t = Task.Run(() => apiClient.GetAsync<object>());
                t.Wait();

                var GiftedBook = t.Result;

                return GiftedBook;

            }
            catch (Exception ex)
            {

                return null;
            }

        }

    }
}