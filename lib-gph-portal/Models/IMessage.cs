using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sa.gov.libgph.Models
{
    public interface IMessage
    {
        string Body { get; set; }
        string Title { get; set; }
        MessageEnum Type { get; set; }
    }
}
