namespace sa.gov.libgph.Models
{

    public class LiberaryModel
    {
        public Data data { get; set; }
        //public Message[] messages { get; set; }
        public int status { get; set; }
        public int dataLength { get; set; }
    }

    public class Data
    {
        public Location[] locations { get; set; }
    }

    public class Location
    {
        public string id { get; set; }
        public string name { get; set; }
        public string discoveryDisplayName { get; set; }
        public string campusId { get; set; }
        public string isActive { get; set; }
    }

    

}
