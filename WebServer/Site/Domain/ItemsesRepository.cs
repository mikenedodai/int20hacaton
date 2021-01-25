using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Site.Domain
{
    public class ItemsesRepository : IDisposable, IItemsRepository
    {
        private ItemsContext _dbContext;
        
        public ItemsesRepository(ItemsContext context)
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

        public IList<Item> GetItems()
        {
            return _dbContext.Items.ToList();
        }

        public IList<Item> GetLastItems()
        {
            var last = _dbContext.Items.OrderByDescending(x => x.Time).FirstOrDefault();
            if (last == null)
                return new List<Item>(0);
            return _dbContext.Items.Where(i => i.Time == last.Time).OrderBy(i => i.Price).ToList();
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