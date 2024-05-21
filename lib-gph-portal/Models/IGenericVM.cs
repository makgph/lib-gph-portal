using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sa.gov.libgph.Models
{
    internal interface IGenericVM<T>
    {
        T Data { get; }
        IMessageList Messages { get; }
        ResponseStatusEnum Status { get; }
    }
}
