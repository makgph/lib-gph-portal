using sa.gov.libgph.MedadApi.Models.Request;
using sa.gov.libgph.MedadApi.Models.Response;
using sa.gov.libgph.Services;
using System;
using System.Threading.Tasks;

namespace sa.gov.libgph.MedadApi.Services
{
    public class GetInstance2Service
    {
        public GetInstance2Response GetInstance2Response(string instanceId)
        {
            var MedadApiBaseURL = MedadApiConfiguration.MedadApiBaseURL;
            var MedadTenantKey = MedadApiConfiguration.MedadTenantKey;
            var MedadTenantValue = MedadApiConfiguration.MedadTenantValue;
            var MedadTokenValue = MedadApiConfiguration.MedadTokenValue;
            var MedadTokenKey = MedadApiConfiguration.MedadTokenKey;

            var Request = new GetInstance2Request();
            var response = new GetInstance2Response();
            try
            {

                ApiClient apiClient = new ApiClient(new Uri(MedadApiBaseURL + Request.URL + Request.Query));
                apiClient.addHeaders(MedadTokenKey, MedadTokenValue);
                apiClient.addHeaders(MedadTenantKey, MedadTenantValue);
                var CurrentTask = Task.Run(() => apiClient.GetAsync<GetInstance2Response>(MedadApiBaseURL + Request.URL + instanceId, Request.Query));
                CurrentTask.Wait();
                response = CurrentTask.Result;
            }
            catch (Exception)
            {

                  
            }

            return response;
        }



    }
}