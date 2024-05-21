namespace sa.gov.libgph.MedadApi
{
    public static class MedadApiConfiguration
    {
        public static string MedadApiBaseURL { get; } = getConfigValue("MedadApiBaseURL");
        public static string MedadTenantKey { get; } = getConfigValue("MedadTenantKey");
        public static string MedadTenantValue { get; } = getConfigValue("MedadTenantValue");
        public static string MedadTokenValue { get; } = getConfigValue("MedadTokenValue");
        public static string MedadTokenKey { get; } = getConfigValue("MedadTokenKey");


        private static string getConfigValue(string key)
        {

            return System.Web
                         .Configuration
                         .WebConfigurationManager
                         .AppSettings[key];
        }

    }
}