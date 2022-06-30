using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.Repository
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new List<Item>()
        {
            new Item() { Id = Guid.NewGuid(), Name = "Potion", Price = 9, DateCreated = DateTime.UtcNow },
            new Item() { Id = Guid.NewGuid(), Name = "Sword", Price = 15, DateCreated = DateTime.UtcNow },
            new Item() { Id = Guid.NewGuid(), Name = "Shield", Price = 10, DateCreated = DateTime.UtcNow }
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid Id)
        {
            return items.Where(item => item.Id == Id).SingleOrDefault();
        }
    }
}
