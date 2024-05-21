﻿using sa.gov.libgph.MedadApi.Models.Request;
using sa.gov.libgph.MedadApi.Models.Response;
using sa.gov.libgph.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace sa.gov.libgph.MedadApi.Services
{
    public class ListAllLibrariesService
    {
        public ListAllLibrariesResponse GetListAllLibrariesResponse()
        {
            var MedadApiBaseURL = MedadApiConfiguration.MedadApiBaseURL;
            var MedadTenantKey = MedadApiConfiguration.MedadTenantKey;
            var MedadTenantValue = MedadApiConfiguration.MedadTenantValue;
            var MedadTokenValue = MedadApiConfiguration.MedadTokenValue;
            var MedadTokenKey = MedadApiConfiguration.MedadTokenKey;

            var Request = new ListAllLibrariesRequest();
            ApiClient apiClient = new ApiClient(new Uri(MedadApiBaseURL + Request.URL + Request.Query));
            apiClient.addHeaders(MedadTokenKey, MedadTokenValue);
            apiClient.addHeaders(MedadTenantKey, MedadTenantValue);
            var response = new ListAllLibrariesResponse();
            try
            {

                var CurrentTask = Task.Run(() => apiClient.GetAsync<ListAllLibrariesResponse>(MedadApiBaseURL + Request.URL, Request.Query));
                CurrentTask.Wait();
                response = CurrentTask.Result;
            }
            catch (Exception) { }
            
            return response;
        }
    }
}