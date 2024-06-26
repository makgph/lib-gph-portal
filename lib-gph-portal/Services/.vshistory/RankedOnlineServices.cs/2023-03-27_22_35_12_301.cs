﻿using sa.gov.libgph.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sa.gov.libgph.Services
{
    public class RankedOnlineServices
    {

        public object GetRequest()
        {
            try
            {
                string OnlineService_APIURL = System.Web
                                                    .Configuration
                                                    .WebConfigurationManager
                                                    .AppSettings["OnlineService_APIURL"];

                ApiClient apiClient = new ApiClient(new Uri(OnlineService_APIURL));
                //var t = Task.Run(() => apiClient.GetAsync<GenericVM<List<ServiceModel>>>());
                var t = Task.Run(() => apiClient.GetAsync<object>());
                t.Wait();

                var RankedOnlineServices = t.Result;

                return RankedOnlineServices;

            }
            catch (Exception ex)
            {

                return null;
            }

        }

    }
}