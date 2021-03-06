using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Site.Models;

namespace Site.Domain
{
    public class ItemsRepository : IDisposable, IItemsRepository
    {
        private ItemsContext _dbContext;
        
        public ItemsRepository(ItemsContext context)
        {
            _dbContext = context;
        }
        
        public async Task<int> Insert(IEnumerable<Item> items)
        {
            await _dbContext.AddRangeAsync(items);
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public IList<KeyValuePair<DateTime, decimal>> GetItems()
        {
            return _dbContext.Items.GroupBy(i => i.Time).Select(g => new KeyValuePair<DateTime,decimal> (g.Key, g.Min(cm => cm.PricePerKg))).ToList();
        }

        public IList<Item> GetLastItems()
        {
            var last = _dbContext.Items.OrderByDescending(x => x.Time).FirstOrDefault();
            if (last == null)
                return new List<Item>(0);
            return _dbContext.Items.Where(i => i.Time == last.Time).OrderBy(i => i.PricePerKg).ToList();
        }

        public Item GetItem(string itemId)
        {
            var id = Int32.Parse(itemId);
            return _dbContext.Items.FirstOrDefault(i => i.ItemID == id);
        }
        

        public void Add(Item item)
        {
            throw new NotImplementedException();
        }
    }
}