using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sa.gov.libgph.Services
{
    public class Authentication
    {

        object mm = new UserData();


        public void Login()
        {
            try
            {
                string LoginEndPointURL = System.Web
                                            .Configuration
                                            .WebConfigurationManager
                                            .AppSettings["LoginEndPointURL"];

                ApiClient apiClient = new ApiClient(new Uri(LoginEndPointURL));
                var t = Task.Run(() => apiClient.GetAsync<ResponseObject>());
                t.Wait();
                mm = t.Result.data;
            }
            catch (Exception) { }

        }


    }
}


public class UserData
{
    public string userId { get; set; }
    public string userName { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string fullName { get; set; }
    public string nameArabic { get; set; }
    public string email { get; set; }
    public string phoneNumber { get; set; }
    public string token { get; set; }
    public string defaultRoleCode { get; set; }
    public List<string> roleCode { get; set; }
}

public class ResponseObject
{
    public UserData data { get; set; }
    //public List<string> messages { get; set; }
    public int status { get; set; }
    public int dataLength { get; set; }
}