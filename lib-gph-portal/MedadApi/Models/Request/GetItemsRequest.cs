namespace sa.gov.libgph.MedadApi.Models.Request
{
    public class GetItemsRequest
    {
        public string URL { get; } = "/item-storage/items";
        public string Query { get; } = @"?query=""barcode""==gphl2";
    }
}