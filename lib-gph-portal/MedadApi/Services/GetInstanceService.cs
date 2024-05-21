﻿using sa.gov.libgph.MedadApi.Models.Request;
using sa.gov.libgph.MedadApi.Models.Response;
using sa.gov.libgph.Services;
using System;
using System.Threading.Tasks;

namespace sa.gov.libgph.MedadApi.Services
{
    public class GetInstanceService
    {
        public GetInstanceResponse GetInstanceResponse()
        {
            var MedadApiBaseURL = MedadApiConfiguration.MedadApiBaseURL;
            var MedadTenantKey = MedadApiConfiguration.MedadTenantKey;
            var MedadTenantValue = MedadApiConfiguration.MedadTenantValue;
            var MedadTokenValue = MedadApiConfiguration.MedadTokenValue;
            var MedadTokenKey = MedadApiConfiguration.MedadTokenKey;

            var Request = new GetInstanceRequest();
            ApiClient apiClient = new ApiClient(new Uri(MedadApiBaseURL + Request.URL + Request.Query));
            apiClient.addHeaders(MedadTokenKey, MedadTokenValue);
            apiClient.addHeaders(MedadTenantKey, MedadTenantValue);
            var CurrentTask = Task.Run(() => apiClient.GetAsync<GetInstanceResponse>(MedadApiBaseURL + Request.URL, Request.Query));
            CurrentTask.Wait();
            var response = CurrentTask.Result;

            return response;
        }



    }
}