using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sa.gov.libgph.Models
{
    public enum ResponseStatusEnum
    {
        Fail = -1,
        NON = 0,
        OK = 1,
        Pending = 2,
        RedirectToEdit = 3,
        isExits = 4,
    }
}