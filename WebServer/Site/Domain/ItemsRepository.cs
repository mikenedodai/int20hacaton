using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Site.Domain
{
    public class ItemsRepository : IDisposable
    {
        private ItemsContext _dbContext;
        
        public ItemsRepository(ItemsContext context)
        {
            _dbContext = context;
        }
        
        public async Task<int> Insert(IEnumerable<ItemDto> items)
        {
            
            var time = DateTime.Now;
            var itemDtos = items.Select((item, idx) => ItemConvector.Convert(item, time));
            await _dbContext.AddRangeAsync(itemDtos);
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}