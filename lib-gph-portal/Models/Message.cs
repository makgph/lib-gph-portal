using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sa.gov.libgph.Models
{
    public class Message : IMessage
    {
        public string Code { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public MessageEnum Type { get; set; }

    }
}