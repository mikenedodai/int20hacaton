using System;
using Site.Models;

namespace Site.Domain
{
    public static class ItemConvector
    {
        public static Item Convert(ItemDto itemDto, DateTime timeSpan)
        {
            return new Item
            {
                Name = itemDto.Name,
                StoreName = itemDto.StoreName,
                Price = itemDto.Price,
                StoreUrl = itemDto.StoreUrl,
                Time = timeSpan,
                ImageUrl = itemDto.ImageUrl,
                PricePerKg = itemDto.PricePerKg
            };
        }
    }
}