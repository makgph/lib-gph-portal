namespace sa.gov.libgph.MedadApi.Models.Request
{
    public class GetMARCRequest
    {
        public GetMARCRequest(string instanceId)
        {
            this.URL = $"/source-storage/records/{instanceId}/formatted";


        }
        public string URL { get; } = "";
        public string Query { get; } = @"idType=INSTANCE";
    }
}