using System;

namespace Site.Domain
{
    public class ItemDto
    {
        public string StoreName { get; set; }
        public string Name { get; set; }
        public string StoreUrl { get; set; }
        public decimal Price { get; set; }
    }
}