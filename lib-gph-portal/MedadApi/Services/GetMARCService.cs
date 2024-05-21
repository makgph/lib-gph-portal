using Newtonsoft.Json.Linq;
using sa.gov.libgph.MedadApi.Models;
using sa.gov.libgph.MedadApi.Models.Request;
using sa.gov.libgph.MedadApi.Models.Response;
using sa.gov.libgph.Services;
using System;
using System.Threading.Tasks;

namespace sa.gov.libgph.MedadApi.Services
{
    public class GetMARCService
    {
        public MarcDetails GetMARCResponse(string instanceId)
        {
            var MedadApiBaseURL = MedadApiConfiguration.MedadApiBaseURL;
            var MedadTenantKey = MedadApiConfiguration.MedadTenantKey;
            var MedadTenantValue = MedadApiConfiguration.MedadTenantValue;
            var MedadTokenValue = MedadApiConfiguration.MedadTokenValue;
            var MedadTokenKey = MedadApiConfiguration.MedadTokenKey;

            var Request = new GetMARCRequest(instanceId);
            GetMARCResponse response = new GetMARCResponse();
            var converter = new MedadApiConverter();
            var jArr = new JArray();
            try
            {
                ApiClient apiClient = new ApiClient(new Uri(MedadApiBaseURL + Request.URL + '?' + Request.Query));
                apiClient.addHeaders(MedadTokenKey, MedadTokenValue);
                apiClient.addHeaders(MedadTenantKey, MedadTenantValue);
                var CurrentTask = Task.Run(() => apiClient.GetAsync<GetMARCResponse>(MedadApiBaseURL + Request.URL, Request.Query));
                CurrentTask.Wait();
                response = CurrentTask.Result;
                jArr = JArray.FromObject(response.parsedRecord.content.fields);

            }
            catch (Exception)
            {

            }

            return converter.GetMarkDetails(jArr);
        }



    }
}