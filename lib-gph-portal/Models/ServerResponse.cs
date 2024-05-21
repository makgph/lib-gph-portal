using System.Collections.Generic;

namespace sa.gov.libgph.Models
{
    public class ServerResponse
    {
        public List<string> Messages { get; set; } = new List<string>();
        public ServerResponseType Type { get; set; }
        public string FormId { get; set; }
        public string CurrentLangauge { get; set; }

    }
}
public enum ServerResponseType
{
    Ok,
    Warning,
    Error
}