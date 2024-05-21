namespace sa.gov.libgph.MedadApi.Models.Request
{
    public class ListMaterialContainersRequest
    {

        public string URL { get; } = "/material-types";
        public string Query { get; private set; } = "?query=cql.allRecords=1 sortby name&limit=2000";
    }
}