using System;
using System.ComponentModel.DataAnnotations;

namespace Site.Domain
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }
        public string StoreName { get; set; }
        public string Name { get; set; }
        public string StoreUrl { get; set; }
        public decimal Price { get; set; }
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        public string ImageUrl { get; set; }
    }
}