using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class BuckwheatItem
    {
        public string name { get; set; }
        public float price { get; set; }
        public string shopName { get; set; }
        public string imgUrl { get; set; }
        public DateTime date { get; set; }
    }
}
