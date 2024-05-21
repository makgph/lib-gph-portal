using sa.gov.libgph.MedadApi.Models.Request;
using sa.gov.libgph.MedadApi.Models.Response;
using sa.gov.libgph.Services;
using System;
using System.Threading.Tasks;

namespace sa.gov.libgph.MedadApi.Services
{
    public class SearchService
    {
        public SearchResponse GetSimpleSearchResponse(string searchKeyWord)
        {
            var MedadApiBaseURL = MedadApiConfiguration.MedadApiBaseURL;
            var MedadTenantKey = MedadApiConfiguration.MedadTenantKey;
            var MedadTenantValue = MedadApiConfiguration.MedadTenantValue;
            var MedadTokenValue = MedadApiConfiguration.MedadTokenValue;
            var MedadTokenKey = MedadApiConfiguration.MedadTokenKey;

            var Request = new SimpleSearchRequest(searchKeyWord);
            ApiClient apiClient = new ApiClient(new Uri(MedadApiBaseURL + Request.URL + Request.Query));
            apiClient.addHeaders(MedadTokenKey, MedadTokenValue);
            apiClient.addHeaders(MedadTenantKey, MedadTenantValue);
            var qu = MedadApiBaseURL + Request.URL + Request.Query;
            var CurrentTask = Task.Run(() => apiClient.GetAsync<SearchResponse>(MedadApiBaseURL + Request.URL, Request.Query));
            CurrentTask.Wait();
            var response = CurrentTask.Result;

            return response;
        }
        public SearchResponse GetAdvancedSearchResponse(string Query)
        {
            var MedadApiBaseURL = MedadApiConfiguration.MedadApiBaseURL;
            var MedadTenantKey = MedadApiConfiguration.MedadTenantKey;
            var MedadTenantValue = MedadApiConfiguration.MedadTenantValue;
            var MedadTokenValue = MedadApiConfiguration.MedadTokenValue;
            var MedadTokenKey = MedadApiConfiguration.MedadTokenKey;

            var Request = new AdvancedSearchRequest(Query);
            ApiClient apiClient = new ApiClient(new Uri(MedadApiBaseURL + Request.URL + Request.Query));
            apiClient.addHeaders(MedadTokenKey, MedadTokenValue);
            apiClient.addHeaders(MedadTenantKey, MedadTenantValue);
            var qu = MedadApiBaseURL + Request.URL + Request.Query;
            var CurrentTask = Task.Run(() => apiClient.GetAsync<SearchResponse>(MedadApiBaseURL + Request.URL, Request.Query));
            var response = new SearchResponse();
            try
            {
                CurrentTask.Wait();
                response = CurrentTask.Result;

            }
            catch (Exception) { }

            return response;
        }



    }
}