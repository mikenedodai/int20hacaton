using System;

namespace Site.Domain
{
    public class PriceDto
    {
        public string Name { get; set; }
        public string StoreUrl { get; set; }
        public decimal Price { get; set; }
    }
}