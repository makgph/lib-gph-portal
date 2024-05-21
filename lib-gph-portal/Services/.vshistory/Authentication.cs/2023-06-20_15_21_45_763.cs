using System.Collections.Generic;

namespace sa.gov.libgph.Services
{
    public class Authentication
    {

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
    public List<string> messages { get; set; }
    public int status { get; set; }
    public int dataLength { get; set; }
}