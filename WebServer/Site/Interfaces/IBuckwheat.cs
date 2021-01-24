using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Site.Models;

namespace Site.Interfaces
{
    interface IBuckwheat
    {
        IEnumerable<BuckwheatItem> BuckwheatItems { get; set; }
    }
}
