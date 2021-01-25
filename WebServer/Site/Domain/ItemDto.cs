using System;
using System.Collections.Generic;

namespace Site.Domain
{
    public class ItemDto
    {
        public string StoreName { get; set; }
        public string Name { get; set; }
        public string StoreUrl { get; set; }
        public decimal Price { get; set; }
        public decimal PricePerKg { get; set; }
        public string ImageUrl { get; set; }
    }
    
    public class ItemsDto
    {
        public ItemDto[] items { get; set; }
    }
}