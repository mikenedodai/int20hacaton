using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Site.Models;

namespace Site.Domain
{
    public interface IItemsRepository
    {
        IList<KeyValuePair<DateTime, decimal>> GetItems();
        IList<Item> GetLastItems();
        Item GetItem(string itemId);
        Task<int> Insert(IEnumerable<Item> items);
        void Add(Item item);
    }
}